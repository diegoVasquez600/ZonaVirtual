using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ZonaClient.Models;
using ZonaClient.Services.Interfaces;

namespace ZonaClient.Services
{
    public class DataStoreTransaccion : ITransaccion<Transaccion>
    {
        #region Fields
        HttpClient client;
        IEnumerable<Transaccion> transacciones;
        #endregion

        #region Contructors
        public DataStoreTransaccion()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri($"{App.AzureBackendUrl}Transaccion/")
            };
        }
        #endregion

        #region Methods
        public async Task<string> AddTransaccionAsync(Transaccion transaccion)
        {
            var serializedItem = JsonConvert.SerializeObject(transaccion);
            var response = await client.PostAsync($"InsertTransaccion", new StringContent(serializedItem, Encoding.UTF8, "application/json"));
            return await response.Content.ReadAsStringAsync();
        }

        public Task<string> DeleteTransaccionAsync(Transaccion transaccion)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Transaccion>> GetTransaccionAsync(Transaccion transaccion)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Transaccion>> GetTransaccionesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateTransaccionAsync(Transaccion transaccion)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
