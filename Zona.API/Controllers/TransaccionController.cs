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
    ///  Controller Transaccion
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TransaccionController : ControllerBase
    {
        ZonaDBContext dbContext = new ZonaDBContext();
        IEnumerable<Transaccion> transacciones = new List<Transaccion>();
        /// <summary>
        /// Method GetTransacciones
        /// </summary>
        /// <returns>
        /// If the execution is correct returns all the list of transactions
        /// </returns>
        /// <remarks>
        /// Usage GET: api/Transaccion/GetTransacciones
        /// </remarks>
        [HttpGet]
        [Route("GetTransacciones")]
        public IEnumerable<Transaccion> GetTransacciones()
        {
            transacciones = dbContext.Transaccions.ToList();
            return transacciones;
        }
        /// <summary>
        /// Method GetTransaccion
        /// </summary>
        /// <param name="value">
        /// Recieve the Transaccion Model
        /// </param>
        /// <returns>
        /// the specific Transaccion
        /// </returns>
        /// <remarks>
        /// Usage GET api/Transaccion/GetTransaccion
        /// </remarks>
        [HttpGet]
        [Route("GetTransaccion")]
        public string GetTransaccion([FromBody] Transaccion value)
        {
            try
            {
                if (dbContext.Transaccions.Any(tsn => tsn.TransId.Equals(value.TransId)))
                {
                    var transaccion = dbContext.Transaccions.Find(value.TransId);
                    return JsonConvert.SerializeObject(transaccion);
                }
                else
                {
                    return $"El comercio con codigo {value.ComercioCodigo} no se encuentra";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
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
                    return $"La transaccion número {value.TransCodigo} ya ha sido insertada anteriormente";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// Method UpdateTransaccion
        /// </summary>
        /// <param name="value">Recieve the Transaccion Model</param>
        /// <returns>if is correct returns a message else returns an exception</returns>
        /// <remarks>
        /// Usage PUT api/Transaccion/UpdateTransaccion
        /// </remarks>
        [HttpPut]
        [Route("UpdateTransaccion")]
        public string UpdateTransaccion([FromBody] Transaccion value)
        {
            try
            {
                if (dbContext.Transaccions.Any(tsn => tsn.TransCodigo.Equals(value.TransCodigo)))
                {
                    dbContext.Transaccions.Update(value);
                    dbContext.SaveChanges();
                    return $"La transacción {value.TransCodigo} actualizada correctamente";
                }
                else
                {
                    return $"La transacción {value.TransCodigo} no se encuentra registrada";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // 
        /// <summary>
        /// Method DeleteTransaccion
        /// </summary>
        /// <param name="value">Recieve the Transacction Model</param>
        /// <remarks>
        /// Usage DELETE api/Transaccion/DeleteTransaccion
        /// </remarks>
        [HttpDelete]
        [Route("DeleteTransaccion")]
        public void DeleteTransaccion([FromBody] Transaccion value)
        {
            if (dbContext.Transaccions.Any(tsn => tsn.TransCodigo.Equals(value.TransCodigo)))
            {
                var delete = dbContext.Transaccions.Find(value.TransId);
                dbContext.Transaccions.Remove(delete);
                dbContext.SaveChanges();
            }
        }
    }
}
