﻿using AutoMapper;
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
    public class BioOxygenService : IBioOxygenService
    {
        private readonly IBioOxygenRepository _repo;

        private readonly IMapper _mapper;
        public BioOxygenService(IBioOxygenRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<int> AddBioOxygen(BioOxygenBLL bioOxygen)
        {
            try
            {
                var id = await _repo.AddBioOxygen(_mapper.Map<BioOxygenDb>(bioOxygen)).ContinueWith(t => t.Result);

                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BioOxygenBLL> DelBioOxygen(int id)
        {
            return await _repo.DelBioOxygen(id)
              .ContinueWith(t => _mapper.Map<BioOxygenBLL>(t.Result));
        }

        public async Task<int> EditBioOxygen(BioOxygenBLL bioOxygen)
        {
            return await _repo.EditBioOxygen(_mapper.Map<BioOxygenDb>(bioOxygen)).ContinueWith(t => t.Result);
        }

        public async Task<IEnumerable<BioOxygenBLL>> GetBioOxygens()
        {
            return await _repo.GetBioOxygens()
               .ContinueWith(t => _mapper.Map<IEnumerable<BioOxygenBLL>>(t.Result));
        }
    }
}
