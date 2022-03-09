using AutoMapper;
using Ecology.DataAccess.Common.Models.Air;
using Ecology.DataAccess.Common.Repositories.Air;
using Ecology.Logic.Common.Models.Air;
using Ecology.Logic.Common.Models.Statistic;
using Ecology.Logic.Common.Services.Air;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecology.Logic.Services.Air
{
    public class OzonService : IOzonService
    {
        private readonly IOzonRepository _repo;

        private readonly IMapper _mapper;
        public OzonService(IOzonRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<int> AddOzon(OzonBLL ozon)
        {
            try
            {
                var id = await _repo.AddOzon(_mapper.Map<OzonDb>(ozon)).ContinueWith(t => t.Result);

                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<OzonBLL> DelOzon(int id)
        {
            return await _repo.DelOzon(id)
               .ContinueWith(t => _mapper.Map<OzonBLL>(t.Result));
        }

        public async Task<int> EditOzon(OzonBLL ozon)
        {
            return await _repo.EditOzon(_mapper.Map<OzonDb>(ozon)).ContinueWith(t => t.Result);
        }

        public async Task<IEnumerable<OzonBLL>> GetOzons()
        {
            return await _repo.GetOzons()
               .ContinueWith(t => _mapper.Map<IEnumerable<OzonBLL>>(t.Result));
        }
        public async Task<IEnumerable<LevelStatisticBLL>> GetLevelStatistic()
        {
            return await _repo.GetLevelStatistic()
                .ContinueWith(t => _mapper.Map<IEnumerable<LevelStatisticBLL>>(t.Result));
        }
        public async Task<IEnumerable<LevelStatisticBLL>> GetCityStatistic(int id)
        {
            return await _repo.GetCityStatistic(id)
                .ContinueWith(t => _mapper.Map<IEnumerable<LevelStatisticBLL>>(t.Result));
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
