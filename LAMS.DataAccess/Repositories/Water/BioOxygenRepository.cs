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
    public class BioOxygenRepository : IBioOxygenRepository
    {
        private readonly DocContext _context;

        public BioOxygenRepository(DocContext context) => _context = context;
        public async Task<int> AddBioOxygen(BioOxygenDb oxygen)
        {
            oxygen.Date = DateTime.Now;
            _context.BioOxygens.Add(oxygen);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return oxygen.Id;
        }

        public async Task<BioOxygenDb> DelBioOxygen(int id)
        {
            BioOxygenDb oxygen = await _context.BioOxygens.FirstOrDefaultAsync(p => p.Id == id).ConfigureAwait(false);

            var result = _context.BioOxygens.Remove(oxygen);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return result;
        }

        public async Task<int> EditBioOxygen(BioOxygenDb oxygen)
        {
            var oxygenInDb = await _context.BioOxygens.FirstOrDefaultAsync(p => p.Id == oxygen.Id).ConfigureAwait(false);

            var entry = _context.Entry(oxygenInDb);
            entry.CurrentValues.SetValues(oxygen);
            return await _context.SaveChangesAsync().ConfigureAwait(false);

        }

        public async Task<IEnumerable<BioOxygenDb>> GetBioOxygens()
        {
            return await _context.BioOxygens.ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<LevelStatisticDTO>> GetLevelStatistic()
        {
            List<LevelStatisticDTO> stat = await _context.BioOxygens
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
            List<LevelStatisticDTO> stat = await _context.BioOxygens.Where(s => s.IdWaterObject == id)
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
            IEnumerable<BioOxygenDb> items = await _context.BioOxygens.Where(o =>
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
            IEnumerable<BioOxygenDb> items = await _context.BioOxygens.Where(o =>
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
