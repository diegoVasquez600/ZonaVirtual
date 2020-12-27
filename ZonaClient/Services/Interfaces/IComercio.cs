using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZonaClient.Services.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IComercio<Comercio>
    {
        Task<string> AddComercioAsync(Comercio comercio);
        Task<string> UpdateComercioAsync(Comercio comercio);
        Task<string> DeleteComercioAsync(Comercio comercio);
        Task<IEnumerable<Comercio>> GetComercioAsync(Comercio comercio);
        Task<IEnumerable<Comercio>> GetComerciosAsync();
    }
}
