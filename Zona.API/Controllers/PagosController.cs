using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zona.API.DAO;
using Zona.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Zona.API.Controllers
{
    /// <summary>
    /// Controller Pagos
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PagosController : ControllerBase
    {
        IEnumerable<Pagos> pagos = new List<Pagos>();
        ZonaDBContext dbContext = new ZonaDBContext();
        PagoDAO objDAO = new PagoDAO();
        // GET: api/<PagosController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// Method GetPagosUsuario
        /// </summary>
        /// <param name="value"> recieve the Usuari Model</param>
        /// <returns>A string with all the Pagos</returns>
        /// <remarks>
        /// GET api/Pagos/GetPagosUsuario
        /// </remarks>
        [HttpPost]
        [Route("GetPagosUsuario")]
        public string GetPagosUsuario([FromBody] Usuario value)
        {
            var pagos = objDAO.GetPagosUsuario(value.UsuarioIdentificacion);
            return JsonConvert.SerializeObject(pagos);
        }

        // POST api/<PagosController>
        //[HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PagosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PagosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
