using Ecology.Logic.Common.Models.Air;
using Ecology.Logic.Common.Models.Statistic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecology.Logic.Common.Services.Air
{
   public interface IAzotService
    {
        Task<int> AddAzot(AzotBLL azot);
        Task<IEnumerable<AzotBLL>> GetAzots();
        Task<AzotBLL> DelAzot(int id);
        Task<int> EditAzot(AzotBLL azot);
        Task<IEnumerable<LevelStatisticBLL>> GetLevelStatistic();
        Task<IEnumerable<LevelStatisticBLL>> GetCityStatistic(int id);
        Task<double> SmallPrediction(int id);
        Task<double> BigPrediction(int id);
    }
}
