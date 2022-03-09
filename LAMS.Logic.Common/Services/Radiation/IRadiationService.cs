using Ecology.Logic.Common.Models.Radiation;
using Ecology.Logic.Common.Models.Statistic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecology.Logic.Common.Services.Radiation
{
    public interface IRadiationService
    {
        Task<int> AddRadiation(RadiationBLL radiation);
        Task<IEnumerable<RadiationBLL>> GetRadiations();
        Task<RadiationBLL> DelRadiation(int id);
        Task<int> EditRadiation(RadiationBLL radiation);

        Task<IEnumerable<LevelRadiationStatisticBLL>> GetLevelStatistic();
        Task<IEnumerable<LevelRadiationStatisticBLL>> GetCityStatistic(int id);

        Task<double> SmallPrediction(int id);
        Task<double> BigPrediction(int id);
    }
}
