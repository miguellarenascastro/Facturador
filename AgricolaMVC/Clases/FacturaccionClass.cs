using AgricolaData.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ApoloCartera.Clases
{
    public class FacturaccionClass
    {
        //private readonly IWebHostEnvironment webHostEnvironment;

        public ViewMod11Dto Modulo11(Modulo11DTO modulo11DTO)
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

            ViewMod11Dto mod11Dto = new ViewMod11Dto();

            mod11Dto.ClaveAcceso = claveAcceso + digitoVerificador.ToString();

            return mod11Dto;
        }



  
        //public async Task<ViewXmlDto> GenerarXml( GenerarXmlDTO generarXmlDTO)
        //{
        //    string folderProcesado = Path.Combine(webHostEnvironment.WebRootPath, "facturaelectronicaprocesados");

        //    if (!Directory.Exists(folderProcesado))
        //    {
        //        Directory.CreateDirectory(folderProcesado);
        //    }

        //    string folderFirmados = Path.Combine(webHostEnvironment.WebRootPath, "documentosfirmados");
        //    if (!Directory.Exists(folderFirmados))
        //    {
        //        Directory.CreateDirectory(folderFirmados);
        //    }

        //    string folderRechazados = Path.Combine(webHostEnvironment.WebRootPath, "documentosrechazados");
        //    if (!Directory.Exists(folderRechazados))
        //    {
        //        Directory.CreateDirectory(folderRechazados);
        //    }

        //    string folderAutorizados = Path.Combine(webHostEnvironment.WebRootPath, "documentosautorizados");
        //    if (!Directory.Exists(folderAutorizados))
        //    {
        //        Directory.CreateDirectory(folderAutorizados);
        //    }

        //    string folderNoAutorizados = Path.Combine(webHostEnvironment.WebRootPath, "documentosnoautorizados");
        //    if (!Directory.Exists(folderNoAutorizados))
        //    {
        //        Directory.CreateDirectory(folderNoAutorizados);
        //    }
        //    ////Empresa
        //    var empresa = await context.Empresas.FirstOrDefaultAsync(e => e.EmpresaRuc == generarXmlDTO.RucEmpresa);
        //    if (empresa == null)
        //        return BadRequest(error: "No existe Èmpresa");


        //    ///Traer Xml
        //    var FacturaXml = cFuncionesComprobantes.GetXmlFacturaAsync(generarXmlDTO.Id, false, generarXmlDTO.ComprobantevTipo, empresa.Id);
        //    if (FacturaXml == null)
        //        return BadRequest(error: "No existe xml");

        //    var factura = FacturaXml.InnerXml;
        //    factura = factura.Replace("&lt;", "<");
        //    factura = factura.Replace("&gt;", ">");

        //    var xmlByte = System.Text.Encoding.UTF8.GetBytes(factura);

        //    var GetXml = await context.ComprobanteVenta.
        //     FirstOrDefaultAsync(c => c.Id == generarXmlDTO.Id && c.ComprobantevTipo == generarXmlDTO.ComprobantevTipo);

        //    var ruta = almacenadorArchivos.GuardarArchivo(xmlByte, ".xml", folderProcesado, GetXml.Docsri);

        //    var rutasxml = await context.TbrutasXmls.FirstOrDefaultAsync(r => r.FkComprobanteVenta == GetXml.Id);
        //    if (rutasxml == null)
        //    {
        //        var rutaXml = new TbrutasXml
        //        {
        //            FkComprobanteVenta = GetXml.Id,
        //            RutaFirmado = null,
        //            RutaGenerado = ruta.Result
        //        };
        //        await context.AddAsync(rutaXml);
        //        await context.SaveChangesAsync();

        //        return Created("", new ViewXmlDto { Id = rutaXml.Id, RutaXml = rutaXml.RutaGenerado });
        //    }
        //    rutasxml.RutaGenerado = ruta.Result;
        //    await context.SaveChangesAsync();
        //    return Created("", new ViewXmlDto { Id = rutasxml.Id, RutaXml = rutasxml.RutaGenerado });



        //}

    }
}