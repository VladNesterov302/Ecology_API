using Ecology.Logic.Common.Models.Air;
using Ecology.Logic.Common.Models.Statistic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecology.Logic.Common.Services.Air
{
    public interface IPmService
    {
        Task<int> AddPm(PmBLL pm);
        Task<IEnumerable<PmBLL>> GetPms();
        Task<PmBLL> DelPm(int id);
        Task<int> EditPm(PmBLL pm);
        Task<IEnumerable<LevelStatisticBLL>> GetLevelStatistic();
        Task<IEnumerable<LevelStatisticBLL>> GetLevel10Statistic();
        Task<IEnumerable<LevelStatisticBLL>> GetCityStatistic(int id);
        Task<IEnumerable<LevelStatisticBLL>> GetCity10Statistic(int id);
        Task<double> SmallPrediction(int id);
        Task<double> BigPrediction10(int id);
        Task<double> SmallPrediction10(int id);
        Task<double> BigPrediction(int id);
    }
}
