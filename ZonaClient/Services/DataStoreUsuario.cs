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
                BaseAddress = new Uri($"{App.AzureBackendUrl}")
            };
            usuarios = new List<Usuario>();
        }
        #endregion

        #region Methods
        public async Task<string> AddUsuarioAsync(Usuario usuario)
        {
            var serializedItem = JsonConvert.SerializeObject(usuario);
            var response = await client.PostAsync($"Usuario/InsertUsuario", new StringContent(serializedItem, Encoding.UTF8, "application/json"));
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

        public async Task<string> LoginUsuarioAsync(Usuario usuario)
        {
            var serializedItem = JsonConvert.SerializeObject(usuario);
            var response = await client.PostAsync($"LoginUsuario/Login", new StringContent(serializedItem, Encoding.UTF8, "application/json"));
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> RegisterUsuarioAsync(Usuario usuario)
        {
            var serializedItem = JsonConvert.SerializeObject(usuario);
            var response = await client.PutAsync($"RegistroUsuario/Registro", new StringContent(serializedItem, Encoding.UTF8, "application/json"));
            return await response.Content.ReadAsStringAsync();
        }

        public Task<string> UpdateUsuarioAsync(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public async Task<string> VerificateUsuarioAsync(Usuario usuario)
        {
            var serializedItem = JsonConvert.SerializeObject(usuario);
            var response = await client.PostAsync($"RegistroUsuario/Verificacion", new StringContent(serializedItem, Encoding.UTF8, "application/json"));
            return await response.Content.ReadAsStringAsync();
        }
        #endregion
    }
}
