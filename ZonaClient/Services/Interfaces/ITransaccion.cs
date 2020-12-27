using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZonaClient.Services.Interfaces
{
    public interface ITransaccion<Transaccion>
    {
        Task<string> AddTransaccionAsync(Transaccion transaccion);
        Task<string> UpdateTransaccionAsync(Transaccion transaccion);
        Task<string> DeleteTransaccionAsync(Transaccion transaccion);
        Task<IEnumerable<Transaccion>> GetTransaccionAsync(Transaccion transaccion);
        Task<IEnumerable<Transaccion>> GetTransaccionesAsync();
    }
}
