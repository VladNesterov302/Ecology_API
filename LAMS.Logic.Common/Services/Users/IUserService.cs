using Ecology.Logic.Common.Models.Users;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Ecology.Logic.Common.Services.Users
{
    public interface IUserService : IDisposable
    {
        Task<User> SignIn(string userName, string password);
        Task<User> GetUserInfo(string userName);
        Task<User> DelUser(string Id);


        Task<IEnumerable<User>> GetUsers();

        Task<string> Block(string id);
        Task<string> Unblock(string id);
    }
}
