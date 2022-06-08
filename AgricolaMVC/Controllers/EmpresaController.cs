using AgricolaData.Entities;
using AgricolaData.ViewModel;
using ApoloCartera.Clases;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApoloCartera.Controllers
{
    public class EmpresaController : Controller
    {

        private Logger _logger = LogManager.GetLogger("AppDomainLog");
        private ApoloData.Context _context = new ApoloData.Context();
        private CombosClass CombosClass = new CombosClass();

        public EmpresaController()
        {
            _context = new ApoloData.Context();

        }


        public ActionResult ListarEmpresas()
        {
            ListarEmpresaViewModel model = new ListarEmpresaViewModel();
            #region Sesion
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
                    var data = _context.Empresas.Where(c => c.Activo == true).ToList();

                    if (data != null)
                    {
                        model.Empresas = data.Select(c => new ItemEmpresaViewModel
                        {
                            IdEmpresa = c.IdEmpresa,
                            ciaRUC = c.Ruc,
                            ciaNombreComercial = c.NombreComercial,
                            ciaDireccion = c.Direccion,
                            IdGrupoProductor = c.IdGrupoProductor,
                 
                        }).ToList();
                    }
                }
            }
            #endregion

            return View(model);

        }


        public ActionResult RegistrarEmpresa()
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

            ItemEmpresaViewModel model = new ItemEmpresaViewModel();

          
            return View(model);
        }

        [HttpPost]
        public ActionResult RegistrarEmpresa(ItemEmpresaViewModel modelo)
        {
            try
            {
                string varUsuario = null;
                if (Session["_UserName"] != null)
                {
                    varUsuario = Session["_UserName"].ToString();
                }

                Empresa registro = new Empresa();

                registro.Ruc = modelo.ciaRUC;
                registro.NombreComercial = modelo.ciaNombreComercial;
                registro.RazonSocial = modelo.ciaRazonSocial;
                registro.Direccion = modelo.ciaDireccion;
                registro.IdGrupoProductor = modelo.IdGrupoProductor;

                registro.Activo = true;
                registro.UsuarioCreacion = varUsuario;
                registro.FechaCreacion = DateTime.Now;

                _context.Empresas.Add(registro);
                _context.SaveChanges();

                TempData["MensajeExito"] = "Se registro correctamente la Empresa.";
            }
            catch (Exception e)
            {
          
                TempData["MensajeError"] = "Error al Registrar la Empresa.";
                throw;
            }

            return RedirectToAction("ListarEmpresas");
        }

        public ActionResult EditarEmpresa(long IdEmpresa)
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

            ItemEmpresaViewModel model = new ItemEmpresaViewModel();

            var itemdata = _context.Empresas.FirstOrDefault(c => c.Activo && c.IdEmpresa == IdEmpresa);

            if (itemdata != null)
            {
                model.IdEmpresa = itemdata.IdEmpresa;
                model.ciaRUC = itemdata.Ruc;
                model.ciaNombreComercial = itemdata.NombreComercial;
                model.ciaRazonSocial = itemdata.RazonSocial;
                model.ciaDireccion = itemdata.Direccion;
                model.IdGrupoProductor = itemdata.IdGrupoProductor;
            }

      
            return View(model);
        }

        [HttpPost]
        public ActionResult EditarEmpresa(ItemEmpresaViewModel modelo)
        {
            try
            {
                string varUsuario = null;
                if (Session["_UserName"] != null)
                {
                    varUsuario = Session["_UserName"].ToString();
                }

                Empresa registro = _context.Empresas.FirstOrDefault(c => c.Activo && c.IdEmpresa == modelo.IdEmpresa);




                registro.Ruc = modelo.ciaRUC;
                registro.NombreComercial = modelo.ciaNombreComercial;
                registro.RazonSocial = modelo.ciaRazonSocial;
                registro.Direccion = modelo.ciaDireccion;
                registro.IdGrupoProductor = modelo.IdGrupoProductor;
               


                registro.Activo = true;
                registro.UsuarioModificacion = varUsuario;
                registro.FechaModificacion = DateTime.Now;


                _context.SaveChanges();


                TempData["MensajeExito"] = "Se actualizo correctamente la Empresa.";
            }
            catch (Exception e)
            {
                TempData["MensajeError"] = "Error al actualizar la Empresa.";
                throw;
            }

            return RedirectToAction("ListarEmpresas");


        }

        public ActionResult EliminarEmpresa(long IdEmpresa)
        {
            try
            {
                string varUsuario = null;
                if (Session["_UserName"] != null)
                {
                    varUsuario = Session["_UserName"].ToString();
                }

                var registro = _context.Empresas.Find(IdEmpresa);
                registro.Activo = false;
                registro.FechaEliminacion = DateTime.Now;
                registro.UsuarioEliminacion = varUsuario;
                _context.SaveChanges();

                TempData["MensajeExito"] = "Se elimino correctamente la Empresa.";
                return RedirectToAction("ListarEmpresas");
            }
            catch (Exception)
            {
                TempData["MensajeExito"] = "Error al eliminar la Empresa.";
                return RedirectToAction("ListarEmpresas");

            }

        }


    }
}