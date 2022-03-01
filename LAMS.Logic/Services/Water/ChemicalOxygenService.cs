using AutoMapper;
using Ecology.DataAccess.Common.Models.Water;
using Ecology.DataAccess.Common.Repositories.Water;
using Ecology.Logic.Common.Models.Statistic;
using Ecology.Logic.Common.Models.Water;
using Ecology.Logic.Common.Services.Water;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecology.Logic.Services.Water
{
    public class ChemicalOxygenService : IChemicalOxygenService
    {
        private readonly IChemicalOxygenRepository _repo;

        private readonly IMapper _mapper;
        public ChemicalOxygenService(IChemicalOxygenRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<int> AddChemicalOxygen(ChemicalOxygenBLL chemicalOxygen)
        {
            try
            {
                var id = await _repo.AddChemicalOxygen(_mapper.Map<ChemicalOxygenDb>(chemicalOxygen)).ContinueWith(t => t.Result);

                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ChemicalOxygenBLL> DelChemicalOxygen(int id)
        {
            return await _repo.DelChemicalOxygen(id)
              .ContinueWith(t => _mapper.Map<ChemicalOxygenBLL>(t.Result));
        }

        public async Task<int> EditChemicalOxygen(ChemicalOxygenBLL chemicalOxygen)
        {
            return await _repo.EditChemicalOxygen(_mapper.Map<ChemicalOxygenDb>(chemicalOxygen)).ContinueWith(t => t.Result);
        }

        public async Task<IEnumerable<ChemicalOxygenBLL>> GetChemicalOxygens()
        {
            return await _repo.GetChemicalOxygens()
                .ContinueWith(t => _mapper.Map<IEnumerable<ChemicalOxygenBLL>>(t.Result));
        }
        public async Task<IEnumerable<LevelStatisticBLL>> GetLevelStatistic()
        {
            return await _repo.GetLevelStatistic()
                .ContinueWith(t => _mapper.Map<IEnumerable<LevelStatisticBLL>>(t.Result));
        }
        public async Task<IEnumerable<LevelStatisticBLL>> GetWaterObjectStatistic(int id)
        {
            return await _repo.GetWaterObjectStatistic(id)
                .ContinueWith(t => _mapper.Map<IEnumerable<LevelStatisticBLL>>(t.Result));
        }
    }
}
