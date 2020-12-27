using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Zona.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Zona.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ComercioController : ControllerBase
    {
        ZonaDBContext dbContext = new ZonaDBContext();
        IEnumerable<Comercio> comercios;
        /// <summary>
        /// Gets all the Comercio list
        /// </summary>
        /// <returns>
        /// if the execution is correct returns the IEnumerable of Comercio
        /// </returns>
        // GET: api/<ComercioController>
        [HttpGet]
        [Route("GetComercios")]
        public IEnumerable<Comercio> GetComercios()
        {
            comercios = new List<Comercio>();
            comercios = dbContext.Comercios.ToList();
            return comercios;
        }

        /// <summary>
        /// Get the specific Comercio
        /// </summary>
        /// <param name="value">
        /// Recieve comercio model
        /// </param>
        /// <returns></returns>
        /// <remarks>
        /// Usage GET api/Comercio/GetComercio
        /// </remarks>
        [HttpGet]
        [Route("GetComercio")]
        public string GetComercio([FromBody] Comercio value)
        {
            try
            {
                if (dbContext.Comercios.Any(cm => cm.ComercioCodigo.Equals(value.ComercioCodigo)))
                {
                    var comercio = dbContext.Comercios.Find(value.ComercioCodigo);
                    return JsonConvert.SerializeObject(comercio);
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
        /// Insert a new Comercio to database
        /// </summary>
        /// <param name="value">
        /// Recieve comercio model
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
                if (!dbContext.Comercios.Any(cm => cm.ComercioCodigo.Equals(value.ComercioCodigo)))
                {
                    dbContext.Comercios.Add(value);
                    dbContext.SaveChanges();
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
        /// <summary>
        /// Update a Comercio registry on Comercio
        /// </summary>
        /// <param name="value">
        /// Recieve comercio model
        /// </param>
        /// <returns>
        /// if the execution is correct and the Comercio Exits return a message if the update was correct or not else return an exception
        /// </returns>
        /// <remarks>
        /// Using PUT api/Comercio/UpdateComercio
        /// </remarks>
        [HttpPut]
        [Route("UpdateComercio")]
        public string UpdateComercio([FromBody] Comercio value)
        {
            try
            {
                if (dbContext.Comercios.Any(cm => cm.ComercioCodigo.Equals(value.ComercioCodigo)))
                {
                    dbContext.Comercios.Update(value);
                    dbContext.SaveChanges();
                    return $"El Comercio {value.ComericoNombre} actualizado correctamente";
                }
                else
                {
                    return $"El Comercio {value.ComericoNombre} no se encuentra registrado";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// Delete the specific Comercio
        /// </summary>
        /// <param name="value">
        /// Recieve comercio model
        /// </param>
        /// <remarks>
        /// Using DELETE api/Comercio/DeleteComercio
        /// </remarks>
        [HttpDelete]
        [Route("DeleteComercio")]
        public void DeleteComercio([FromBody] Comercio value)
        {
            if (dbContext.Comercios.Any(cm => cm.ComercioCodigo.Equals(value.ComercioCodigo)))
            {
                var deleteComercio = dbContext.Comercios.Find(value.ComercioCodigo);
                dbContext.Comercios.Remove(deleteComercio);
                dbContext.SaveChanges();
            }
        }
    }
}
