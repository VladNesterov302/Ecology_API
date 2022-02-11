using Ecology.Logic.Common.Models.Location;
using Ecology.Logic.Common.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecology.Logic.Common.Models.Water
{
    public class BioOxygenBLL
    {

        public int Id { get; set; }

        public double Dose { get; set; }

        public string Level { get; set; }

        public int IdWaterObject { get; set; }

        public virtual WaterObjectBLL WaterObject { get; set; }

        public string IdUser { get; set; }

        public virtual UserShort User { get; set; }

        public DateTime Date { get; set; }
    }
}
