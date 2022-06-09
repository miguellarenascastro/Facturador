using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgricolaMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            var IdUsuario = Session["_IdUsuario"];
            if (IdUsuario == null)
            {
                return RedirectToAction("Login", "Seguridad", new { area = "" });
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult Configuraciones()
        {

            Session["_OpcionMenu"] = "CONFIGURACION";

            var IdUsuario = Session["_IdUsuario"];
            if (IdUsuario == null)
            {
                return RedirectToAction("Login", "Seguridad", new { area = "" });
            }

            return View();
        }
    }
}