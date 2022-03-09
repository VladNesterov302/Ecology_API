using Ecology.DataAccess.Common.DTO;
using Ecology.DataAccess.Common.Models.Water;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecology.DataAccess.Common.Repositories.Water
{
   public interface IPhRepository
    {
        Task<int> AddPh(PhDb ph);
        Task<IEnumerable<PhDb>> GetPhs();
        Task<PhDb> DelPh(int id);
        Task<int> EditPh(PhDb ph);
        Task<IEnumerable<LevelStatisticDTO>> GetLevelStatistic();
        Task<IEnumerable<LevelStatisticDTO>> GetWaterObjectStatistic(int id);
        Task<double> SmallPrediction(int id);
        Task<double> BigPrediction(int id);

    }
}
