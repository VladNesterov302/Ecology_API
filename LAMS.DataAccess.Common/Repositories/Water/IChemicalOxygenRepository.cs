using Ecology.DataAccess.Common.DTO;
using Ecology.DataAccess.Common.Models.Water;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecology.DataAccess.Common.Repositories.Water
{
   public interface IChemicalOxygenRepository
    {
        Task<int> AddChemicalOxygen(ChemicalOxygenDb oxygen);
        Task<IEnumerable<ChemicalOxygenDb>> GetChemicalOxygens();
        Task<ChemicalOxygenDb> DelChemicalOxygen(int id);
        Task<int> EditChemicalOxygen(ChemicalOxygenDb oxygen);

        Task<IEnumerable<LevelStatisticDTO>> GetLevelStatistic();
        Task<IEnumerable<LevelStatisticDTO>> GetWaterObjectStatistic(int id);
        Task<double> SmallPrediction(int id);
        Task<double> BigPrediction(int id);

    }
}
