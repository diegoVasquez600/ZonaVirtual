using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zona.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Zona.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        ZonaDBContext dBContext = new ZonaDBContext();
        IEnumerable<Usuario> usuarios;
        /// <summary>
        /// Method GetUsuarios
        /// </summary>
        /// <returns>
        /// if the execution is complete returns the list of Usuarios
        /// </returns>
        /// <remarks>
        /// Usage GET: api/Usuario/GetUsuarios
        /// </remarks>
        [HttpGet]
        [Route("GetUsuarios")]
        public IEnumerable<Usuario> GetUsuario()
        {
            usuarios = new List<Usuario>();
            usuarios = dBContext.Usuarios.ToList();
            return usuarios;
        }

        /// <summary>
        /// Method GetUsuario
        /// </summary>
        /// <param name="value">
        /// Recieve the usuario Model
        /// </param>
        /// <returns>
        /// if the execution is successful returns the specific Usuario
        /// </returns>
        /// <remarks>
        /// Usage GET api/Usuario/GetUsuario
        /// </remarks>
        [HttpGet]
        [Route("GetUsuario")]
        public string GetUsuario([FromBody] Usuario value)
        {
            try
            {
                if (dBContext.Usuarios.Any(usr => usr.UsuarioIdentificacion.Equals(value.UsuarioIdentificacion)))
                {
                    var usuario = dBContext.Usuarios.Where(usr => usr.UsuarioIdentificacion == value.UsuarioIdentificacion).FirstOrDefault();
                    return JsonConvert.SerializeObject(usuario);
                }
                else
                    return $"El usuario con identificacion {value.UsuarioIdentificacion} no se encuentra";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// Method InsertUsuario
        /// </summary>
        /// <param name="value">
        /// Recieve the Usuario Model
        /// </param>
        /// <returns>
        /// If the execution is successful returns a Message else returns an exception
        /// </returns>
        /// <remarks>
        /// Usage POST api/Usuario/InsertUsuario
        /// </remarks>
        [HttpPost]
        [Route("InsertUsuario")]
        public string InsertUsuario([FromBody] Usuario value)
        {
            try
            {
                if (!dBContext.Usuarios.Any(usr => usr.UsuarioIdentificacion.Equals(value.UsuarioIdentificacion)))
                {
                    dBContext.Usuarios.Add(value);
                    dBContext.SaveChanges();
                    return $"El Usuario {value.UsuarioNombre} ha sido insertado exitosamente";
                }
                else
                {
                    return $"El Usuario {value.UsuarioNombre} ha sido insertado anteriormente";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// Method UpdateUsuario
        /// </summary>
        /// <param name="value">
        /// Recieve the Usuario Model
        /// </param>
        /// <remarks>
        /// Usage PUT api/Usuario/UpdateUsuario
        /// </remarks>
        [HttpPut]
        [Route("UpdateUsuario")]
        public string UpdateUsuario([FromBody] Usuario value)
        {
            try
            {
                if (dBContext.Usuarios.Any(usr=> usr.IdUsuario.Equals(value.IdUsuario)))
                {
                    dBContext.Usuarios.Update(value);
                    dBContext.SaveChanges();
                    return $"El Usuario {value.UsuarioNombre} actualizado correctamente";
                }
                else
                {
                    return $"El Usuario {value.UsuarioNombre} no se encuentra registrado";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// Method DeleteUsuario
        /// </summary>
        /// <param name="value">
        /// Recieve the usuario Model
        /// </param>
        /// <remarks>
        /// Usage DELETE api/Usuario/DeleteUsuario
        /// </remarks>
        [HttpDelete]
        [Route("DeleteUsuario")]
        public void DeleteUsuario([FromBody] Usuario value)
        {
            if (dBContext.Usuarios.Any(usr => usr.IdUsuario.Equals(value.IdUsuario)))
            {
                var delete = dBContext.Usuarios.Find(value.IdUsuario);
                dBContext.Usuarios.Remove(delete);
                dBContext.SaveChanges();
            }
        }
    }
}
