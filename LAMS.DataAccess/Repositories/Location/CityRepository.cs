using Ecology.DataAccess.Common.Models.Location;
using Ecology.DataAccess.Common.Repositories.Location;
using Ecology.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecology.DataAccess.Repositories.Location
{
    public class CityRepository : ICityRepository
    {
        private readonly DocContext _context;

        public CityRepository(DocContext context) => _context = context;

        public async Task<int> AddCity(CityDb city)
        {
            _context.Cities.Add(city);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return city.Id;
        }

        public async Task<int> EditCity(CityDb city)
        {
            var cityInDb = await _context.Radiations.FirstOrDefaultAsync(p => p.Id == city.Id).ConfigureAwait(false);

            var entry = _context.Entry(cityInDb);
            entry.CurrentValues.SetValues(city);

            return await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<CityDb>> GetCities()
        {
            return await _context.Cities.ToListAsync().ConfigureAwait(false);
        }

        public async Task<bool> IsCityAvailable(string city)
        {
            return !(await _context.Cities.AnyAsync(u => u.City == city).ConfigureAwait(false));
        }
    }
}
