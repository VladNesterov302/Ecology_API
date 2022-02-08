using Ecology.DataAccess.Common.Models.Air;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecology.DataAccess.ModelConfigurations.Air
{
   public class OzonConfiguration : EntityTypeConfiguration<OzonDb>
    {
        public OzonConfiguration()
        {
            ToTable("Ozon");

            HasKey(x => x.Id);

            HasRequired(m => m.User)
               .WithMany(t => t.Ozons)
               .HasForeignKey(m => m.IdUser)
               .WillCascadeOnDelete(false);

            HasRequired(m => m.City)
                .WithMany(t => t.Ozons)
                .HasForeignKey(m => m.IdCity)
                .WillCascadeOnDelete(false);

        }
    }
}