using AgricolaData.Entities;
using AgricolaData.ViewModel;
using ExcelDataReader;
using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ApoloCartera.Controllers
{
    public class CargaArchivoController : Controller
    {
        private Logger _logger = LogManager.GetLogger("AppDomainLog");
        private ApoloData.Context _context = new ApoloData.Context();
        //private CombosClass CombosClass = new CombosClass();


        public CargaArchivoController()
        {
            _context = new ApoloData.Context();

        }



        public ActionResult Listar()
        {
            ListarArchivoOrdenViewModel model = new ListarArchivoOrdenViewModel();
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
                var usuario = _context.Cat_Usuarios.FirstOrDefault(c => c.IdUsuario == IdUsuario);
                if (usuario != null)
                {
                    var data = _context.FilaArchivoOrdens.Where(c => c.Activo == true).ToList();

                    if (data != null)
                    {
                        model.Archivos = data.Select(c => new ItemArchivoViewModel
                        {
                            IdArchivoOrden = 0,
                            IdEmpresa = 0,
                            FechaOrden = c.FechaCreacion ?? DateTime.Now,
                            UsuarioCarga = c.UsuarioCreacion,
                            Detalle = "",
                            IdFilaArchivoOrden = c.IdFilaArchivoOrden,
                            NumCedula = c.NumCedula,
                            NombrePersona = c.NombrePersona,
                            Valor = c.Valor
                        }).ToList();
                    }
                }
            }
            #endregion

            return View(model);

        }


        public bool CrearFactura(long IdArchivo)
        {


            var ArchivoCabecera = _context.ArchivoOrdens.FirstOrDefault(c => c.Activo && c.IdArchivoOrden == IdArchivo);

            if (ArchivoCabecera != null)
            {
                var filasArchivo = _context.FilaArchivoOrdens.Where(c => c.Activo && c.IdArchivoOrden == ArchivoCabecera.IdArchivoOrden).ToList();

                foreach (var item in filasArchivo)
                {


                    var persona = _context.Personas.FirstOrDefault(c => c.Activo && c.Ruc.Contains(item.NumCedula.Trim().ToString()));


                    if (persona != null)
                    {
                        DocumentoCabecera Cabecera = new DocumentoCabecera();
                        var empresa = _context.Empresas.FirstOrDefault(c => c.Activo && c.IdEmpresa == 4);
                        var establecimiento = _context.Establecimientos.FirstOrDefault(c => c.Activo && c.IdEmpresa == empresa.IdEmpresa && c.IdEstablecimiento == 1);
                        var puntoVenta = _context.PuntoVentas.FirstOrDefault(c => c.Activo && c.IdPuntoVenta == 1 && c.IdEstablecimiento == 1);
                        var formaPago = _context.FormaPagos.FirstOrDefault(c => c.Activo && c.IdFormaPago == 1);
                        var tipoDocumento = _context.TipoDocumentos.First(c => c.Activo && c.Nombre == "Factura");


                        Cabecera.IdEmpresa = empresa.IdEmpresa;
                        Cabecera.IdEstablecimiento = establecimiento.IdEstablecimiento;
                        Cabecera.IdPuntoVenta = puntoVenta.IdPuntoVenta;
                        Cabecera.IdPersona = persona.IdPersona;
                        Cabecera.Descripcion = ArchivoCabecera.DetalleFacturas;
                        Cabecera.FechaEmision = DateTime.Now;
                        Cabecera.FechaVencimiento = DateTime.Now.AddMonths(1);
                        Cabecera.DireccionMatriz = empresa.Direccion;
                        Cabecera.DireccionSucursal = establecimiento.Direccion;
                        Cabecera.IdFormaPago = formaPago.IdFormaPago;

                        Cabecera.Info1Direccion = "";
                        Cabecera.NumDocumento = 1;
                        Cabecera.IdTipoDocumento = tipoDocumento.IdTipoDocumento;

                       //Cabecera.IdTipoDocumentoModificado = 1;
                        Cabecera.ComprobanteModifica = "";
                        Cabecera.RazonModificacion = "";

                        Cabecera.Activo = true;
                        Cabecera.UsuarioCreacion = "";
                        Cabecera.FechaCreacion = DateTime.Now;


                        _context.DocumentoCabecera.Add(Cabecera);
                        _context.SaveChanges();


                        DocumentoDetalle DetalleFactura = new DocumentoDetalle();


                        DetalleFactura.IdDocumentoCabecera = Cabecera.IdDocumentoCabecera;

                        DetalleFactura.Cantidad = 1;
                        DetalleFactura.IdUnidadMedida = 1;
                        DetalleFactura.Precio = item.Valor;

                        DetalleFactura.Descuento = 0;
                        DetalleFactura.SubTotal = item.Valor;
                        DetalleFactura.DetalleDocumento = Cabecera.Descripcion;

                        DetalleFactura.Activo = true;
                        DetalleFactura.UsuarioCreacion = "SYSTEM";
                        DetalleFactura.FechaCreacion = DateTime.Now;

                        _context.DocumentoDetalles.Add(DetalleFactura);
                        _context.SaveChanges();

                    }



                }
            }


            return true;
        }

        public ActionResult RegistrarArchivoOrden(long? IdLote = 0, long? IdConcepto = 0)
        {

            string varUsuario = null;
            ListarArchivoOrdenPagoViewModel Model = new ListarArchivoOrdenPagoViewModel();

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

            var ServerSavePath = Path.Combine(Server.MapPath("~/Plantillas/"));

            var NombreArchivo = "PLANTILLA_TABLA_COMPUESTA.xlsx";

            var pathCompleto = ServerSavePath + "" + NombreArchivo;

            Model.Url_Plantilla = pathCompleto;

            Model.Url_Plantilla = ServerSavePath.ToString().Trim().ToUpper();

            Model.Url_Plantilla = Model.Url_Plantilla.Replace('%', ' ');
            Model.Url_Plantilla = Model.Url_Plantilla.Replace('*', ' ');
            Model.Url_Plantilla = Model.Url_Plantilla.Replace('-', ' ');
            Model.Url_Plantilla = Model.Url_Plantilla.Replace('+', ' ');
            Model.Url_Plantilla = Model.Url_Plantilla.Replace('.', ' ');
            Model.Url_Plantilla = Model.Url_Plantilla.Replace('=', ' ');



            //NumInspeccion = item.ArchivosInspeccion?.NumInspeccion;
            //NombreInspector = item.ArchivosInspeccion?.Inspector?.Username;

            //itemVista.IdFoto = item.IdFoto;
            //itemVista.Nombre = item.Nombre;
            //itemVista.URL = suffiView + "" + strimData;

            Model.FechaContrato = DateTime.Now;



            return View(Model);
        }


        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> RegistrarArchivoOrden(FormCollection fc, HttpPostedFileBase upload)
        {
            ListarArchivoOrdenPagoViewModel Model = new ListarArchivoOrdenPagoViewModel();




            if (ModelState.IsValid)
            {

                string varUsuario = null;


                if (Session["_IdUsuario"] != null)
                {
                    varUsuario = Session["_IdUsuario"].ToString();
                }

                if (upload != null && upload.ContentLength > 0)
                {
                    var tabla = await RegistrarAsync(upload, varUsuario);

                    Model.Filas = tabla;
                }
                else
                {
                    ModelState.AddModelError("File", "Please Upload Your file");
                }
            }





            return View(Model);

        }


        public async Task<List<ItemFilaArchivoViewModel>> RegistrarAsync(HttpPostedFileBase upload, string varUsuario)
        {

            // List<ItemFilaArchivoContenedoresViewModel> Lista = new List<ItemFilaArchivoContenedoresViewModel>();

            List<ItemFilaArchivoViewModel> listaCargaArchivo = new List<ItemFilaArchivoViewModel>();

            if (upload != null && upload.ContentLength > 0)
            {
                try
                {
                    // ExcelDataReader works with the binary Excel file, so it needs a FileStream
                    // to get started. This is how we avoid dependencies on ACE or Interop:
                    Stream stream = upload.InputStream;

                    // We return the interface, so that
                    IExcelDataReader reader = null;

                    long IdUsuario = 0;

                    long.TryParse(varUsuario, out IdUsuario);



                    var usuarioLocal = _context.Cat_Usuarios.FirstOrDefault(c => c.Activo && c.IdUsuario == IdUsuario);

                    if (upload.FileName.EndsWith(".xls"))
                    {
                        reader = ExcelReaderFactory.CreateBinaryReader(stream);
                    }
                    else if (upload.FileName.EndsWith(".xlsx"))
                    {
                        reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                    }
                    else
                    {
                        //ModelState.AddModelError("File", "This file format is not supported");
                        return listaCargaArchivo; ;
                    }

                    DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });

                    if (result != null && result.Tables[0].Rows.Count > 0)
                    {

                        ArchivoOrden cabecera = new ArchivoOrden();

                        cabecera.IdEmpresa = 0;
                        cabecera.FechaOrden = DateTime.Now;
                        cabecera.UsuarioCarga = varUsuario;

                        cabecera.Activo = true;
                        cabecera.UsuarioCreacion = usuarioLocal.Username;
                        cabecera.FechaCreacion = DateTime.Now;

                        _context.ArchivoOrdens.Add(cabecera);
                        _context.SaveChanges();

                        int NumeroFila = 0;

                        foreach (var item in result.Tables[0].Rows)
                        {
                            if ((((System.Data.DataRow)item).ItemArray[1] != null) && (((System.Data.DataRow)item).ItemArray[1].ToString() != ""))
                            {
                                FilaArchivoOrden fila = new FilaArchivoOrden();

                                decimal ValorFila = 0;

                                decimal.TryParse(((System.Data.DataRow)item).ItemArray[3].ToString(), out ValorFila);

                                fila.IdArchivoOrden = cabecera.IdArchivoOrden;
                                fila.NumCedula = ((System.Data.DataRow)item).ItemArray[0].ToString();
                                fila.NombrePersona = ((System.Data.DataRow)item).ItemArray[1].ToString();
                                fila.Valor = ValorFila;

                                fila.Activo = true;
                                fila.UsuarioCreacion = usuarioLocal.Username;
                                fila.FechaCreacion = DateTime.Now;

                                _context.FilaArchivoOrdens.Add(fila);
                                _context.SaveChanges();


                                ItemFilaArchivoViewModel itemFilaArchivo = new ItemFilaArchivoViewModel();
                                itemFilaArchivo.NumFila = NumeroFila;
                                itemFilaArchivo.Detalle = "Cuota Doctor #: " + fila.NombrePersona + ", creada correctamente";

                                listaCargaArchivo.Add(itemFilaArchivo);
                            }
                            NumeroFila = NumeroFila + 1;
                        }
                        CrearFactura(cabecera.IdArchivoOrden);

                        //if (cabecera != null)
                        //{
                        //    var detalles = _context.FilaArchivoOrdens.Where(c => c.Activo && c.IdArchivoOrden == cabecera.IdArchivoOrden).ToList();

                        //    foreach (var item in detalles)
                        //    {
                        //        DocumentoCabecera CabeceraFactura = new DocumentoCabecera();


                        //        var TipoDocumento = _context.TipoDocumentos.FirstOrDefault(c => c.Activo && c.Nombre == "Factura");
                        //        var Empresa = _context.Empresas.FirstOrDefault(c => c.Activo && c.IdEmpresa == 4);
                        //        var Establecimiento = _context.Establecimientos.FirstOrDefault(c => c.Activo && c.IdEstablecimiento == 1);

                        //        CabeceraFactura.IdTipoDocumento = TipoDocumento.IdTipoDocumento;
                        //        CabeceraFactura.IdEmpresa = 4;
                        //        CabeceraFactura.IdEstablecimiento = Establecimiento.IdEstablecimiento;
                        //        CabeceraFactura.IdPuntoVenta = 1;

                        //        CabeceraFactura.FechaEmision = DateTime.Now;

                        //        CabeceraFactura.IdPersona = 4;
                        //        CabeceraFactura.Descripcion = "Factura emitida por Orden de Facturación #" + cabecera.IdArchivoOrden;
                        //        CabeceraFactura.FechaVencimiento = DateTime.Now;
                        //        CabeceraFactura.DireccionMatriz = Empresa.Direccion;
                        //        CabeceraFactura.DireccionSucursal = Establecimiento.Direccion;
                        //        CabeceraFactura.NumDocumento = 0;
                        //        CabeceraFactura.Info1Direccion = "";
                        //        CabeceraFactura.Info2Email = "";
                        //        CabeceraFactura.IdFormaPago = 0;


                        //        CabeceraFactura.IdTipoDocumentoModificado = 0;
                        //        CabeceraFactura.ComprobanteModifica = "";
                        //        CabeceraFactura.RazonModificacion = "";

                        //        CabeceraFactura.Activo = true;
                        //        CabeceraFactura.UsuarioCreacion = usuarioLocal.Username;
                        //        CabeceraFactura.FechaCreacion = DateTime.Now;

                        //        _context.DocumentoCabecera.Add(CabeceraFactura);
                        //        _context.SaveChanges();

                        //        DocumentoDetalle detalle = new DocumentoDetalle();



                        //        detalle.IdDocumentoCabecera = CabeceraFactura.IdDocumentoCabecera;

                        //        detalle.IdProducto = 1;

                        //        detalle.Cantidad = 1;
                        //        detalle.IdUnidadMedida = 1;
                        //        detalle.Precio = item.Valor;
                        //        detalle.IdRetenFuente = 0;
                        //        detalle.IdRetenIva = 0;
                        //        detalle.Descuento = 0;
                        //        detalle.SubTotal = item.Valor;

                        //        _context.DocumentoDetalles.Add(detalle);
                        //        _context.SaveChanges();

                        //    }




                        //}

                        return listaCargaArchivo;
                    }
                }
                catch (Exception e)
                {

                    throw;
                }
            }
            return listaCargaArchivo;
        }

    }
}

