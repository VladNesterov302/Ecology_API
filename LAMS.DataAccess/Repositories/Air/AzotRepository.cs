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
    public class AzotRepository : IAzotRepository
    {
        private readonly DocContext _context;

        public AzotRepository(DocContext context) => _context = context;

        public async Task<int> AddAzot(AzotDb azot)
        {
            _context.Azots.Add(azot);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return azot.Id;
        }

        public async Task<AzotDb> DelAzot(int id)
        {
            AzotDb azot = await _context.Azots.FirstOrDefaultAsync(p => p.Id == id).ConfigureAwait(false);

            var result = _context.Azots.Remove(azot);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return result;
        }

        public async Task<int> EditAzot(AzotDb azot)
        {
            var azotInDb = await _context.Azots.FirstOrDefaultAsync(p => p.Id == azot.Id).ConfigureAwait(false);

            var entry = _context.Entry(azotInDb);
            entry.CurrentValues.SetValues(azot);

            return await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<AzotDb>> GetAzots()
        {
            return await _context.Azots.OrderByDescending(r => r.Id).ToListAsync().ConfigureAwait(false);
        }
    }
}
