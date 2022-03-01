using AutoMapper;
using Ecology.DataAccess.Common.DTO;
using Ecology.Logic.Common.Models.Air;
using Ecology.Logic.Common.Models.Water;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecology.Logic.Mappings.Statistic
{
    public class LevelStatisticProfile : Profile
    {
        public LevelStatisticProfile()
        {
            CreateMap<AzotBLL, LevelStatisticDTO>().ReverseMap();
            CreateMap<LevelStatisticDTO, AzotBLL>();

            CreateMap<OzonBLL, LevelStatisticDTO>().ReverseMap();
            CreateMap<LevelStatisticDTO, OzonBLL>();

            CreateMap<PmBLL, LevelStatisticDTO>().ReverseMap();
            CreateMap<LevelStatisticDTO, PmBLL>();

            CreateMap<SeraBLL, LevelStatisticDTO>().ReverseMap();
            CreateMap<LevelStatisticDTO, SeraBLL>();

            CreateMap<BioOxygenBLL, LevelStatisticDTO>().ReverseMap();
            CreateMap<LevelStatisticDTO, BioOxygenBLL>();

            CreateMap<ChemicalOxygenBLL, LevelStatisticDTO>().ReverseMap();
            CreateMap<LevelStatisticDTO, ChemicalOxygenBLL>();

            CreateMap<PhBLL, LevelStatisticDTO>().ReverseMap();
            CreateMap<LevelStatisticDTO, PhBLL>();
        }
    }
}
