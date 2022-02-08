
using Ecology.DataAccess.Common.Models.Air;
using Ecology.DataAccess.Common.Models.Location;
using Ecology.DataAccess.Common.Models.Radiation;
using Ecology.DataAccess.Common.Models.Users;
using Ecology.DataAccess.ModelConfigurations.Air;
using Ecology.DataAccess.ModelConfigurations.Auth;
using Ecology.DataAccess.ModelConfigurations.Location;
using Ecology.DataAccess.ModelConfigurations.Radiation;
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
            modelBuilder.Configurations.Add(new RadiationConfiguration());
            modelBuilder.Configurations.Add(new CityConfiguration());
            modelBuilder.Configurations.Add(new WaterObjectConfiguration());
            modelBuilder.Configurations.Add(new PmConfiguration());
            modelBuilder.Configurations.Add(new SeraConfiguration());
            modelBuilder.Configurations.Add(new AzotConfiguration());
            modelBuilder.Configurations.Add(new OzonConfiguration());

        }
        public IDbSet<UserDb> Users { get; set; }

        public IDbSet<RoleDb> Roles { get; set; }
        public IDbSet<RadiationDb> Radiations { get; set; }
        public IDbSet<CityDb> Cities { get; set; }
        public IDbSet<WaterObjectDb> WaterObjects { get; set; }
        public IDbSet<PmDb> Pms { get; set; }
        public IDbSet<SeraDb> Seras { get; set; }
        public IDbSet<AzotDb> Azots { get; set; }
        public IDbSet<OzonDb> Ozons { get; set; }
  
    }
}
