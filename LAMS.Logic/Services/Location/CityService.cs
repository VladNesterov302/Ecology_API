using AutoMapper;
using Ecology.DataAccess.Common.Models.Location;
using Ecology.DataAccess.Common.Repositories.Location;
using Ecology.Logic.Common.Models.Location;
using Ecology.Logic.Common.Services.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecology.Logic.Services.Location
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _repo;

        private readonly IMapper _mapper;

        public CityService(ICityRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<int> AddCity(CityBLL city)
        {
            try
            {
                if (!await _repo.IsCityAvailable(city.City))
                {
                    return 0;
                }
                var id = await _repo.AddCity(_mapper.Map<CityDb>(city)).ContinueWith(t => t.Result);

                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> EditCity(CityBLL city)
        {
            return await _repo.EditCity(_mapper.Map<CityDb>(city)).ContinueWith(t => t.Result);
        }

        public async Task<IEnumerable<CityBLL>> GetCities()
        {
            return await _repo.GetCities()
               .ContinueWith(t => _mapper.Map<IEnumerable<CityBLL>>(t.Result));
        }
    }
}
