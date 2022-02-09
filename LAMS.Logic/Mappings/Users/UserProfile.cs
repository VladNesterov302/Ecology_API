using AutoMapper;
using Ecology.DataAccess.Common.Models.Users;
using Ecology.Logic.Common.Models.Users;

namespace Ecology.Logic.Mappings.Users
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDb>().ReverseMap();
            CreateMap<UserDb, User>();      
            CreateMap<UserShort, UserDb>().ReverseMap();
            CreateMap<UserDb, UserShort>();
        }
    }
}
