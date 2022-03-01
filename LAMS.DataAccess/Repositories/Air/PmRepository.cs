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
    public class PmRepository : IPmRepository
    {
        private readonly DocContext _context;

        public PmRepository(DocContext context) => _context = context;

        public async Task<int> AddPm(PmDb pm)
        {
            pm.Date = DateTime.Now;
            _context.Pms.Add(pm);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return pm.Id;
        }

        public async Task<PmDb> DelPm(int id)
        {
            PmDb pm = await _context.Pms.FirstOrDefaultAsync(p => p.Id == id).ConfigureAwait(false);

            var result = _context.Pms.Remove(pm);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return result;
        }

        public async Task<int> EditPm(PmDb pm)
        {
            var pmInDb = await _context.Pms.FirstOrDefaultAsync(p => p.Id == p.Id).ConfigureAwait(false);

            var entry = _context.Entry(pmInDb);
            entry.CurrentValues.SetValues(pm);

            return await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<PmDb>> GetPms()
        {
            return await _context.Pms.OrderByDescending(r => r.Id).ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<LevelStatisticDTO>> GetLevelStatistic()
        {
            List<LevelStatisticDTO> stat = await _context.Pms
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
        public async Task<IEnumerable<LevelStatisticDTO>> GetLevel10Statistic()
        {
            List<LevelStatisticDTO> stat = await _context.Pms
                .GroupBy(o => o.Level10)
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
            List<LevelStatisticDTO> stat = await _context.Pms.Where(s => s.IdCity == id)
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

        public async Task<IEnumerable<LevelStatisticDTO>> GetCity10Statistic(int id)
        {
            List<LevelStatisticDTO> stat = await _context.Pms.Where(s => s.IdCity == id)
                .GroupBy(o => o.Level10)
                 .Select(m =>
                    new LevelStatisticDTO
                    {
                        Level = m.Key,
                        Number = m.Count()
                    })
                 .OrderBy(o => o.Level).ToListAsync();

            return stat;
        }
    }
}
