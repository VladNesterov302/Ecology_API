using AutoMapper;
using Ecology.DataAccess.Common.DTO;
using Ecology.Logic.Common.Models.Statistic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecology.Logic.Mappings.Statistic
{
    public class RadiationStatisticProfile : Profile
    {
        public RadiationStatisticProfile()
        {
            CreateMap<LevelRadiationStatisticBLL, LevelRadiationStatisticDTO>().ReverseMap();
            CreateMap<LevelRadiationStatisticDTO, LevelRadiationStatisticBLL>();
        }
    }
}
