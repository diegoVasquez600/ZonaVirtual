using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZonaClient.Services.Interfaces
{
    /// <summary>
    /// Interface IPrueba
    /// </summary>
    /// <typeparam name="Prueba">Prueba Model</typeparam>
    public interface IPrueba<Prueba>
    {
        /// <summary>
        /// Method GetDataAsync 
        /// </summary>
        /// <returns>
        /// if the execution is correct returns a task else returns an exception message
        /// </returns>
        Task<IEnumerable<Prueba>> GetDataAsync();
    }
}
