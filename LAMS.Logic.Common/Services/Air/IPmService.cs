using Ecology.Logic.Common.Models.Air;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecology.Logic.Common.Services.Air
{
    public interface IPmService
    {
        Task<int> AddPm(PmBLL pm);
        Task<IEnumerable<PmBLL>> GetPms();
        Task<PmBLL> DelPm(int id);
        Task<int> EditPm(PmBLL pm);
    }
}
