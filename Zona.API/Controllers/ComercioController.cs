using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zona.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Zona.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComercioController : ControllerBase
    {
        ZonaDBContext dBContext = new ZonaDBContext();
        // GET: api/<ComercioController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ComercioController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">
        /// 
        /// </param>
        /// <remarks>
        ///  Using POST api/Comercio/InsertComercio
        /// </remarks>
        [HttpPost]
        [Route("InsertComercio")]
        public string InsertComercio([FromBody] Comercio value)
        {
            try
            {
                if (!dBContext.Comercios.Any(cm => cm.ComercioCodigo.Equals(value.ComercioCodigo)))
                {
                    dBContext.Comercios.Add(value);
                    dBContext.SaveChanges();
                    return $"Comercio {value.ComericoNombre} insertado correctamente";
                }
                else
                {
                    return $"El Comercio {value.ComericoNombre} ya se encuentra registrado";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // PUT api/<ComercioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<ComercioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
