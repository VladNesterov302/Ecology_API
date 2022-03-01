using Ecology.Logic.Common.Models.Air;
using Ecology.Logic.Common.Models.Statistic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecology.Logic.Common.Services.Air
{
    public interface IOzonService
    {
        Task<int> AddOzon(OzonBLL ozon);
        Task<IEnumerable<OzonBLL>> GetOzons();
        Task<OzonBLL> DelOzon(int id);
        Task<int> EditOzon(OzonBLL ozon);
        Task<IEnumerable<LevelStatisticBLL>> GetLevelStatistic();
        Task<IEnumerable<LevelStatisticBLL>> GetCityStatistic(int id);
    }
}
