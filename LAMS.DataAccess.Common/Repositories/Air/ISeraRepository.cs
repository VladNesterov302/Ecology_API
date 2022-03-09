using Ecology.DataAccess.Common.DTO;
using Ecology.DataAccess.Common.Models.Air;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecology.DataAccess.Common.Repositories.Air
{
   public interface ISeraRepository
    {
        Task<int> AddSera(SeraDb sera);
        Task<IEnumerable<SeraDb>> GetSeras();
        Task<SeraDb> DelSera(int id);
        Task<int> EditSera(SeraDb sera);
        Task<IEnumerable<LevelStatisticDTO>> GetLevelStatistic();
        Task<IEnumerable<LevelStatisticDTO>> GetCityStatistic(int id);
        Task<double> SmallPrediction(int id);
        Task<double> BigPrediction(int id);
    }
}
