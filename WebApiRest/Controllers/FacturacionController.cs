using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using WebApiRest.Context;
using WebApiRest.Controllers.CustomerControllers;
using WebApiRest.Dto;
using WebApiRest.Interfaces;
using WebApiRest.Services;

namespace WebApiRest.Controllers
{
    [ApiController]
    [Route("api/facturacion")]
    public class FacturacionController : CCustomBase
    {
        private readonly dbSRICompElectContext context;
        private readonly IAlmacenadorArchivos almacenadorArchivos;
        private readonly CFuncionesComprobantesElectronicos cFuncionesComprobantes;
        private readonly CGenerarRide cGenerarRide;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IMapper mapper;


        public FacturacionController(dbSRICompElectContext context, 
            IAlmacenadorArchivos almacenadorArchivos, 
            CFuncionesComprobantesElectronicos cFuncionesComprobantes,
            CGenerarRide cGenerarRide,
            IWebHostEnvironment webHostEnvironment, IMapper mapper) : base(context, mapper)
        {
            this.context = context;
            this.almacenadorArchivos = almacenadorArchivos;
            this.cFuncionesComprobantes = cFuncionesComprobantes;
            this.cGenerarRide = cGenerarRide;
            this.webHostEnvironment = webHostEnvironment;
            this.mapper = mapper;
        }



        [AllowAnonymous]
        [HttpGet("Modulo11")]
        public ActionResult<ViewMod11Dto> Modulo11([FromQuery] Modulo11DTO modulo11DTO)
        {
            int suma = 0, factor = 7;
            //12032021Fecha 06TipoComprobante 0704453810001RucEmpresa 1PruebaProducion 100PtoEmicion 001Sucursal 000000806Secuencial  00000051PK 1

            var claveAcceso = (modulo11DTO.Fecha + modulo11DTO.TipoComprobante + modulo11DTO.RucEmpresa
                + modulo11DTO.Ambiente + modulo11DTO.PtoEmision + modulo11DTO.Sucursal + modulo11DTO.Secuencial + modulo11DTO.Digito8 + "1");

            var clave = claveAcceso.ToCharArray();
            foreach (var item in clave)
            {
                suma = suma + Convert.ToInt32(item.ToString()) * factor;
                factor = factor - 1;
                if (factor == 1)
                    factor = 7;

            }
            var digitoVerificador = (suma % 11);
            digitoVerificador = 11 - digitoVerificador;
            if (digitoVerificador == 11)
                digitoVerificador = 0;
            if (digitoVerificador == 10)
                digitoVerificador = 1;

            return Ok(new ViewMod11Dto { ClaveAcceso = claveAcceso + digitoVerificador.ToString() });

        }


