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
    public class SeraRepository : ISeraRepository
    {
        private readonly DocContext _context;

        public SeraRepository(DocContext context) => _context = context;

        public async Task<int> AddSera(SeraDb sera)
        {
            _context.Seras.Add(sera);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return sera.Id;
        }

        public async Task<SeraDb> DelSera(int id)
        {
            SeraDb sera = await _context.Seras.FirstOrDefaultAsync(p => p.Id == id).ConfigureAwait(false);

            var result = _context.Seras.Remove(sera);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return result;
        }

        public async Task<int> EditSera(SeraDb sera)
        {
            var seraInDb = await _context.Seras.FirstOrDefaultAsync(p => p.Id == p.Id).ConfigureAwait(false);

            var entry = _context.Entry(seraInDb);
            entry.CurrentValues.SetValues(sera);

            return await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<SeraDb>> GetSeras()
        {
            return await _context.Seras.ToListAsync().ConfigureAwait(false);
        }
    }
}
