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
   public class ChemicalOxygenRepository : IChemicalOxygenRepository
    {
        private readonly DocContext _context;

        public ChemicalOxygenRepository(DocContext context) => _context = context;

        public async Task<int> AddChemicalOxygen(ChemicalOxygenDb oxygen)
        {
            oxygen.Date = DateTime.Now;
            _context.ChemicalOxygens.Add(oxygen);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return oxygen.Id;
        }

        public async Task<ChemicalOxygenDb> DelChemicalOxygen(int id)
        {
            ChemicalOxygenDb oxygen = await _context.ChemicalOxygens.FirstOrDefaultAsync(p => p.Id == id).ConfigureAwait(false);

            var result = _context.ChemicalOxygens.Remove(oxygen);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return result;
        }

        public async Task<int> EditChemicalOxygen(ChemicalOxygenDb oxygen)
        {
            var oxygenInDb = await _context.ChemicalOxygens.FirstOrDefaultAsync(p => p.Id == oxygen.Id).ConfigureAwait(false);

            var entry = _context.Entry(oxygenInDb);
            entry.CurrentValues.SetValues(oxygen);
            return await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<ChemicalOxygenDb>> GetChemicalOxygens()
        {
            return await _context.ChemicalOxygens.ToListAsync().ConfigureAwait(false);
        }
    }
}
