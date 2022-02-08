using Ecology.DataAccess.Common.Models.Air;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecology.DataAccess.Common.Repositories.Air
{
    public interface IPmRepository
    {
        Task<int> AddPm(PmDb pm);
        Task<IEnumerable<PmDb>> GetPms();
        Task<PmDb> DelPm(int id);
        Task<int> EditPm(PmDb pm);
    }
}
