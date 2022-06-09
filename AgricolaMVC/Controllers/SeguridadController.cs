using Agricola.Seguridad.Entidades;
using Agricola.Seguridad.Managers;
using AgricolaData.Entities;

using AgricolaData.ViewModel;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Extensions.Logging;
using Microsoft.Owin.Security;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


using System.Web.Optimization;
using System.Web.Routing;

namespace AgricolaMVC.Controllers
{
    public class SeguridadController : Controller
    {


        private Logger _logger = LogManager.GetLogger("AppDomainLog");

        protected AgricolaSignInManager _signInManager;
        protected AdministradorUsuariosAgricola _userManager;
        protected AgricolaRoleManager _roleManager;
        protected ApoloData.Context _context = new ApoloData.Context();
     
        //protected SpUsuarioDomus spUsuarioDomus = new SpUsuarioDomus();

        public SeguridadController()
        {
        }
        public SeguridadController(AdministradorUsuariosAgricola userManager, AgricolaSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }
        public AgricolaSignInManager SignInManager
        {
            get => _signInManager ?? HttpContext.GetOwinContext().Get<AgricolaSignInManager>();
            private set => _signInManager = value;
        }
        public AdministradorUsuariosAgricola UserManager
        {
            get => _userManager ?? HttpContext.GetOwinContext().GetUserManager<AdministradorUsuariosAgricola>();
            private set => _userManager = value;
        }
        public AgricolaRoleManager RoleManager
        {
            get => _roleManager ?? HttpContext.GetOwinContext().GetUserManager<AgricolaRoleManager>();
            private set => _roleManager = value;
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            LoginViewModel model = new LoginViewModel();
          
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, change to shouldLockout: true
                //var result =
                //    await SignInManager.PasswordSignInAsync(model.usuario, model.clave, model.RememberMe, false);

                //var clave = SeguridadClass.Encriptar(model.clave);

                var us = _context.Cat_Usuarios.FirstOrDefault(x => x.Username == model.usuario && x.Clave == model.clave);
                //var us = spUsuarioDomus.SP_CARGAR_USUARIO(model.usuario, model.clave);
                //if(us.IdTaller != null)
                //{
                //    User.Identity.GetTallerId(us.IdTaller);
                //}
              
                if (us != null)
                {
                    

                    Session["_IdUsuario"] = us.IdUsuario;
                    Session["_UserName"] = us.Username;
                    return RedirectToLocal(returnUrl);

               //     if (model.IdEmpresa > 0 && empresasusuario != null && empresasusuario.IdUsuario == us.IdUsuario)
               //     {
               //         Session["_IdEmpresa"] = model.IdEmpresa;
               //         Session["_EmpresaNombre"] = empresasusuario.Empresa.ciaCodigo + " " + empresasusuario.Empresa.ciaNombreComercial;
               //;
               //     }
               //     else
               //     {
               //         ViewBag.IdEmpresa = classCombos.ListarComboEmpresa();
               //         ModelState.AddModelError("", "Empresa no válidas");
               //         return View(model);
               //     }
                 
                }
                else
                {
                   
                    ModelState.AddModelError("", "Credenciales no válidas");
                    return View(model);
                }
                //switch (result)
                //{
                //    case SignInStatus.Success:
                //        return RedirectToLocal(returnUrl);
                //    case SignInStatus.LockedOut:
                //        return View("Lockout");
                //    case SignInStatus.RequiresVerification:
                //        return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, model.RememberMe });
                //    case SignInStatus.Failure:
                //    default:
                //        ModelState.AddModelError("", "Credenciales no válidas");
                //        return View(model);
                //}
            }
            catch (Exception e)
            {

                _logger.Error(e.Message);
            }

