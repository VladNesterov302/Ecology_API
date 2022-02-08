using Ecology.DataAccess.Common.Models.Air;
using Ecology.DataAccess.Common.Models.Radiation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecology.DataAccess.Common.Models.Location
{
  public  class CityDb
    {
        public int Id { get; set; }
        public string City { get; set; }

        public virtual ICollection<RadiationDb> Radiations { get; set; }
        public virtual ICollection<PmDb> Pms { get; set; }
        public virtual ICollection<SeraDb> Seras { get; set; }
        public virtual ICollection<OzonDb> Ozons { get; set; }
        public virtual ICollection<AzotDb> Azots { get; set; }
    }
}
