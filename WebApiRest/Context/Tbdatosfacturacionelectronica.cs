using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiRest.Context
{
    public partial class Tbdatosfacturacionelectronica
    {
        public int Id { get; set; }
        public int FkEmpresa { get; set; }
        public string Dfecontribuyente { get; set; }
        public string Dfeubicacionarchivop12 { get; set; }
        public string Dfecontrasena { get; set; }
        public string Dfeimagen { get; set; }
        public string Dfeubicacionruta { get; set; }
        public bool? Dfepruebaproduccion { get; set; }


    }
}
