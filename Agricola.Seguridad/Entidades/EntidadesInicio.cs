using Agricola.Seguridad.Managers;
using Agricola.Seguridad.Providers;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;


namespace Agricola.Seguridad.Entidades
{
    /// <summary>
    /// Inicializacion de ASP Identity basado OWIN Startup Class routine.
    /// Configura <see cref="OAuthAuthorizationServerOptions"/> para Web Api Mvc. 
    /// Configura <see cref="CookieAuthenticationOptions"/> para Web Mvc.
    /// </summary>
    public static class EntidadesInicio
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public static string PublicClientId { get; private set; }

        /// <summary>
        /// Funcion a llamarse en Startup.cs para configurar arranque OWIN.
        /// Referencia oficial: <see cref="http://go.microsoft.com/fwlink/?LinkId=301864"/> 
        /// </summary>
        /// <param name="app">OWIN Compliant Mvc App</param>
        public static void ConfigureAuth(IAppBuilder app)
        {
//            // Configure the db context and user manager to use a single instance per request
//            app.CreatePerOwinContext(SeguridadDbContext.Create);
//            app.CreatePerOwinContext<AdministradorUsuariosAgricola>(AdministradorUsuariosAgricola.Create);
//            app.CreatePerOwinContext<AgricolaSignInManager>(AgricolaSignInManager.Create);
//            app.CreatePerOwinContext<AgricolaRoleManager>(AgricolaRoleManager.Create);

//            var CookieAuthenticationOptions = new CookieAuthenticationOptions
//            {
//                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
//                LoginPath = new PathString("/Seguridad/Login"),
//                Provider = new AgricolaCookieAuthenticationProvider(),
//                ExpireTimeSpan = TimeSpan.FromHours(4),
//                CookieName = "AgricolaIdentity",
//#if DEBUG
//                CookieDomain = "localhost"
//#else
//                CookieDomain = ".com"
//#endif
//            };

//            // Enable the application to use a cookie to store information for the signed in user
//            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
//            app.UseCookieAuthentication(CookieAuthenticationOptions);
//            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

//            // Configure the application for OAuth based flow
//            PublicClientId = "self";
//            OAuthOptions = new OAuthAuthorizationServerOptions
//            {
//                TokenEndpointPath = new PathString("/Token"),
//                Provider = new OAuthServerProvider(PublicClientId),
//                AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
//                AccessTokenExpireTimeSpan = TimeSpan.FromDays(30),
//                // In production mode set AllowInsecureHttp = false
//                AllowInsecureHttp = true
//            };

//            // Enable the application to use bearer tokens to authenticate users
//            app.UseOAuthBearerTokens(OAuthOptions);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //    consumerKey: "",
            //    consumerSecret: "");

            //app.UseFacebookAuthentication(
            //    appId: "",
            //    appSecret: "");

            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            //{
            //    ClientId = "",
            //    ClientSecret = ""
            //});
        }
    }
}
