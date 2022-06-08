using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgricolaData.ViewModel
{
    class FacturacionViewModels
    {
    }


    public class ViewMod11Dto
    {
        public string ClaveAcceso { get; set; }
    }

    public class Modulo11DTO
    {
        public String Fecha { get; set; }
        public string TipoComprobante { get; set; }
        public string RucEmpresa { get; set; }
        public string Ambiente { get; set; }
        public string PtoEmision { get; set; }
        public string Sucursal { get; set; }
        public string Secuencial { get; set; }
        public string Digito8 { get; set; }

    }

    public class ViewXmlDto
    {
        public int Id { get; set; }
        public string RutaXml { get; set; }

    }


    //public class GenerarXmlDTO
    //{
    //    [Required(ErrorMessage = "Campo requerido")]
    //    [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
    //    public int Id { get; set; }

    //    [Required(ErrorMessage = "Campo requerido")]
    //    public string ComprobantevTipo { get; set; }
    //    [Required(ErrorMessage = "Campo requerido")]
    //    [StringLength(maximumLength: 13, MinimumLength = 13)]
    //    [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
    //    public string RucEmpresa { get; set; }
    //}

}
