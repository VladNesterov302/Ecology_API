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
    public class WaterObjectService : IWaterObjectService
    {
        private readonly IWaterObjectRepository _repo;

        private readonly IMapper _mapper;

        public WaterObjectService(IWaterObjectRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<int> AddWaterObject(WaterObjectBLL waterObject)
        {
            try
            {
                if (!await _repo.IsWaterObjectAvailable(waterObject.WaterObject))
                {
                    return 0;
                }
                var id = await _repo.AddWaterObject(_mapper.Map<WaterObjectDb>(waterObject)).ContinueWith(t => t.Result);

                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> EditWaterObject(WaterObjectBLL waterObject)
        {
            return await _repo.EditWaterObject(_mapper.Map<WaterObjectDb>(waterObject)).ContinueWith(t => t.Result);
        }

        public async Task<IEnumerable<WaterObjectBLL>> GetWaterObjects()
        {
            return await _repo.GetWaterObjects()
                .ContinueWith(t => _mapper.Map<IEnumerable<WaterObjectBLL>>(t.Result));
        }
    }
}
