using Ecology.DataAccess.Common.Models.Radiation;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecology.DataAccess.ModelConfigurations.Radiation
{
    public class RadiationConfiguration : EntityTypeConfiguration<RadiationDb>
    {
        public RadiationConfiguration()
        {
            ToTable("Radiation");

            HasKey(x => x.Id);

            HasRequired(m => m.User)
               .WithMany(t => t.Radiations)
               .HasForeignKey(m => m.IdUser)
               .WillCascadeOnDelete(false);

            HasRequired(m => m.City)
                .WithMany(t => t.Radiations)
                .HasForeignKey(m => m.IdCity)
                .WillCascadeOnDelete(false);

        }
    }
}
