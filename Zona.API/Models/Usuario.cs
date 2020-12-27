#nullable disable

namespace Zona.API.Models
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string UsuarioNombre { get; set; }
        public string UsuarioIdentificacion { get; set; }
        public string UsuarioEmail { get; set; }
        public string UsuarioPassword { get; set; }
        public string UsuarioSalt { get; set; }
    }
}
