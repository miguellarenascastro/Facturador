using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebApiRest.Context
{
    public partial class Producto
    {
        [Column("ProductoId")]
        public int Id { get; set; }
        public string ProductoCod { get; set; }
        public string ProductoDescripcion { get; set; }
        public string ProductoEstado { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ProductoValor { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ProductoCantidad { get; set; }
        public string ProductoIva { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ProductoFabricacion { get; set; }
    }
}
