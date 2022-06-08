using AgricolaData.ViewModel;
using ApoloCartera.Clases;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApoloCartera.Controllers
{
    public class DocumentoController : Controller
    {

        private Logger _logger = LogManager.GetLogger("AppDomainLog");
        private ApoloData.Context _context = new ApoloData.Context();
        private CombosClass CombosClass = new CombosClass();

        public DocumentoController()
        {
            _context = new ApoloData.Context();

        }


        public ActionResult Registrar()
        {

            string varUsuario = null;
            if (Session["_IdUsuario"] != null)
            {
                varUsuario = Session["_IdUsuario"].ToString();
            }

            long IdUsuario = 0;

            if (varUsuario == null)
            {

                return RedirectToAction("Login", "Seguridad", new { area = "" });
            }
            else
            {
                long.TryParse(varUsuario, out IdUsuario);
                var usuario = _context.Cat_Usuarios.FirstOrDefault(c => c.Activo && c.IdUsuario == IdUsuario);
                if (usuario != null)
                {

                }
            }

            ItemDocumentoViewModel model = new ItemDocumentoViewModel();

            ItemDetalleDocumentoViewModel itemdetalle1 = new ItemDetalleDocumentoViewModel();
            ItemDetalleDocumentoViewModel itemdetalle2 = new ItemDetalleDocumentoViewModel();

            model.FechaEmision = DateTime.Now;
            model.FechaVencimiento = DateTime.Now;

            itemdetalle1.IdProducto = 1;
            itemdetalle1.Cantidad = 1;
            itemdetalle1.Precio = 100;
            itemdetalle1.SubTotal = 100;
            itemdetalle1.Descuento = 0;
            itemdetalle1.NombreProducto = "Primer Producto";
            itemdetalle1.NombreUnidadMedida = "Unidad";

            itemdetalle2.IdProducto = 1;
            itemdetalle2.Cantidad = 1;
            itemdetalle2.Precio = 100;
            itemdetalle2.SubTotal = 100;
            itemdetalle2.Descuento = 0;
            itemdetalle2.NombreProducto = "Segundo Producto";
            itemdetalle2.NombreUnidadMedida = "Unidad";
            model.Detalle.Add(itemdetalle1);
            model.Detalle.Add(itemdetalle2);

            model.FechaEmision = DateTime.Now;
            
            ViewBag.IdEstablecimiento = CombosClass.ListarComboEstablecimiento();
            ViewBag.IdPuntoVenta = CombosClass.ListarComboPuntoVenta();
            ViewBag.IdTipoDocumento = CombosClass.ListarComboTipoDocumento();
            ViewBag.IdPersona = CombosClass.ListarComboPersonas();
            ViewBag.IdFormaPago = CombosClass.ListarComboFormaPago();
           

            return View(model);
        }

    }
}