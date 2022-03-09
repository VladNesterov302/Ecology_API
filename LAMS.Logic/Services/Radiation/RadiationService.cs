using AutoMapper;
using Ecology.DataAccess.Common.Models.Radiation;
using Ecology.DataAccess.Common.Repositories.Radiation;
using Ecology.Logic.Common.Models.Radiation;
using Ecology.Logic.Common.Models.Statistic;
using Ecology.Logic.Common.Services.Radiation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecology.Logic.Services.Radiation
{
    public class RadiationService : IRadiationService
    {
        private readonly IRadiationRepository _repo;

        private readonly IMapper _mapper;
        public RadiationService(IRadiationRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<int> AddRadiation(RadiationBLL radiation)
        {
            try
            {
                var id = await _repo.AddRadiation(_mapper.Map<RadiationDb>(radiation)).ContinueWith(t => t.Result);

                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<RadiationBLL> DelRadiation(int id)
        {
            return await _repo.DelRadiation(id)
               .ContinueWith(t => _mapper.Map<RadiationBLL>(t.Result));
        }

        public async Task<int> EditRadiation(RadiationBLL radiation)
        {
            return await _repo.EditRadiation(_mapper.Map<RadiationDb>(radiation)).ContinueWith(t => t.Result);
        }

        public async Task<IEnumerable<RadiationBLL>> GetRadiations()
        {
            return await _repo.GetRadiations()
                .ContinueWith(t => _mapper.Map<IEnumerable<RadiationBLL>>(t.Result));
        }

        public async Task<IEnumerable<LevelRadiationStatisticBLL>> GetLevelStatistic()
        {
            return await _repo.GetLevelStatistic()
                .ContinueWith(t => _mapper.Map<IEnumerable<LevelRadiationStatisticBLL>>(t.Result));
        }

        public async Task<IEnumerable<LevelRadiationStatisticBLL>> GetCityStatistic(int id)
        {
            return await _repo.GetCityStatistic(id)
                .ContinueWith(t => _mapper.Map<IEnumerable<LevelRadiationStatisticBLL>>(t.Result));
        }

        public async Task<double> SmallPrediction(int id)
        {
            return await _repo.SmallPrediction(_mapper.Map<int>(id)).ContinueWith(t => t.Result);
        }
        public async Task<double> BigPrediction(int id)
        {
            return await _repo.BigPrediction(_mapper.Map<int>(id)).ContinueWith(t => t.Result);
        }
    }
}
