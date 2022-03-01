using Ecology.Logic.Common.Models.Statistic;
using Ecology.Logic.Common.Models.Water;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecology.Logic.Common.Services.Water
{
    public interface IPhService
    {
        Task<int> AddPh(PhBLL ph);
        Task<IEnumerable<PhBLL>> GetPhs();
        Task<PhBLL> DelPh(int id);
        Task<int> EditPh(PhBLL ph);
        Task<IEnumerable<LevelStatisticBLL>> GetLevelStatistic();
        Task<IEnumerable<LevelStatisticBLL>> GetWaterObjectStatistic(int id);
    }
}
