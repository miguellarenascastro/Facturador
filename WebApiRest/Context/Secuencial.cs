using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebApiRest.Context
{
    public partial class Secuencial
    {
        [Column("SecuencialId")]
        public int Id { get; set; }
        public string SecuencialNumero { get; set; }
        public string SecuencialTipo { get; set; }
        public int FkEmpresa { get; set; }

    }
}
