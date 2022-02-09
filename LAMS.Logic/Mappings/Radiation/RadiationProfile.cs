using AutoMapper;
using Ecology.DataAccess.Common.Models.Radiation;
using Ecology.Logic.Common.Models.Radiation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecology.Logic.Mappings.Radiation
{
    public class RadiationProfile : Profile
    {
        public RadiationProfile()
        {
            CreateMap<RadiationBLL, RadiationDb>().ReverseMap();
            CreateMap<RadiationDb, RadiationBLL>();
        }
    }
}