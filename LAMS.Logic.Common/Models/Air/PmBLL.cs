using Ecology.Logic.Common.Models.Location;
using Ecology.Logic.Common.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecology.Logic.Common.Models.Air
{
    public class PmBLL
    {
        public int Id { get; set; }

        public double Dose { get; set; }

        public int Level { get; set; }

        public double Dose10 { get; set; }

        public int Level10 { get; set; }

        public int IdCity { get; set; }

        public virtual CityBLL City { get; set; }

        public string IdUser { get; set; }

        public virtual UserShort User { get; set; }

        public DateTime Date { get; set; }
    }
}
