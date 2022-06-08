using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiRest.Context
{
    public partial class Tbdocumentosfacturacionelectronica
    {
        public int Id { get; set; }
        public int? FkComprobanteVenta { get; set; }
        public string Empidfk { get; set; }
        public string FelectEstado { get; set; }
        public string FelectAmbiente { get; set; }
        public string FelectNumeroautorizacion { get; set; }
        public string FelectFechaautorizacion { get; set; }
        public int? FelectIdentificador { get; set; }
        public string FelectMensaje { get; set; }
        public string FelectInformacionadicional { get; set; }
        public string FelectTipo { get; set; }
        public string FelectComprobantexml { get; set; }


    }
}
