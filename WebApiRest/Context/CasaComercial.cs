
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebApiRest.Interfaces;

#nullable disable

namespace WebApiRest.Context
{
    public partial class CasaComercial : ID
    {
        [Column("CasacomercialId")]
        public int Id { get; set; }
        public string CasacomercialNombre { get; set; }
        public string CasacomercialRuc { get; set; }
        public string CasacomercialDireccion { get; set; }
        public string CasacomercialTelefono { get; set; }
        public string CasacomercialEstado { get; set; }
        public string CasacomercialEmail { get; set; }
        public string CasacomercialPropietario { get; set; }
    }
}
