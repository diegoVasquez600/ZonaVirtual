using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZonaClient.Models;

namespace ZonaClient.Services.Interfaces
{
    public interface IPago<Pagos>
    {
        Task<IEnumerable<Pagos>> GetPagosUsuario(Usuario usuario);
    }
}
