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
    public class AzotProfile : Profile
    {
        public AzotProfile()
        {
            CreateMap<AzotBLL, AzotDb>().ReverseMap();
            CreateMap<AzotDb, AzotBLL>();
        }
    }
}