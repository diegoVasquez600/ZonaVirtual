using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZonaClient.Models;
using ZonaClient.Services.Interfaces;

namespace ZonaClient.Services
{
    /// <summary>
    /// Class DataStorePrueba that connects to the ZonaVirtual API, implements <c>IPrueba</c> insterface.
    /// </summary>
    public class DataStorePrueba : IPrueba<Prueba>
    {
        /// <summary>
        /// Constructor DataStorePrueba Initialize the HTTP Client
        /// </summary>
        public DataStorePrueba()
        {

        }

        /// <summary>
        /// Method GetDataAsync 
        /// </summary>
        /// <returns>
        /// if the execution is correct returns a task else returns an exception message
        /// </returns>
        public Task<Prueba> GetDataAsync()
        {
            throw new NotImplementedException();
        }
    }
}
