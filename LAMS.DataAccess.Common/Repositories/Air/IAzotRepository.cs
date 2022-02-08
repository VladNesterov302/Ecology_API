using Ecology.DataAccess.Common.Models.Air;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecology.DataAccess.Common.Repositories.Air
{
    public interface IAzotRepository
    {
        Task<int> AddAzot(AzotDb azot);
        Task<IEnumerable<AzotDb>> GetAzots();
        Task<AzotDb> DelAzot(int id);
        Task<int> EditAzot(AzotDb azot);
    }
}
