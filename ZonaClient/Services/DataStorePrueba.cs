using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
        #region Fields
        HttpClient client;
        IEnumerable<Prueba> data;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor DataStorePrueba Initialize the HTTP Client
        /// </summary>
        public DataStorePrueba()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri($"{App.ZonaPruebaUrl}Prueba/")
            };
            data = new List<Prueba>();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Method GetDataAsync get data from the backend in postMethod
        /// </summary>
        /// <returns>
        /// if the execution is correct returns a task else returns an exception message
        /// </returns>
        public async Task<IEnumerable<Prueba>> GetDataAsync()
        {
            var serializedItem = "noneHere";
            var response = await client.PostAsync($"Consulta", new StringContent(serializedItem, Encoding.UTF8, "application/json"));
            data = JsonConvert.DeserializeObject<IEnumerable<Prueba>>(await response.Content.ReadAsStringAsync());
            return data;
        } 
        #endregion
    }
}
