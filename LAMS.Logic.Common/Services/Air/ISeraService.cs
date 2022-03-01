using Ecology.Logic.Common.Models.Air;
using Ecology.Logic.Common.Models.Statistic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecology.Logic.Common.Services.Air
{
   public interface ISeraService
    {
        Task<int> AddSera(SeraBLL sera);
        Task<IEnumerable<SeraBLL>> GetSeras();
        Task<SeraBLL> DelSera(int id);
        Task<int> EditSera(SeraBLL sera);
        Task<IEnumerable<LevelStatisticBLL>> GetLevelStatistic();
        Task<IEnumerable<LevelStatisticBLL>> GetCityStatistic(int id);
    }
}
