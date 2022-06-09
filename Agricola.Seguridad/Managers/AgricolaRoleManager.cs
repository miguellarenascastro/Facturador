using Agricola.Seguridad.Entidades;
using Agricola.Seguridad.Stores;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricola.Seguridad.Managers
{
    public class AgricolaRoleManager : RoleManager<AgricolaRoles, long>
    {
        public AgricolaRoleManager(IRoleStore<AgricolaRoles, long> store) : base(store)
        {
        }

        public override IQueryable<AgricolaRoles> Roles
        {
            get { return base.Roles.Where(c => c.Activo).OrderBy(c => c.Prioridad).ThenBy(c => c.Orden); }
        }

        public IQueryable<AgricolaRoles> SystemRoles
        {
            get { return base.Roles.Where(c => c.Activo && c.Sistema).OrderBy(c => c.Prioridad).ThenBy(c => c.Orden); }
        }

        public IQueryable<AgricolaRoles> CustomRoles
        {
            get
            {
                return base.Roles.Where(c => c.Activo && c.Sistema == false).OrderBy(c => c.Prioridad)
                    .ThenBy(c => c.Orden);
            }
        }

        public IQueryable<AgricolaRoles> AvailableEditRoles(int prioridad)
        {
            return base.Roles.Where(c => c.Activo && c.Prioridad > prioridad).OrderBy(c => c.Prioridad).ThenBy(c => c.Orden);
        }

        public static AgricolaRoleManager Create(IdentityFactoryOptions<AgricolaRoleManager> options,
            IOwinContext context)
        {
            return new AgricolaRoleManager(new AgricolaRoleStore(context.Get<SeguridadDbContext>()));
        }
    }

   
}
