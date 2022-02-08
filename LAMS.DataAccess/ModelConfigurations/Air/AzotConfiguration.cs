using Ecology.DataAccess.Common.Models.Air;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecology.DataAccess.ModelConfigurations.Air
{
   public class AzotConfiguration : EntityTypeConfiguration<AzotDb>
    {
        public AzotConfiguration()
        {
            ToTable("Azot");

            HasKey(x => x.Id);

            HasRequired(m => m.User)
               .WithMany(t => t.Azots)
               .HasForeignKey(m => m.IdUser)
               .WillCascadeOnDelete(false);

            HasRequired(m => m.City)
                .WithMany(t => t.Azots)
                .HasForeignKey(m => m.IdCity)
                .WillCascadeOnDelete(false);

        }
    }
}
