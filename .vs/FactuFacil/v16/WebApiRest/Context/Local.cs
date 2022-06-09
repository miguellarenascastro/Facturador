using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebApiRest.Context
{
    public partial class Local
    {
        [Column("LocalId")]
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public string LocalNombre { get; set; }
        public string LocalTelefono { get; set; }
        public string LocalDireccion { get; set; }
        public string LocalActividad { get; set; }
        public DateTime LocalFechainicioactividad { get; set; }
        public string LocalEstado { get; set; }
        public string LocalNumero { get; set; }
    }
}
