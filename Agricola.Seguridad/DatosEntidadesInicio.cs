using Agricola.Seguridad.Entidades;
using Agricola.Seguridad.Managers;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricola.Seguridad
{

    public static class DatosEntidadesInicio
    {
        public static void DefaultRoles(AgricolaRoleManager roleManager, List<AgricolaRoles> roleDataList = null)
        {
            roleDataList = roleDataList ?? new List<AgricolaRoles>();
            roleDataList.Add(new AgricolaRoles("Tester", "Testers", 0, "Usuario con fines de testing.", true));
            roleDataList.Add(new AgricolaRoles("Administrador Sistema", "Administradores de Sistema", 1,
                "Usuario maestro con mayor nivel de privilegios. Generados por el sistema.", true));
            roleDataList.Add(new AgricolaRoles("Administrador", "Administradores", 2,
                "Usuario con privilegios de administrador, puede crear otros usuarios."));
            int c = 1;
            foreach (var role in roleDataList)
                if (!roleManager.RoleExists(role.Name))
                {
                    role.FechaRegistro = DateTime.Now;
                    role.Orden = c++;
                    roleManager.Create(role);
                }
        }

        public static void DefaultUsers(AdministradorUsuariosAgricola userManager, List<AgricolaUser> userDataList = null)
        {
            userDataList = userDataList ?? new List<AgricolaUser>
            {
                new AgricolaUser {UserName = "test@agricola.com", Email = "test@agricola.com"}
            };

            foreach (var user in userDataList)
                if (userManager.FindByName(user.UserName) == null)
                {
                    var creation = userManager.Create(user, "test" + DateTime.Today.Year);
                    if (creation.Succeeded)
                        userManager.AddToRole(user.Id, "Tester");
                }

            var systemAdmin = new AgricolaUser
            {
                UserName = "system@agricola.com",
                Email = "system@agricola.com"
            };

            if (userManager.FindByName(systemAdmin.UserName) == null)
            {
                var creation = userManager.Create(systemAdmin, "6fpyKQshvQGF");
                if (creation.Succeeded)
                    userManager.AddToRole(systemAdmin.Id, "Administrador Sistema");
            }
        }
    }

   
}
