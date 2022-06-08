using Agricola.Seguridad.Entidades;
using Agricola.Seguridad.Managers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.Cookies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricola.Seguridad.Providers
{
    public class AgricolaCookieAuthenticationProvider : CookieAuthenticationProvider
    {
        public AgricolaCookieAuthenticationProvider() : base()
        {
            OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<AdministradorUsuariosAgricola, AgricolaUser, long>
            (
                validateInterval: TimeSpan.FromMinutes(30),
                regenerateIdentityCallback: (AdministradorUsuariosAgricola, agricolaUser) => AdministradorUsuariosAgricola.AuthenticateUserAsync(agricolaUser, DefaultAuthenticationTypes.ApplicationCookie),
                getUserIdCallback: id => id.GetUserId<long>()
            );

            OnResponseSignIn = context =>
            {
                // Acciones en login
            };

            OnResponseSignOut = context =>
            {
                // Acciones en logout
            };
        }
    }

  
}
