using Ecology.DataAccess.Common.Models.Location;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecology.DataAccess.ModelConfigurations.Location
{
   public class CityConfiguration : EntityTypeConfiguration<CityDb>
    {
        public CityConfiguration()
        {
            ToTable("City");

            HasKey(x => x.Id);

            Property(c => c.City).IsRequired();
        }
    }
}
