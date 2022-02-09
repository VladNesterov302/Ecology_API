using Ecology.Logic.Common.Models.Air;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecology.Logic.Common.Services.Air
{
   public interface IAzotService
    {
        Task<int> AddAzot(AzotBLL azot);
        Task<IEnumerable<AzotBLL>> GetAzots();
        Task<AzotBLL> DelAzot(int id);
        Task<int> EditAzot(AzotBLL azot);
    }
}
