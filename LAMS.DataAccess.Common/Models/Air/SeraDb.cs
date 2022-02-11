using Ecology.DataAccess.Common.Models.Location;
using Ecology.DataAccess.Common.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecology.DataAccess.Common.Models.Air
{
    public class SeraDb
    {
        public int Id { get; set; }

        public double Dose { get; set; }

        public string Level { get; set; }

        public int IdCity { get; set; }

        public virtual CityDb City { get; set; }

        public string IdUser { get; set; }

        public virtual UserDb User { get; set; }

        public DateTime Date { get; set; }
    }
}
