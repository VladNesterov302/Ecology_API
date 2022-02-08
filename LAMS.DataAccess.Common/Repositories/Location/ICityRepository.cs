using Ecology.DataAccess.Common.Models.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecology.DataAccess.Common.Repositories.Location
{
   public interface ICityRepository
    {
        Task<int> AddCity(CityDb city);
        Task<IEnumerable<CityDb>> GetCities();
        Task<int> EditCity(CityDb city);
        Task<bool> IsCityAvailable(string city);
    }
}
