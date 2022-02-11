using Ecology.DataAccess.Common.Models.Water;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecology.DataAccess.ModelConfigurations.Water
{
    public class ChemicalOxygenConfiguration : EntityTypeConfiguration<ChemicalOxygenDb>
    {
        public ChemicalOxygenConfiguration()
        {
            ToTable("ChemicalOxygen");

            HasKey(x => x.Id);

            HasRequired(m => m.User)
               .WithMany(t => t.ChemicalOxygens)
               .HasForeignKey(m => m.IdUser)
               .WillCascadeOnDelete(false);

            HasRequired(m => m.WaterObject)
                .WithMany(t => t.ChemicalOxygens)
                .HasForeignKey(m => m.IdWaterObject)
                .WillCascadeOnDelete(false);

        }
    }
}