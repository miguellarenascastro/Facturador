using AgricolaData.Configuration;
using AgricolaData.Entities;
using AgricolaMVC.Controllers;
using System.Web;
using System.Web.Mvc;

namespace AgricolaMVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new AuthorizeAttribute());

        }


    }

    //public class VerificaSession : ActionFilterAttribute
    //{
    //    private Usuarios oUsuario;
    //    public override void OnActionExecuted(ActionExecutedContext filterContext)
    //    {
    //        try
    //        {
    //            base.OnActionExecuted(filterContext);
    //            oUsuario = (Usuarios)HttpContext.Current.Session["User"];
    //            if(oUsuario == null)
    //            {
    //                if(filterContext.Controller is SeguridadController == false)
    //                {
    //                    filterContext.HttpContext.Response.Redirect("/Seguridad/Login");
    //                }

    //            }
    //        }
    //        catch (System.Exception)
    //        {

    //            throw;
    //        }
    //        base.OnActionExecuted(filterContext);
    //    }

    //}
}
