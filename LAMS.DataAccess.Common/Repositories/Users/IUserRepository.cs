using Ecology.DataAccess.Common.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Ecology.DataAccess.Common.Repositories.Users
{
    /// <summary>
    /// Provides a standart DAL methods to work with users.
    /// </summary>
    public interface IUserRepository : IDisposable
    {
        Task<UserDb> SignIn(string userName, string password);

        Task<bool> IsUserNameAvailable(string userName);

        Task<UserDb> GetUserInfo(string userName);
        Task<UserDb> DelUser(string Id);

        Task<IEnumerable<UserDb>> GetUsers();

        Task<string> Registration(UserDb user);

        Task<string> Block(string id);
        Task<string> Unblock(string id);
    }
}
