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
    public class DataStoreComercio:IComercio<Comercio>
    {
        #region Fields
        HttpClient client;
        IEnumerable<Comercio> comercios;
        #endregion

        #region Constructors
        public DataStoreComercio()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri($"{App.AzureBackendUrl}Comercio/")
            };
            comercios = new List<Comercio>();
        }
        #endregion

        #region Methods

        public async Task<string> AddComercioAsync(Comercio comercio)
        {
            var serializedItem = JsonConvert.SerializeObject(comercio);
            var response = await client.PostAsync($"InsertComercio", new StringContent(serializedItem, Encoding.UTF8, "application/json"));
            return await response.Content.ReadAsStringAsync();
        }

        public Task<string> DeleteComercioAsync(Comercio comercio)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Comercio>> GetComercioAsync(Comercio comercio)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Comercio>> GetComerciosAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateComercioAsync(Comercio comercio)
        {
            throw new NotImplementedException();
        } 
        #endregion
    }
}
