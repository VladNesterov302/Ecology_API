using Ecology.DataAccess.Common.Models.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecology.DataAccess.Common.Repositories.Location
{
   public interface IWaterObjectRepository
    {
        Task<int> AddWaterObject(WaterObjectDb waterObject);
        Task<IEnumerable<WaterObjectDb>> GetWaterObjects();
        Task<int> EditWaterObject(WaterObjectDb waterObject);
        Task<bool> IsWaterObjectAvailable(string waterObject);
    }
}
