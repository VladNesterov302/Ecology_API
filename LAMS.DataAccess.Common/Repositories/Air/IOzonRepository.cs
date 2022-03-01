using Ecology.DataAccess.Common.DTO;
using Ecology.DataAccess.Common.Models.Air;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecology.DataAccess.Common.Repositories.Air
{
    public interface IOzonRepository
    {
        Task<int> AddOzon(OzonDb ozon);
        Task<IEnumerable<OzonDb>> GetOzons();
        Task<OzonDb> DelOzon(int id);
        Task<int> EditOzon(OzonDb ozon);

        Task<IEnumerable<LevelStatisticDTO>> GetLevelStatistic();
        Task<IEnumerable<LevelStatisticDTO>> GetCityStatistic(int id);
    }
}
