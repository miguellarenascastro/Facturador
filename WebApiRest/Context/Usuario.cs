using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebApiRest.Context
{
    public partial class Usuario
    {
        [Column("UsuarioId")]
        public int Id { get; set; }
        public string UsuarioNombre { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UsuarioTipo { get; set; }
        public string UsuarioEstado { get; set; }
        public string UsuarioCodereset { get; set; }
    }
}
