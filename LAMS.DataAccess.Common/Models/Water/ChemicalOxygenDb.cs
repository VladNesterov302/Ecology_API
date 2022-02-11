using Ecology.DataAccess.Common.Models.Location;
using Ecology.DataAccess.Common.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecology.DataAccess.Common.Models.Water
{
   public class ChemicalOxygenDb
    {
        public int Id { get; set; }

        public double Dose { get; set; }

        public string Level { get; set; }

        public int IdWaterObject { get; set; }

        public virtual WaterObjectDb WaterObject { get; set; }

        public string IdUser { get; set; }

        public virtual UserDb User { get; set; }

        public DateTime Date { get; set; }
    }
}
