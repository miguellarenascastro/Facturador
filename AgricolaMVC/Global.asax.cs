using Agricola.Seguridad;
using Agricola.Seguridad.Entidades;
using Agricola.Seguridad.Managers;
using Agricola.Seguridad.Stores;
using AgricolaMVC.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AgricolaMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private NLog.Logger appDomainLog = NLog.LogManager.GetLogger("AppDomainLog");

        protected void Application_Start()
        {

            //int temp = 0;
            //HttpContext.Current.Session.Add("_IdUsuario", temp);


            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            HangFireService.Instance.Start();

            var context = new SeguridadDbContext();
            var applicationRoles = new List<AgricolaRoles>
            {
                new AgricolaRoles("Moderador", "Moderadores", 4),
            };
            DatosEntidadesInicio.DefaultRoles(new AgricolaRoleManager(new AgricolaRoleStore(context)), applicationRoles);
            DatosEntidadesInicio.DefaultUsers(new AdministradorUsuariosAgricola(new AgricolaUserStore(context)));
            context.Dispose();
        }
        //protected void Application_Error(object sender, EventArgs e)
        //{
        //    Exception exception = Server.GetLastError();
        //    if (exception != null)
        //    {
        //        appLog.Error($"Excepcion MVC Origen: {exception.Source}\n Mensaje: {exception.Message} \n StackTrace: \n{exception.Source}\n");
        //    }
        //}

        //protected void Application_End(object sender, EventArgs e)
        //{
        //    appLog.Info("Finalizacion de aplicacion");
        //}
    }
}
