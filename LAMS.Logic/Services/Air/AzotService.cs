using AutoMapper;
using Ecology.DataAccess.Common.Models.Air;
using Ecology.DataAccess.Common.Repositories.Air;
using Ecology.Logic.Common.Models.Air;
using Ecology.Logic.Common.Services.Air;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecology.Logic.Services.Air
{
    public class AzotService : IAzotService
    {
        private readonly IAzotRepository _repo;

        private readonly IMapper _mapper;
        public AzotService(IAzotRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<int> AddAzot(AzotBLL azot)
        {
            try
            {
                var id = await _repo.AddAzot(_mapper.Map<AzotDb>(azot)).ContinueWith(t => t.Result);

                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<AzotBLL> DelAzot(int id)
        {
            return await _repo.DelAzot(id)
                .ContinueWith(t => _mapper.Map<AzotBLL>(t.Result));
        }

        public async Task<int> EditAzot(AzotBLL azot)
        {
            return await _repo.EditAzot(_mapper.Map<AzotDb>(azot)).ContinueWith(t => t.Result);
        }

        public async Task<IEnumerable<AzotBLL>> GetAzots()
        {
            return await _repo.GetAzots()
              .ContinueWith(t => _mapper.Map<IEnumerable<AzotBLL>>(t.Result));
        }
    }
}
