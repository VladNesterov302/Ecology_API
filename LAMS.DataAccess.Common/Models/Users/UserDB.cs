
using Ecology.DataAccess.Common.Models.Air;
using Ecology.DataAccess.Common.Models.Radiation;
using Ecology.DataAccess.Common.Models.Water;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecology.DataAccess.Common.Models.Users
{
    /// <summary>
    /// DataBase entity of user.
    /// </summary>
    public class UserDb
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime Created { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string UserName { get; set; }
        public string Status { get; set; }

        public string RoleId { get; set; }
        public virtual RoleDb Role { get; set; }

        public virtual ICollection<RadiationDb> Radiations { get; set; }
        public virtual ICollection<PmDb> Pms { get; set; }
        public virtual ICollection<SeraDb> Seras { get; set; }
        public virtual ICollection<OzonDb> Ozons { get; set; }
        public virtual ICollection<AzotDb> Azots { get; set; }
        public virtual ICollection<BioOxygenDb> BioOxygens { get; set; }
        public virtual ICollection<ChemicalOxygenDb> ChemicalOxygens { get; set; }
        public virtual ICollection<PhDb> Phs { get; set; }
    }
}