            return View(model);
        }
        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            return RedirectToAction("Index", "Home", new { area = "" });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            Session["_IdUsuario"] = null;
            Session["_UserName"] = null;
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login", "Seguridad");
        }

        public ActionResult ListarUsuarios()
        {
            //ListarEmpleadosViewModel model = new ListarEmpleadosViewModel();

            ListarUsuariosViewModel model = new ListarUsuariosViewModel();
            var lista = _context.Cat_Usuarios.Where(c => c.Activo).ToList();

            if (lista != null)
            {
                foreach (var item in lista)
                {
                    Usuarios itemLista = new Usuarios();
                    itemLista.IdUsuario = item.IdUsuario;
                    itemLista.Nombres = item.Nombres;
                    itemLista.Apellidos = item.Apellidos;
                    itemLista.Username = item.Username;
                    itemLista.Apellidos = item.Apellidos;
                    itemLista.Identificacion = item.Identificacion;


                    model.Usuarios.Add(itemLista);
                }
            }


            return View(model);
        }

        public ActionResult EditarUsuario(long IdUsuario)
        {
            UsuarioViewModel model = new UsuarioViewModel();

            // var empleado = _context.Users.FirstOrDefault(c => c.Activo && c.Id == IdUsuario);
            var empleado = _context.Cat_Usuarios.FirstOrDefault(c => c.Activo && c.IdUsuario == IdUsuario);

            if (empleado == null)
            {
                return HttpNotFound();
            }
            var clave = "";
            //if (empleado.Clave != "")
            //{
            //    SeguridadClass.DesEncriptar(empleado.Clave);
            //}


            model.IdUsuario = empleado.IdUsuario;
            model.Nombres = empleado.Nombres;
            model.Apellidos = empleado.Apellidos;
            model.UserName = empleado.Username;
            model.Identificacio = empleado.Identificacion;
            model.Clave = clave;


            return View(model);
        }
        public ActionResult RegistrarUsuario()
        {

            string varUsuario = null;
            if (Session["_IdUsuario"] != null)
            {
                varUsuario = Session["_IdUsuario"].ToString();
            }

            long IdUsuario = 0;
            //string nombreHacienda = "";
            //long IdHacienda = 0;
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
                    //var hacienda = _context.Haciendas.FirstOrDefault(c => c.Activo && c.Nombre == usuario.NombreHacienda);

                    //IdHacienda = hacienda?.IdHacienda ?? 0;
                    //nombreHacienda = hacienda?.Nombre ?? "";
                }

            }


            UsuarioViewModel model = new UsuarioViewModel();
            // model.IdHacienda = IdHacienda;

            return View(model);
        }


        [HttpPost]
        public ActionResult RegistrarUsuario(UsuarioViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //AgricolaUser usuario = new AgricolaUser();
                    Cat_Usuarios usuario = new Cat_Usuarios();

                    usuario.Nombres = modelo.Nombres;
                    usuario.Apellidos = modelo.Apellidos;
                    usuario.Identificacion = modelo.Identificacio;
                    usuario.Username = modelo.UserName;
                    usuario.FechaCreacion = DateTime.Now;
                    usuario.Activo = true;
                    usuario.UsuarioCreacion = "";

                    //var clave = 
                    //usuario.Clave = clave;


                    _context.Cat_Usuarios.Add(usuario);
                    _context.SaveChanges();
                    return RedirectToAction("ListarUsuarios");


                }
                catch (Exception e)
                {
                    return View(modelo);
                    throw;
                }
            }
            return View(modelo);
        }



        [HttpPost]
        public ActionResult EditarUsuario(UsuarioViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //var clave = SeguridadClass.Encriptar(modelo.Clave);

                    var usuario = _context.Cat_Usuarios.Find(modelo.IdUsuario);
                    usuario.Nombres = modelo.Nombres;
                    usuario.Apellidos = modelo.Apellidos;
                    usuario.Identificacion = modelo.Identificacio;
                    usuario.Username = modelo.UserName;
                    usuario.Clave = usuario.Clave;
                    usuario.FechaModificacion = DateTime.Now;


                    _context.SaveChanges();
                    return RedirectToAction("ListarUsuarios");
                }
                catch (Exception)
                {
                    return View(modelo);
                    throw;
                }
            }
            return View(modelo);
        }


        public ActionResult ListarRoles()
        {
            ListarRolesViewModel model = new ListarRolesViewModel();


            var roles = _context.Roles.Where(c => c.Activo).ToList();
            if (roles == null)
            {
                return HttpNotFound();
            }

            foreach (var item in roles)
            {
                var itemrol = new AgricolaRoles();
                itemrol.Id = item.Id;
                itemrol.Name = item.Name;
                itemrol.Descripcion = item.Descripcion;
                itemrol.Plural = item.Plural;
                itemrol.Prioridad = item.Prioridad;
                model.Roles.Add(itemrol);
            }


            return View(model);
        }


        public ActionResult EditarRoll(long IdRoll)
        {
            RollViewModel model = new RollViewModel();

            var roll = _context.Roles.FirstOrDefault(c => c.Activo && c.Id == IdRoll);

            if (roll == null)
            {
                return HttpNotFound();
            }
            model.IdRoll = roll.Id;
            model.Nombre = roll.Name;
            model.Singular = roll.Plural;
            model.Prioridad = roll.Prioridad;
            model.Descripcion = roll.Descripcion;

            return View(model);
        }

        public ActionResult EliminarUsuario(long IdUsuario)
        {
            try
            {
                string varUsuario = null;
                if (Session["_UserName"] != null)
                {
                    varUsuario = Session["_UserName"].ToString();
                }

               
                var registro = _context.Cat_Usuarios.FirstOrDefault(c => c.IdUsuario == IdUsuario);
                registro.Activo = false;
                registro.FechaEliminacion = DateTime.Now;
                registro.UsuarioEliminacion = varUsuario;
                _context.SaveChanges();

                TempData["MensajeExito"] = "Se elimino correctamente el Usuario.";
                return RedirectToAction("ListarUsuarios");
            }
            catch (Exception)
            {
                TempData["MensajeExito"] = "Error al eliminar la Finca.";
                return RedirectToAction("ListarUsuarios");

            }

        }


      

        //public ActionResult Login()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Login(LoginViewModel modelo)
        //{
        //    try
        //    {
        //        var usuario = _context.Usuarios.FirstOrDefault(c => c.Activo 
        //        && c.Username.ToUpper() == modelo.usuario.ToUpper() && c.Clave.ToUpper() == modelo.clave.ToUpper());
        //        if(usuario!= null)
        //        {
        //            Session["User"] = usuario;
        //            Session["IdUsuario"] = usuario.IdUsuario;
        //            return RedirectToAction("Index","Home");

        //            //return RedirectToAction("Index", "Home", "Hacienda", new { area = "" }, new { @class = "item" });
        //        }
        //        else
        //        {
        //            ViewBag.Error = "Usuario o Contraseña invalida";
        //            return View();
        //        }
        //      return  RedirectToAction("");
        //    }
        //    catch (Exception)
        //    {
        //        return RedirectToAction("");
        //        throw;

        //    }

        //}

    }
}