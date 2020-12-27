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
    public class DataStoreUsuario : IUsuario<Usuario>
    {
        #region Fields
        HttpClient client;
        IEnumerable<Usuario> usuarios;
        #endregion

        #region Constructors
        public DataStoreUsuario()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri($"{App.AzureBackendUrl}Usuario/")
            };
            usuarios = new List<Usuario>();
        } 
        #endregion

        #region Methods
        public async Task<string> AddUsuarioAsync(Usuario usuario)
        {
            var serializedItem = JsonConvert.SerializeObject(usuario);
            var response = await client.PostAsync($"InsertUsuario", new StringContent(serializedItem, Encoding.UTF8, "application/json"));
            return await response.Content.ReadAsStringAsync();
        }

        public Task<string> DeleteUsuarioAsync(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Usuario>> GetUsuarioAsync(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Usuario>> GetUsuariosAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateUsuarioAsync(Usuario usuario)
        {
            throw new NotImplementedException();
        } 
        #endregion
    }
}
