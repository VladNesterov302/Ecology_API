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
    public class SeraProfile : Profile
    {
        public SeraProfile()
        {
            CreateMap<SeraBLL, SeraDb>().ReverseMap();
            CreateMap<SeraDb, SeraBLL>();
        }
    }
}
