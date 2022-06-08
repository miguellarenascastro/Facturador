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
    public class AgricolaRoleStore : RoleStore<AgricolaRoles, long, AgricolaUserRole>
    {
        public AgricolaRoleStore(DbContext context) : base(context)
        {
        }
    }

}
