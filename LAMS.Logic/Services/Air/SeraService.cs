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
    public class SeraService : ISeraService
    {
        private readonly ISeraRepository _repo;

        private readonly IMapper _mapper;
        public SeraService(ISeraRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<int> AddSera(SeraBLL sera)
        {
            try
            {
                var id = await _repo.AddSera(_mapper.Map<SeraDb>(sera)).ContinueWith(t => t.Result);

                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<SeraBLL> DelSera(int id)
        {
            return await _repo.DelSera(id)
              .ContinueWith(t => _mapper.Map<SeraBLL>(t.Result));
        }

        public async Task<int> EditSera(SeraBLL sera)
        {
            return await _repo.EditSera(_mapper.Map<SeraDb>(sera)).ContinueWith(t => t.Result);
        }

        public async Task<IEnumerable<SeraBLL>> GetSeras()
        {
            return await _repo.GetSeras()
               .ContinueWith(t => _mapper.Map<IEnumerable<SeraBLL>>(t.Result));
        }
    }
}
