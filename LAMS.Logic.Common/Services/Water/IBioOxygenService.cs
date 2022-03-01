using Ecology.Logic.Common.Models.Statistic;
using Ecology.Logic.Common.Models.Water;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecology.Logic.Common.Services.Water
{
    public interface IBioOxygenService
    {
        Task<int> AddBioOxygen(BioOxygenBLL bioOxygen);
        Task<IEnumerable<BioOxygenBLL>> GetBioOxygens();
        Task<BioOxygenBLL> DelBioOxygen(int id);
        Task<int> EditBioOxygen(BioOxygenBLL bioOxygen);
        Task<IEnumerable<LevelStatisticBLL>> GetLevelStatistic();
        Task<IEnumerable<LevelStatisticBLL>> GetWaterObjectStatistic(int id);
    }
}
