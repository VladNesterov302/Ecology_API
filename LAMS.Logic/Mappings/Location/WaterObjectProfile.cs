using AutoMapper;
using Ecology.DataAccess.Common.Models.Location;
using Ecology.Logic.Common.Models.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecology.Logic.Mappings.Location
{
  public  class WaterObjectProfile : Profile
    {
        public WaterObjectProfile()
        {
            CreateMap<WaterObjectBLL, WaterObjectDb>().ReverseMap();
            CreateMap<WaterObjectDb, WaterObjectBLL>();
        }
    }
}
