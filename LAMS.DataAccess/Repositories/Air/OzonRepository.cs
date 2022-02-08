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
            return await _context.Ozons.ToListAsync().ConfigureAwait(false);
        }
    }
}
