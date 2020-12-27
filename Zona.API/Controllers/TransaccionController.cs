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
    ///  Controller Transaccion
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TransaccionController : ControllerBase
    {
        ZonaDBContext dbContext = new ZonaDBContext();
        // GET: api/<TransaccionController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TransaccionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// Method Insert a new Transaction
        /// </summary>
        /// <param name="value">
        /// Recieve Transaccion Model
        /// </param>
        /// <returns>
        /// if the execution is correct returns a message with the confirmation else returns an exception
        /// </returns>
        // POST api/Transaccion/InsertTransaccion
        [HttpPost]
        [Route("InsertTransaccion")]
        public string InsertTransaccion([FromBody] Transaccion value)
        {
            try
            {
                if(!dbContext.Transaccions.Any(ts => ts.TransCodigo.Equals(value.TransCodigo)))
                {
                    dbContext.Transaccions.Add(value);
                    dbContext.SaveChanges();
                    return $"La transaccion número {value.TransCodigo} ha sido insertada exitosamente";
                }
                else
                {
                    return $"La transaccion número {value.TransCodigo} ha sido insertada anteriormente";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // PUT api/<TransaccionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TransaccionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
