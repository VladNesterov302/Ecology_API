using AutoMapper;
using Ecology.DataAccess.Common.Models.Water;
using Ecology.DataAccess.Common.Repositories.Water;
using Ecology.Logic.Common.Models.Water;
using Ecology.Logic.Common.Services.Water;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecology.Logic.Services.Water
{
    public class PhService : IPhService
    {
        private readonly IPhRepository _repo;

        private readonly IMapper _mapper;
        public PhService(IPhRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<int> AddPh(PhBLL ph)
        {
            try
            {
                var id = await _repo.AddPh(_mapper.Map<PhDb>(ph)).ContinueWith(t => t.Result);

                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PhBLL> DelPh(int id)
        {
            return await _repo.DelPh(id)
              .ContinueWith(t => _mapper.Map<PhBLL>(t.Result));
        }

        public async Task<int> EditPh(PhBLL ph)
        {
            return await _repo.EditPh(_mapper.Map<PhDb>(ph)).ContinueWith(t => t.Result);
        }

        public async Task<IEnumerable<PhBLL>> GetPhs()
        {
            return await _repo.GetPhs()
               .ContinueWith(t => _mapper.Map<IEnumerable<PhBLL>>(t.Result));
        }
    }
}
