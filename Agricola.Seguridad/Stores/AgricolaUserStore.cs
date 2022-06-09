using Agricola.Seguridad.Entidades;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricola.Seguridad.Stores
{
    public class AgricolaUserStore : UserStore<AgricolaUser, AgricolaRoles, long, AgricolaUserLogin,
         AgricolaUserRole, AgricolaUserClaims>
    {
        public AgricolaUserStore(DbContext context) : base(context)
        {

        }

        public IQueryable<AgricolaUser> GetUsersInRole(AgricolaRoles role)
        {
            return Users.Where(c => c.Roles.Any(r => r.RoleId == role.Id && r.Activo));
        }
    }
}
