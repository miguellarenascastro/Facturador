using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebApiRest.Context
{
    public partial class ComprobanteVentum
    {
        [Column("ComprobantevId")]
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public DateTime ComprobantevFecha { get; set; }
        public string ComprobantevTipo { get; set; }
        public string ComprobantevNumero { get; set; }
        public string ComprobantevFormapago { get; set; }
        public string ComprobantevRemision { get; set; }
        public string ComprobantevEstado { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ComprobantevSubtotal0 { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ComprobantevSubtotal12 { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ComprobantevDescuento { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ComprobantevSubtotal { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ComprobantevIvatotal { get; set; }
        public int UsuarioId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ComprobantevTotal { get; set; }
        public string Docsri { get; set; }
    }
}
