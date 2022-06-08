
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebApiRest.Interfaces;

#nullable disable

namespace WebApiRest.Context
{
    public partial class ComprobanteCompra :ID
    {
        [Column("ComprobantecId")]
        public int Id { get; set; }
        public int CasacomercialId { get; set; }
        public int UsuarioId { get; set; }
        public string ComprobantecNumerocompleto { get; set; }
        public DateTime ComprobantecFecha { get; set; }
        public string ComprobantecDetalle { get; set; }
        public string ComprobantecEstado { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ComprobantecSubtotal0 { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ComprobantecSubtotal12 { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ComprobantecIvatotal { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ComprobantecTotal { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ComprobantecDescuento { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ComprobantecSubtotal { get; set; }
        public string ComprobantecTipo { get; set; }
        public string ComprobantecFormapago { get; set; }
        public string ComprobantecNumeroserie { get; set; }
        public string ComprobantecNumerolocal { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ComprobantecNumero { get; set; }
    }
}
