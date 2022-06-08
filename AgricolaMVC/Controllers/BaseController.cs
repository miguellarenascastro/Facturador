using AgricolaData.Entities;
using AgricolaData.ViewModel;
using ExcelDataReader;
using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApoloCartera.Controllers
{
    public class BaseController : Controller
    {

        private Logger _logger = LogManager.GetLogger("AppDomainLog");
        ApoloData.Context _context = new ApoloData.Context();
    

        public BaseController()
        {
            _context = new ApoloData.Context();

        }


       
        //public ActionResult Registrar()
        //{

        //    string varUsuario = null;
        //    ListarArchivoExportacionViewModel Model = new ListarArchivoExportacionViewModel();

        //    if (Session["_IdUsuario"] != null)
        //    {
        //        varUsuario = Session["_IdUsuario"].ToString();
        //    }

        //    long IdUsuario = 0;
        //    //string nombreHacienda = "";
        //    //long IdHacienda = 0;
        //    if (varUsuario == null)
        //    {

        //        return RedirectToAction("Login", "Seguridad", new { area = "" });
        //    }
        //    else
        //    {
        //        long.TryParse(varUsuario, out IdUsuario);
        //        var usuario = _context.Cat_Usuarios.FirstOrDefault(c => c.Activo && c.IdUsuario == IdUsuario);
        //        if (usuario != null)
        //        {
        //            //var hacienda = _context.Haciendas.FirstOrDefault(c => c.Activo && c.Nombre == usuario.NombreHacienda);

        //            //IdHacienda = hacienda?.IdHacienda ?? 0;
        //            //nombreHacienda = hacienda?.Nombre ?? "";
        //        }

        //    }


        //    return View(Model);
        //}

    
    }
}