using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricola.Seguridad.Entidades
{
    public class AgricolaUser : IdentityUser<long, AgricolaUserLogin, AgricolaUserRole, AgricolaUserClaims>
    {
        public AgricolaUser()
        {
            FechaRegistro = DateTime.Now;
            Activo = true;
        }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Identificacion { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaActivacion { get; set; }
        public DateTime? FechaDesactivacion { get; set; }
        public DateTime? FechaExpiracion { get; set; }
        public DateTime? FechaModificacion { get; set; }

    }
    public class AgricolaUserRole : IdentityUserRole<long>
    {
        public AgricolaUserRole()
        {
            Activo = true;
            FechaRegistro = DateTime.Now;
        }
        public bool Activo { get; set; }
        public bool Primario { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public DateTime? FechaEliminacion { get; set; }
    }

    public class AgricolaUserClaims : IdentityUserClaim<long>
    {
    }

    public class AgricolaUserLogin : IdentityUserLogin<long>
    {
    }
}
