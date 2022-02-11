using AutoMapper;
using Ecology.DataAccess.Common.Models.Water;
using Ecology.Logic.Common.Models.Water;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecology.Logic.Mappings.Water
{
    public class BioOxygenProfile : Profile
    {
        public BioOxygenProfile()
        {
            CreateMap<BioOxygenBLL, BioOxygenDb>().ReverseMap();
            CreateMap<BioOxygenDb, BioOxygenBLL>();
        }
    }
}