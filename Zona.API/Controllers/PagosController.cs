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
        [HttpGet]
        [Route("GetPagosComercio")]
        public string GetPagosComercio([FromBody] Comercio value)
        {
            var pagosComercio = objDAO.GetPagosComercio(value.ComercioCodigo);
            return JsonConvert.SerializeObject(pagosComercio);
        }

    }
}
