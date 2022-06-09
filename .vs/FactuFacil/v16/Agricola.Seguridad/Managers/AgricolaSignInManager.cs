using Agricola.Seguridad.Entidades;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Agricola.Seguridad.Managers
{
    public class AgricolaSignInManager : SignInManager<AgricolaUser, long>
    {
        public AgricolaSignInManager(AdministradorUsuariosAgricola userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(AgricolaUser user)
        {
            return UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
        }

        public static AgricolaSignInManager Create(IdentityFactoryOptions<AgricolaSignInManager> options,
            IOwinContext context)
        {
            return new AgricolaSignInManager(context.GetUserManager<AdministradorUsuariosAgricola>(), context.Authentication);
        }
    }

   
}
