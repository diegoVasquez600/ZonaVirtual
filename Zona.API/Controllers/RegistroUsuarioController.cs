using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Text;
using Zona.API.Models;
using Zona.API.Utils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Zona.API.Controllers
{
    /// <summary>
    /// Controller RegistroUsuario
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroUsuarioController : ControllerBase
    {
        ZonaDBContext dBContext = new ZonaDBContext();
        /// <summary>
        /// Usage  POST api/RegistroContoller/Verificacion
        /// </summary>
        [HttpPost]
        [Route("Verificacion")]
        public int Verificacion([FromBody] Usuario value)
        {
            if (dBContext.Usuarios.Any(usr => usr.UsuarioIdentificacion.Equals(value.UsuarioIdentificacion)))
            {
                var usuario = dBContext.Usuarios.Where(usr => usr.UsuarioIdentificacion == value.UsuarioIdentificacion).FirstOrDefault();
                if (usuario.UsuarioPassword != null)
                {
                    return 1;
                }
                else
                    return 2;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>
        /// Usage PUT api/RegistroUsuario/Registro
        /// </remarks>
        [HttpPut]
        [Route("Registro")]
        public int Registro([FromBody] Usuario value)
        {
            if (dBContext.Usuarios.Any(usr => usr.UsuarioIdentificacion.Equals(value.UsuarioIdentificacion)))
            {
                var usuario = dBContext.Usuarios.Where(usr => usr.UsuarioIdentificacion == value.UsuarioIdentificacion).FirstOrDefault();
                if (usuario.UsuarioPassword != null)
                {
                    return 1;
                }
                else
                {
                    var find = dBContext.Usuarios.Find(usuario.IdUsuario);
                    find.UsuarioSalt = Convert.ToBase64String(Common.GetRandomSalt(16));
                    find.UsuarioPassword = Convert.ToBase64String(Common.SaltHashPassword(
                    Encoding.ASCII.GetBytes(value.UsuarioPassword), Convert.FromBase64String(find.UsuarioSalt)));
                    dBContext.Usuarios.Update(find);
                    dBContext.SaveChanges();
                    return 1;
                }

            }
            else
            {
                return 0;
            }
        }
    }
}
