using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebApiRest.Context
{
    public partial class DetalleVentum
    {
        [Column("DetallevId")]
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public int ComprobantevId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal DetallevCantidad { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal DetallevValor { get; set; }
        public string DetallevEstado { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal DetallevDescuento { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal DetallevTotal { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal DetallevDescuentoporc { get; set; }
    }
}