        [AllowAnonymous]
        [HttpPost("GenerarXml")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ViewXmlDto>> GenerarXml([FromBody] GenerarXmlDTO generarXmlDTO)
        {
            string folderProcesado = Path.Combine(webHostEnvironment.WebRootPath, "facturaelectronicaprocesados");

            if (!Directory.Exists(folderProcesado))
            {
                Directory.CreateDirectory(folderProcesado);
            }

            string folderFirmados = Path.Combine(webHostEnvironment.WebRootPath, "documentosfirmados");
            if (!Directory.Exists(folderFirmados))
            {
                Directory.CreateDirectory(folderFirmados);
            }

            string folderRechazados = Path.Combine(webHostEnvironment.WebRootPath, "documentosrechazados");
            if (!Directory.Exists(folderRechazados))
            {
                Directory.CreateDirectory(folderRechazados);
            }

            string folderAutorizados = Path.Combine(webHostEnvironment.WebRootPath, "documentosautorizados");
            if (!Directory.Exists(folderAutorizados))
            {
                Directory.CreateDirectory(folderAutorizados);
            }

            string folderNoAutorizados = Path.Combine(webHostEnvironment.WebRootPath, "documentosnoautorizados");
            if (!Directory.Exists(folderNoAutorizados))
            {
                Directory.CreateDirectory(folderNoAutorizados);
            }
            ////Empresa
            var empresa = await context.Empresas.FirstOrDefaultAsync(e => e.EmpresaRuc == generarXmlDTO.RucEmpresa);
            if (empresa == null)
                return BadRequest(error: "No existe Èmpresa");


            ///Traer Xml
            var FacturaXml = cFuncionesComprobantes.GetXmlFacturaAsync(generarXmlDTO.Id, false, generarXmlDTO.ComprobantevTipo, empresa.Id);
            if (FacturaXml == null)
                return BadRequest(error: "No existe xml" );

            var factura = FacturaXml.InnerXml;
            factura = factura.Replace("&lt;", "<");
            factura = factura.Replace("&gt;", ">");

            var xmlByte = System.Text.Encoding.UTF8.GetBytes(factura);

            var GetXml = await context.ComprobanteVenta.
             FirstOrDefaultAsync(c => c.Id == generarXmlDTO.Id && c.ComprobantevTipo == generarXmlDTO.ComprobantevTipo);

            var ruta = almacenadorArchivos.GuardarArchivo(xmlByte, ".xml", folderProcesado, GetXml.Docsri);

            var rutasxml = await context.TbrutasXmls.FirstOrDefaultAsync(r => r.FkComprobanteVenta == GetXml.Id);
            if (rutasxml == null)
            {
                var rutaXml = new TbrutasXml
                {
                    FkComprobanteVenta = GetXml.Id,
                    RutaFirmado = null,
                    RutaGenerado = ruta.Result
                };
                await context.AddAsync(rutaXml);
                await context.SaveChangesAsync();

                return Created("", new ViewXmlDto { Id = rutaXml.Id, RutaXml = rutaXml.RutaGenerado });
            }
            rutasxml.RutaGenerado = ruta.Result;
            await context.SaveChangesAsync();
            return Created("", new ViewXmlDto { Id = rutasxml.Id, RutaXml = rutasxml.RutaGenerado });



        }


        [AllowAnonymous]
        [HttpPost("SubirP12")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ViewArchivoP12Dto>> SubirP12([FromForm] ArchivoP12Dto archivoP12Dto)
        {

            try
            {
                var TbFE = mapper.Map<Tbdatosfacturacionelectronica>(archivoP12Dto);
                TbFE.Dfepruebaproduccion = false;
           

                if (archivoP12Dto.Dfeubicacionarchivop12 != null)
                {
                    //Sedes.RutaLogoSede = await almacenadorAzure.GuardarImagen(contenedor, imagenDTO.Imagen);

                    using (var memoryStream = new MemoryStream())
                    {
                        await archivoP12Dto.Dfeubicacionarchivop12.CopyToAsync(memoryStream);
                        var contenido = memoryStream.ToArray();
                        var extension = Path.GetExtension(archivoP12Dto.Dfeubicacionarchivop12.FileName);
                        TbFE.Dfeubicacionarchivop12 = await almacenadorArchivos.GuardarP12(contenido, extension, "archivosfacturacionelectronica",
                           archivoP12Dto.Dfeubicacionarchivop12.ContentType);
                    }
                }

                if (archivoP12Dto.Dfeimagen != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await archivoP12Dto.Dfeimagen.CopyToAsync(memoryStream);
                        var contenido = memoryStream.ToArray();
                        var extension = Path.GetExtension(archivoP12Dto.Dfeimagen.FileName);
                        TbFE.Dfeimagen = await almacenadorArchivos.GuardarP12(contenido, extension, "archivosfacturacionelectronica",
                           archivoP12Dto.Dfeubicacionarchivop12.ContentType);
                    }
                }
                await context.AddAsync(TbFE);
                await context.SaveChangesAsync();
                return Created("", new ViewArchivoP12Dto { Id = TbFE.Id });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);

            }


        }

        //firmaa

