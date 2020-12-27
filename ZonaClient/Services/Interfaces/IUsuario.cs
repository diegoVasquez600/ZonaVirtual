using System.Collections.Generic;
using System.Threading.Tasks;

namespace ZonaClient.Services.Interfaces
{
    public interface IUsuario<Usuario>
    {
        Task<string> AddUsuarioAsync(Usuario usuario);
        Task<string> UpdateUsuarioAsync(Usuario usuario);
        Task<string> DeleteUsuarioAsync(Usuario usuario);
        Task<IEnumerable<Usuario>> GetUsuarioAsync(Usuario usuario);
        Task<IEnumerable<Usuario>> GetUsuariosAsync();
    }
}
