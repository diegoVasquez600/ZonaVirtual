using Microsoft.AspNetCore.Mvc;
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
        IEnumerable<Usuario> usuarios = new List<Usuario>();
        // GET: api/<UsuarioController>
        [HttpGet]
        [Route("GetUsuarios")]
        public IEnumerable<Usuario> GetUsuario()
        {
            return usuarios;
        }

        // GET api/<UsuarioController>/5
        [HttpGet]
        [Route("GetUsuario")]
        public string GetUsuario(Usuario value)
        {
            return "value";
        }

        // POST api/<UsuarioController>
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

        // PUT api/<UsuarioController>/5
        [HttpPut]
        [Route("UpdateUsuario")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
