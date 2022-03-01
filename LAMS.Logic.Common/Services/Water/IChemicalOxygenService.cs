using Ecology.Logic.Common.Models.Statistic;
using Ecology.Logic.Common.Models.Water;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecology.Logic.Common.Services.Water
{
    public interface IChemicalOxygenService
    {
        Task<int> AddChemicalOxygen(ChemicalOxygenBLL chemicalOxygen);
        Task<IEnumerable<ChemicalOxygenBLL>> GetChemicalOxygens();
        Task<ChemicalOxygenBLL> DelChemicalOxygen(int id);
        Task<int> EditChemicalOxygen(ChemicalOxygenBLL chemicalOxygen);
        Task<IEnumerable<LevelStatisticBLL>> GetLevelStatistic();
        Task<IEnumerable<LevelStatisticBLL>> GetWaterObjectStatistic(int id);
    }
}
