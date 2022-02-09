using Ecology.DataAccess.Common.Models.Users;
using Ecology.DataAccess.Common.Repositories.Users;
using Ecology.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Ecology.DataAccess.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly DocContext _context;


        private bool _disposed;

        public UserRepository(DocContext context) => _context = context;

        public void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
                GC.SuppressFinalize(this);
            }
        }
  
        public async Task<UserDb> DelUser(string Id)
        {
            UserDb user = await _context.Users.FirstOrDefaultAsync(p => p.Id == Id).ConfigureAwait(false);

            var result = _context.Users.Remove(user);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return result;
        }

        public async Task<UserDb> SignIn(string userName, string password)
        {
            return await _context.Users.Where(p =>
                                    p.UserName == userName && p.Password == password && p.Status == "Активен"
                                    ).FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public async Task<bool> IsUserNameAvailable(string userName)
        {
            return !(await _context.Users.AnyAsync(u => u.UserName == userName).ConfigureAwait(false));
        }

        public async Task<UserDb> GetUserInfo(string userName)
        {
            return await _context.Users.Where(p =>
                                    p.UserName == userName).FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public async Task<string> Registration(UserDb user)
        {
            user.Id = Guid.NewGuid().ToString();
            user.Created = DateTime.UtcNow;
            user.RoleId = "f4c9fe7b-1e77-4e67-8800-1d33948b22a1";
            user.Status = "Активен";
            _context.Users.Add(user);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return user.Id;
        }

        public async Task<IEnumerable<UserDb>> GetUsers()
        {
            return await _context.Users.Include(r=>r.Role).Where(o =>
                o.RoleId != "2d314154-6b40-47d7-a277-385e17b114c0"
            ).ToListAsync().ConfigureAwait(false);
        }
        public async Task<string> Block(string id)
        {
            var info = await _context.Users.FirstOrDefaultAsync(p => p.Id == id).ConfigureAwait(false);
            info.Status = "Заблокирован";

            var entry = _context.Entry(info);
            entry.CurrentValues.SetValues(info);
            entry.Property(p => p.Status).IsModified = true;
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return info.Id;

        }
        public async Task<string> Unblock(string id)
        {
            var info = await _context.Users.FirstOrDefaultAsync(p => p.Id == id).ConfigureAwait(false);
            info.Status = "Активен";

            var entry = _context.Entry(info);
            entry.CurrentValues.SetValues(info);
            entry.Property(p => p.Status).IsModified = true;
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return info.Id;
        }
        ~UserRepository()
        {
            Dispose();
        }
    }
}
