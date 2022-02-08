using Ecology.DataAccess.Common.Models.Radiation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecology.DataAccess.Common.Repositories.Radiation
{
    public interface IRadiationRepository
    {
        Task<int> AddRadiation(RadiationDb radiation);
        Task<IEnumerable<RadiationDb>> GetRadiations();
        Task<RadiationDb> DelRadiation(int id);
        Task<int> EditRadiation(RadiationDb radiation);
    }
}
