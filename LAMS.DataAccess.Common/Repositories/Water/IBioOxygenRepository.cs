using Ecology.DataAccess.Common.DTO;
using Ecology.DataAccess.Common.Models.Water;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecology.DataAccess.Common.Repositories.Water
{
   public interface IBioOxygenRepository
    {
        Task<int> AddBioOxygen(BioOxygenDb oxygen);
        Task<IEnumerable<BioOxygenDb>> GetBioOxygens();
        Task<BioOxygenDb> DelBioOxygen(int id);
        Task<int> EditBioOxygen(BioOxygenDb oxygen);

        Task<IEnumerable<LevelStatisticDTO>> GetLevelStatistic();
        Task<IEnumerable<LevelStatisticDTO>> GetWaterObjectStatistic(int id);
    }
}
