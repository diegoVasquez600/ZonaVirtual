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
    public class MedioPagoController : ControllerBase
    {
        ZonaDBContext dbContext = new ZonaDBContext();
        // GET: api/<MedioPagoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<MedioPagoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>
        /// Usage POST api/MedioPago/InsertMedioPago
        ///</remarks>
        [HttpPost]
        [Route("InsertMedioPago")]
        public string InsertMedioPago([FromBody] TransMedioPago value)
        {
            try
            {
                if (!dbContext.TransMedioPagos.Any(tmp => tmp.MedioPagoCodigo.Equals(value.MedioPagoCodigo)))
                {
                    dbContext.TransMedioPagos.Add(value);
                    dbContext.SaveChanges();
                    return $"El Medio de pago con codigo {value.MedioPagoCodigo} ha sido insertada exitosamente";
                }
                else
                {
                    return $"El Medio de pago con codigo {value.MedioPagoCodigo} ya ha sido insertado anteriormente";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // PUT api/<MedioPagoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MedioPagoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
