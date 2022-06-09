
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebApiRest.Interfaces;

#nullable disable

namespace WebApiRest.Context
{
    public partial class Cliente : ID
    {
        [Column("ClienteId")]
        public int Id { get; set; }
        public string ClienteCiruc { get; set; }
        public string ClienteNombre { get; set; }
        public string ClienteEmail { get; set; }
        public string ClienteDireccion { get; set; }
        public string ClienteTelefono { get; set; }
        public string ClienteEstado { get; set; }
    }
}
