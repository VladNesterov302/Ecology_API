using AutoMapper;
using Ecology.DataAccess.Common.Models.Air;
using Ecology.Logic.Common.Models.Air;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecology.Logic.Mappings.Air
{
    public class PmProfile : Profile
    {
        public PmProfile()
        {
            CreateMap<PmBLL, PmDb>().ReverseMap();
            CreateMap<PmDb, PmBLL>();
        }
    }
}
