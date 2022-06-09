using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiRest.Dto
{
    public class GenerarXmlDTO
    {
        [Required(ErrorMessage = "Campo requerido")]
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public string ComprobantevTipo { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(maximumLength: 13, MinimumLength = 13)]
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        public string RucEmpresa { get; set; }
    }

    public class ViewXmlDto
    {
        public int Id { get; set; }
        public string RutaXml { get; set; }

    }


    public class ArchivoP12Dto
    {
        public int FkEmpresa { get; set; }
        public string Dfecontribuyente { get; set; }
        public IFormFile Dfeubicacionarchivop12 { get; set; }
        public string Dfecontrasena { get; set; }
        public IFormFile Dfeimagen { get; set; }
        public bool? Dfepruebaproduccion { get; set; }

    }
    public class ViewArchivoP12Dto
    {
        public int Id { get; set; }

    }
    public class PdfDTO
    {
        [Required(ErrorMessage = "Campo requerido")]
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(maximumLength: 13, MinimumLength = 13)]
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        public string RucEmpresa { get; set; }

    }

    public class ViewPathPDFDTo
    {
        public int Id { get; set; }
        public string RutaPDF { get; set; }

    }


    public class FirmaXmlDto : GenerarXmlDTO
    {


    }


    public class RecepcionDto
    {
        [Required(ErrorMessage = "Campo requerido")]
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        public int Id { get; set; }

    }
    public class AutorizacionDto
    {
        [Required(ErrorMessage = "Campo requerido")]
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        public int Id { get; set; }


    }


    public class RespuestaRecepcionSri
    {

        public string RespuestaRecepcion { get; set; }

    }

    public class RespuestaAutorizacionSri
    {

        public string RespuestaAutorizacion { get; set; }

    }

}
