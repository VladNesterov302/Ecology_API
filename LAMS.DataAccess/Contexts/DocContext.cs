
using Ecology.DataAccess.Common.Models.Users;
using Ecology.DataAccess.ModelConfigurations.Auth;
using System.Collections.Generic;
using System.Data.Entity;

namespace Ecology.DataAccess.Contexts
{
 
    public class DocContext : DbContext
    {
        public DocContext() : base("EcologyConnection") { }
        public DocContext(string connectionString) : base(connectionString) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());

        }
        public IDbSet<UserDb> Users { get; set; }

        public IDbSet<RoleDb> Roles { get; set; }
  
    }
}
