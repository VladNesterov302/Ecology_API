using Ecology.Logic.Common.Models.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecology.Logic.Common.Services.Location
{
    public interface ICityService
    {
        Task<int> AddCity(CityBLL city);
        Task<IEnumerable<CityBLL>> GetCities();
        Task<int> EditCity(CityBLL city);
    }
}
