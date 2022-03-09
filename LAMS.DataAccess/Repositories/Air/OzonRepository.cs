using Ecology.DataAccess.Common.DTO;
using Ecology.DataAccess.Common.Models.Air;
using Ecology.DataAccess.Common.Repositories.Air;
using Ecology.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecology.DataAccess.Repositories.Air
{
    public class OzonRepository : IOzonRepository
    {
        private readonly DocContext _context;

        public OzonRepository(DocContext context) => _context = context;

        public async Task<int> AddOzon(OzonDb ozon)
        {
            ozon.Date = DateTime.Now;
            _context.Ozons.Add(ozon);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return ozon.Id;
        }

        public async Task<OzonDb> DelOzon(int id)
        {
            OzonDb ozon = await _context.Ozons.FirstOrDefaultAsync(p => p.Id == id).ConfigureAwait(false);

            var result = _context.Ozons.Remove(ozon);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return result;
        }

        public async Task<int> EditOzon(OzonDb ozon)
        {
            var ozonInDb = await _context.Ozons.FirstOrDefaultAsync(p => p.Id == ozon.Id).ConfigureAwait(false);

            var entry = _context.Entry(ozonInDb);
            entry.CurrentValues.SetValues(ozon);

            return await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<OzonDb>> GetOzons()
        {
            return await _context.Ozons.OrderByDescending(r => r.Id).ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<LevelStatisticDTO>> GetLevelStatistic()
        {
            List<LevelStatisticDTO> stat = await _context.Ozons
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
        public async Task<IEnumerable<LevelStatisticDTO>> GetCityStatistic(int id)
        {
            List<LevelStatisticDTO> stat = await _context.Ozons.Where(s => s.IdCity == id)
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
            IEnumerable<OzonDb> items = await _context.Ozons.Where(o =>
                o.IdCity == id
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
            IEnumerable<OzonDb> items = await _context.Ozons.Where(o =>
                o.IdCity == id
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
