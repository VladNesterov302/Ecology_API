using Ecology.DataAccess.Common.Models.Water;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecology.DataAccess.Common.Models.Location
{
   public class WaterObjectDb
    {
        public int Id { get; set; }
        public string WaterObject { get; set; }

        public virtual ICollection<BioOxygenDb> BioOxygens { get; set; }
        public virtual ICollection<ChemicalOxygenDb> ChemicalOxygens { get; set; }
        public virtual ICollection<PhDb> Phs { get; set; }
    }
}
