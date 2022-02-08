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
    public class WaterObjectRepository : IWaterObjectRepository
    {
        private readonly DocContext _context;

        public WaterObjectRepository(DocContext context) => _context = context;

        public async Task<int> AddWaterObject(WaterObjectDb waterObject)
        {
            _context.WaterObjects.Add(waterObject);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return waterObject.Id;
        }

        public async Task<int> EditWaterObject(WaterObjectDb waterObject)
        {
            var objInDb = await _context.WaterObjects.FirstOrDefaultAsync(p => p.Id == waterObject.Id).ConfigureAwait(false);

            var entry = _context.Entry(objInDb);
            entry.CurrentValues.SetValues(waterObject);

            return await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<WaterObjectDb>> GetWaterObjects()
        {
            return await _context.WaterObjects.ToListAsync().ConfigureAwait(false);
        }

        public async Task<bool> IsWaterObjectAvailable(string waterObject)
        {
            return !(await _context.WaterObjects.AnyAsync(u => u.WaterObject == waterObject).ConfigureAwait(false));
        }
    }
}
