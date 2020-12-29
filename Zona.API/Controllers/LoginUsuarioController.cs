using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Text;
using Zona.API.Models;
using Zona.API.Utils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Zona.API.Controllers
{
    /// <summary>
    /// Controller LoginUsuario
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LoginUsuarioController : ControllerBase
    {
        ZonaDBContext dBContext = new ZonaDBContext();
        /// <summary>
        /// Method LoginUsuario
        /// </summary>
        /// <param name="value"></param>
        /// <remarks> 
        /// Usage POST api/LoginUsuario/Login
        /// </remarks> 

        [HttpPost]
        [Route("Login")]
        public string LoginUsuario([FromBody] Usuario value)
        {
            if (dBContext.Usuarios.Any(usr => usr.UsuarioIdentificacion.Equals(value.UsuarioIdentificacion)))
            {
                Usuario usuario = dBContext.Usuarios.Where(u => u.UsuarioIdentificacion.Equals(value.UsuarioIdentificacion)).First();
                // clientPostHashPassword decrypt password with salt algorithm.
                var clientPostHashPassword = Convert.ToBase64String(
                    Common.SaltHashPassword(
                    Encoding.ASCII.GetBytes(value.UsuarioPassword),
                    Convert.FromBase64String(usuario.UsuarioSalt)));
                if (clientPostHashPassword.Equals(usuario.UsuarioPassword))
                {
                    return JsonConvert.SerializeObject(usuario);
                }
                else
                    return "2";
            }
            else
                return "0";
        }
    }
}
