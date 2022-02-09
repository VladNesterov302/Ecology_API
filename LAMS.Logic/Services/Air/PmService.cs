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
    public class PmService : IPmService
    {
        private readonly IPmRepository _repo;

        private readonly IMapper _mapper;
        public PmService(IPmRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<int> AddPm(PmBLL pm)
        {
            try
            {
                var id = await _repo.AddPm(_mapper.Map<PmDb>(pm)).ContinueWith(t => t.Result);

                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PmBLL> DelPm(int id)
        {
            return await _repo.DelPm(id)
               .ContinueWith(t => _mapper.Map<PmBLL>(t.Result));
        }

        public async Task<int> EditPm(PmBLL pm)
        {
            return await _repo.EditPm(_mapper.Map<PmDb>(pm)).ContinueWith(t => t.Result);
        }

        public async Task<IEnumerable<PmBLL>> GetPms()
        {
            return await _repo.GetPms()
             .ContinueWith(t => _mapper.Map<IEnumerable<PmBLL>>(t.Result));
        }
    }
}
