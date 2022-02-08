using Ecology.DataAccess.Common.Models.Air;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecology.DataAccess.ModelConfigurations.Air
{
    public class PmConfiguration : EntityTypeConfiguration<PmDb>
    {
        public PmConfiguration()
        {
            ToTable("Pm");

            HasKey(x => x.Id);

            HasRequired(m => m.User)
               .WithMany(t => t.Pms)
               .HasForeignKey(m => m.IdUser)
               .WillCascadeOnDelete(false);

            HasRequired(m => m.City)
                .WithMany(t => t.Pms)
                .HasForeignKey(m => m.IdCity)
                .WillCascadeOnDelete(false);

        }
    }
}