        [AllowAnonymous]
        [HttpPost("FirmaXml")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ViewXmlDto>> FirmaXml([FromBody] FirmaXmlDto firmaXmlDto)
        {

            if (firmaXmlDto == null)
            {
                return BadRequest("No existe datos");
            }
            try
            {
                var empresa = await context.Empresas.FirstOrDefaultAsync(e => e.EmpresaRuc == firmaXmlDto.RucEmpresa);
                if (empresa == null)
                    return BadRequest("No existe empresa");
                var comprobanteFirmar = await context.TbrutasXmls.FirstOrDefaultAsync(r => r.FkComprobanteVenta == firmaXmlDto.Id);
                if (comprobanteFirmar == null)
                    return BadRequest("No existe comprobante Firmar");

                var rutasdatosFE = await context.Tbdatosfacturacionelectronicas.FirstOrDefaultAsync(e => e.FkEmpresa == empresa.Id);
                if (comprobanteFirmar == null)
                    return BadRequest("No existe datos Facturacion");

                var comprobante = await context.ComprobanteVenta.FirstOrDefaultAsync(c => c.Id == firmaXmlDto.Id);
                if (comprobante == null)
                    return BadRequest("No existe comprobante");

                var firma = new PassStoreKS.Signer();
                firma.Sign(comprobanteFirmar.RutaGenerado,
                     webHostEnvironment.WebRootPath + @"\\documentosfirmados\\" + comprobante.Docsri + ".xml",
                     rutasdatosFE.Dfeubicacionarchivop12, rutasdatosFE.Dfecontrasena);

                comprobanteFirmar.RutaFirmado = webHostEnvironment.WebRootPath + @"\\documentosfirmados\\" + comprobante.Docsri + ".xml";
                context.SaveChanges();

                return Ok(new ViewXmlDto { Id = comprobanteFirmar.Id, RutaXml = comprobanteFirmar.RutaFirmado });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }


        //ws
        [AllowAnonymous]
        [HttpGet("RecepcionPrueba")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<RespuestaRecepcionSri>> RecepcionPrueba([FromQuery] RecepcionDto recepcionDto)
        {
            var ruta = await context.TbrutasXmls.FirstOrDefaultAsync(c => c.FkComprobanteVenta == recepcionDto.Id);

            if (ruta == null)
                return BadRequest("No existe datos Comprobante" );

            var recepcion = cFuncionesComprobantes.RecepcionComprobantePrueba(ruta.RutaFirmado);
            if (recepcion.Estado.Equals("RECIBIDA"))
                return Ok(new RespuestaRecepcionSri { RespuestaRecepcion = recepcion.Estado });
            recepcion.Comprobantes[0].Mensajes[0].mensaje.ToString();
            return BadRequest(error:recepcion.Estado + " Mensaje: " + recepcion.Comprobantes[0].Mensajes[0].mensaje.ToString() );

        }




        [AllowAnonymous]
        [HttpGet("AutorizacionPrueba")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RespuestaAutorizacionSri>> AutorizacionPrueba([FromQuery] AutorizacionDto autorizacionDto)
        {
            var comprobante = await context.ComprobanteVenta.FirstOrDefaultAsync(x => x.Id == autorizacionDto.Id);
            
            if (comprobante == null)
                return BadRequest("No existe datos Comprobante" );
            var ruta = await context.TbrutasXmls.FirstOrDefaultAsync(c => c.FkComprobanteVenta == comprobante.Id);
            if (ruta == null)
                return BadRequest("No existe datos Comprobantefirmado" );

            var autorizacion = cFuncionesComprobantes.AutorizacionComprobantePrueba(comprobante.Docsri);
            if (autorizacion.Comprobantes[0].Estado.Equals("AUTORIZADO"))
            {
                cFuncionesComprobantes.xmlAutorizado(ruta.RutaFirmado,
                  webHostEnvironment.WebRootPath + @"\\documentosautorizados\\" + comprobante.Docsri + ".xml", autorizacion.Comprobantes[0].Estado,
                autorizacion.ClaveAcceso, autorizacion.Comprobantes[0].FechaAutorizacion);

                return Ok(new RespuestaAutorizacionSri { RespuestaAutorizacion = autorizacion.Comprobantes[0].Estado });
            }
            return BadRequest(error: autorizacion.Comprobantes[0].Mensajes );


        }

        //wsPRoduccion
        [AllowAnonymous]
        [HttpGet("Recepcion")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<RespuestaRecepcionSri>> Recepcion([FromQuery] RecepcionDto recepcionDto)
        {
            var ruta = await context.TbrutasXmls.FirstOrDefaultAsync(c => c.FkComprobanteVenta == recepcionDto.Id);

            if (ruta == null)
                return BadRequest("No existe datos Comprobante" );

            var recepcion = cFuncionesComprobantes.RecepcionComprobante(ruta.RutaFirmado);
            if (recepcion.Estado.Equals("RECIBIDA"))
                return Ok(new RespuestaRecepcionSri { RespuestaRecepcion = recepcion.Estado });

            return BadRequest(recepcion.Estado);
        }

        [AllowAnonymous]
        [HttpGet("Autorizacion")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RespuestaAutorizacionSri>> Autorizacion([FromQuery] AutorizacionDto autorizacionDto)
        {
            var comprobante = await context.ComprobanteVenta.FirstOrDefaultAsync(x => x.Id == autorizacionDto.Id);

            if (comprobante == null)
                return BadRequest("No existe datos Comprobante" );
            var ruta = await context.TbrutasXmls.FirstOrDefaultAsync(c => c.FkComprobanteVenta == comprobante.Id);
            if (ruta == null)
                return BadRequest("No existe datos Comprobantefirmado" );

            var autorizacion = cFuncionesComprobantes.AutorizacionComprobante(comprobante.Docsri);
            if (autorizacion.Comprobantes[0].Estado.Equals("AUTORIZADO"))
            {
                cFuncionesComprobantes.xmlAutorizado(ruta.RutaFirmado,
                  webHostEnvironment.WebRootPath + @"\\documentosautorizados\\" + comprobante.Docsri + ".xml", autorizacion.Estado,
                autorizacion.ClaveAcceso, autorizacion.Comprobantes[0].FechaAutorizacion);
                ruta.RutaAutorizado = webHostEnvironment.WebRootPath + @"\\documentosautorizados\\" + comprobante.Docsri + ".xml";
                await context.SaveChangesAsync();
                return Ok(new RespuestaAutorizacionSri { RespuestaAutorizacion = autorizacion.Comprobantes[0].Estado });
            }
            return BadRequest(error: autorizacion.Comprobantes[0].Estado );


        }


        //pdf

        [AllowAnonymous]
        [HttpGet("GeneracionRide")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ViewPathPDFDTo>> GeneracionRide([FromQuery] PdfDTO pdfDTO)

        {
            string folderPdf = Path.Combine(webHostEnvironment.WebRootPath, "pdf");

            if (!Directory.Exists(folderPdf))
            {
                Directory.CreateDirectory(folderPdf);
            }


            var rutas = await context.TbrutasXmls.FirstOrDefaultAsync(c => c.FkComprobanteVenta == pdfDTO.Id);
            if (rutas == null)
                return BadRequest("No existe xml" );

            var xml = XDocument.Load(rutas.RutaFirmado);


            var empresa = await context.Empresas.FirstOrDefaultAsync(e => e.EmpresaRuc == pdfDTO.RucEmpresa);
            if (rutas == null)
                return BadRequest("No existe empresa" );

            var imagen = await context.Tbdatosfacturacionelectronicas.FirstOrDefaultAsync(e => e.FkEmpresa == empresa.Id);

            if (imagen.Dfeimagen == null)
                return BadRequest("No existe imagen" );
            byte[] imagenStream = System.IO.File.ReadAllBytes(imagen.Dfeimagen);
            Stream StreamImagen = new MemoryStream(imagenStream);



            var pdf = cGenerarRide.GeneracionRideFactura(folderPdf, xml, StreamImagen);


            if (!string.IsNullOrEmpty(pdf))
            {
                rutas.RutaPdf = pdf;
                await context.SaveChangesAsync();
                return Ok(new ViewPathPDFDTo { RutaPDF = pdf });
            }
            return BadRequest("No se genero PDF" );
        }

    }

}
