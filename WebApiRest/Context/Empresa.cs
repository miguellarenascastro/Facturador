using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebApiRest.Context
{
    public partial class Empresa
    {
        [Column("EmpresaId")]
        public int Id { get; set; }
        public string EmpresaRuc { get; set; }
        public string EmpresaPropietario { get; set; }
        public string EmpresaEmail { get; set; }
        public string EmpresaClasecontribuyente { get; set; }
        public string EmpresaNumerocalificacion { get; set; }
        public string EmpresaCalificacionartesanal { get; set; }
        public string EmpresaActividadeconomica { get; set; }
        public string EmpresaOlc { get; set; }
        public string EmpresaEstado { get; set; }
        public string EmpresaNombre { get; set; }
        public string EmpresaDireccion { get; set; }
    }
}
