using System;
using System.Threading.Tasks;
using Agricola.Seguridad.Entidades;
using System.Web;
using AgricolaMVC.Security;
using Hangfire;
using Hangfire.Dashboard;
using Microsoft.Owin;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(AgricolaMVC.Startup))]

namespace AgricolaMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            EntidadesInicio.ConfigureAuth(app);
            Hangfire.GlobalConfiguration.Configuration.UseSqlServerStorage("DefaultConnection");

            app.UseHangfireServer();

            app.UseHangfireDashboard("/hangfire", new DashboardOptions
            {
                Authorization = new[] { new AgricolaHangfireAuthorizationFilter("Administrador Sistema", "Tester") }
            });
            // Para obtener más información sobre cómo configurar la aplicación, visite https://go.microsoft.com/fwlink/?LinkID=316888
        }
        public class AgricolaHangfireAuthorizationFilter : IDashboardAuthorizationFilter
        {
            public string[] AllowedRoles { get; set; }

            /// <summary>
            /// Indica que Roles pueden ingresar al Dashboard de Hangfire
            /// </summary>
            /// <param name="allowedRoles">Nombres de los roles autorizados</param>
            public AgricolaHangfireAuthorizationFilter(params string[] allowedRoles)
            {
                AllowedRoles = allowedRoles;
            }

            public bool Authorize(DashboardContext context)
            {
                var appContext = HttpContext.Current;
                if (appContext.User.Identity.IsAuthenticated)
                {
                    foreach (var role in AllowedRoles)
                    {
                        if (appContext.User.IsInRole(role))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }

    }
}
