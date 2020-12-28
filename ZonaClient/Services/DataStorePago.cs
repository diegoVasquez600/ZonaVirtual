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
    public class DataStorePago:IPago<Pagos>
    {
        #region Fields
        HttpClient client;
        IEnumerable<Pagos> pagos;
        #endregion
        public DataStorePago()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri($"{App.AzureBackendUrl}Pagos/")
            };
        }

        public async Task<IEnumerable<Pagos>> GetPagosUsuario(Usuario usuario)
        {
            var serializedItem = JsonConvert.SerializeObject(usuario);
            var response = await client.PostAsync($"GetPagosUsuario", new StringContent(serializedItem, Encoding.UTF8, "application/json"));
            var res = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Pagos>>(res);
        }
    }
}
