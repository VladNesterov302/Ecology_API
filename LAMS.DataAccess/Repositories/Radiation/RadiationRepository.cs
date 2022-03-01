using Ecology.DataAccess.Common.DTO;
using Ecology.DataAccess.Common.Models.Radiation;
using Ecology.DataAccess.Common.Repositories.Radiation;
using Ecology.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecology.DataAccess.Repositories.Radiation
{
    public class RadiationRepository : IRadiationRepository
    {
        private readonly DocContext _context;

        public RadiationRepository(DocContext context) => _context = context;

        public async Task<int> AddRadiation(RadiationDb radiation)
        {
            radiation.Date = DateTime.Now;
            _context.Radiations.Add(radiation);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return radiation.Id;
        }

        public async Task<RadiationDb> DelRadiation(int id)
        {
            RadiationDb radiation = await _context.Radiations.FirstOrDefaultAsync(p => p.Id == id).ConfigureAwait(false);

            var result = _context.Radiations.Remove(radiation);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return result;
        }

        public async Task<int> EditRadiation(RadiationDb radiation)
        {
            var radiationInDb = await _context.Radiations.FirstOrDefaultAsync(p => p.Id == radiation.Id).ConfigureAwait(false);

            var entry = _context.Entry(radiationInDb);
            entry.CurrentValues.SetValues(radiation);

            return await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<RadiationDb>> GetRadiations()
        {
            return await _context.Radiations.OrderByDescending(r => r.Id).ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<LevelRadiationStatisticDTO>> GetLevelStatistic()
        {
            List<LevelRadiationStatisticDTO> stat = await _context.Radiations
                .GroupBy(o => o.Level)
                 .Select(m =>
                    new LevelRadiationStatisticDTO
                    {
                        Level = m.Key,
                        Number = m.Count()
                    })
                 .OrderBy(o => o.Level).ToListAsync();

            return stat;
        }

        public async Task<IEnumerable<LevelRadiationStatisticDTO>> GetCityStatistic(int id)
        {
            List<LevelRadiationStatisticDTO> stat = await _context.Radiations.Where(s => s.IdCity == id)
                .GroupBy(o => o.Level)
                 .Select(m =>
                    new LevelRadiationStatisticDTO
                    {
                        Level = m.Key,
                        Number = m.Count()
                    })
                 .OrderBy(o => o.Level).ToListAsync();

            return stat;
        }
    }
}
