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
    public class DataStorePago:IPago<Pago>
    {
        #region Fields
        HttpClient client;
        IEnumerable<Pago> pagos;
        #endregion
        public DataStorePago()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri($"{App.AzureBackendUrl}Pagos/")
            };
        }

        public async Task<IEnumerable<Pago>> GetPagosUsuario(Usuario usuario)
        {
            var serializedItem = JsonConvert.SerializeObject(usuario);
            var response = await client.PostAsync($"GetPagosUsuario", new StringContent(serializedItem, Encoding.UTF8, "application/json"));
            var res = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Pago>>(res);
        }
    }
}
