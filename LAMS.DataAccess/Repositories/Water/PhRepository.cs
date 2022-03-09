using Ecology.DataAccess.Common.DTO;
using Ecology.DataAccess.Common.Models.Water;
using Ecology.DataAccess.Common.Repositories.Water;
using Ecology.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecology.DataAccess.Repositories.Water
{
    public class PhRepository : IPhRepository
    {
        private readonly DocContext _context;

        public PhRepository(DocContext context) => _context = context;
        public async Task<int> AddPh(PhDb ph)
        {
            ph.Date = DateTime.Now;
            _context.Phs.Add(ph);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return ph.Id;
        }

        public async Task<PhDb> DelPh(int id)
        {
            PhDb ph = await _context.Phs.FirstOrDefaultAsync(p => p.Id == id).ConfigureAwait(false);

            var result = _context.Phs.Remove(ph);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return result; throw new NotImplementedException();
        }

        public async Task<int> EditPh(PhDb ph)
        {
            var phInDb = await _context.Phs.FirstOrDefaultAsync(p => p.Id == ph.Id).ConfigureAwait(false);

            var entry = _context.Entry(phInDb);
            entry.CurrentValues.SetValues(ph);
            return await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<PhDb>> GetPhs()
        {
            return await _context.Phs.ToListAsync().ConfigureAwait(false);
        }
        public async Task<IEnumerable<LevelStatisticDTO>> GetLevelStatistic()
        {
            List<LevelStatisticDTO> stat = await _context.Phs
                .GroupBy(o => o.Level)
                 .Select(m =>
                    new LevelStatisticDTO
                    {
                        Level = m.Key,
                        Number = m.Count()
                    })
                 .OrderBy(o => o.Level).ToListAsync();

            return stat;
        }

        public async Task<IEnumerable<LevelStatisticDTO>> GetWaterObjectStatistic(int id)
        {
            List<LevelStatisticDTO> stat = await _context.Phs.Where(s => s.IdWaterObject == id)
                .GroupBy(o => o.Level)
                 .Select(m =>
                    new LevelStatisticDTO
                    {
                        Level = m.Key,
                        Number = m.Count()
                    })
                 .OrderBy(o => o.Level).ToListAsync();

            return stat;
        }
        public async Task<double> SmallPrediction(int id)
        {
            double prediction = 0;
            IEnumerable<PhDb> items = await _context.Phs.Where(o =>
                o.IdWaterObject == id
            ).OrderByDescending(o => o.Date).ToListAsync().ConfigureAwait(false);

            if (items.Count() == 0)
            {
                return prediction;
            }
            else
            {
                prediction = items.Take(7).Average(o => o.Dose);
                return prediction;
            }
        }
        public async Task<double> BigPrediction(int id)
        {
            double prediction = 0;
            IEnumerable<PhDb> items = await _context.Phs.Where(o =>
                o.IdWaterObject == id
            ).OrderByDescending(o => o.Date).ToListAsync().ConfigureAwait(false);

            if (items.Count() == 0)
            {
                return prediction;
            }
            else
            {
                prediction = items.Take(30).Average(o => o.Dose);
                return prediction;
            }

        }
    }
}
