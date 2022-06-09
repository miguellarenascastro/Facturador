using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiRest.Context
{
    public class TbrutasXml
    {
        public int Id { get; set; }
        public string RutaGenerado { get; set; }
        public string RutaFirmado { get; set; }
        public int FkComprobanteVenta { get; set; }
        public string RutaAutorizado { get; set; }
        public string RutaPdf { get; set; }
    }
}
