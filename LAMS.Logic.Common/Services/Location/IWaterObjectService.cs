using Ecology.Logic.Common.Models.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecology.Logic.Common.Services.Location
{
    public interface IWaterObjectService
    {
        Task<int> AddWaterObject(WaterObjectBLL waterObject);
        Task<IEnumerable<WaterObjectBLL>> GetWaterObjects();
        Task<int> EditWaterObject(WaterObjectBLL waterObject);
    }
}
