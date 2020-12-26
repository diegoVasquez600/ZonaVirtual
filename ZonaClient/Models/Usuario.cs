using System;
using System.Collections.Generic;

#nullable disable

namespace ZonaClient.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Transaccions = new HashSet<Transaccion>();
        }

        public int IdUsuario { get; set; }
        public string UsuarioNombre { get; set; }
        public string UsuarioIdentificacion { get; set; }
        public string UsuarioEmail { get; set; }
        public string UsuarioPassword { get; set; }
        public string UsuarioSalt { get; set; }

        public virtual ICollection<Transaccion> Transaccions { get; set; }
    }
}
