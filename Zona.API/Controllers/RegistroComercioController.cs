using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zona.API.Models;
using Zona.API.Utils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Zona.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroComercioController : ControllerBase
    {
        ZonaDBContext dBContext = new ZonaDBContext();
        /// <summary>
        /// Usage  POST api/RegistroContoller/Verificacion
        /// </summary>
        [HttpPost]
        [Route("Verificacion")]
        public int Verificacion([FromBody] Comercio value)
        {
            if (dBContext.Comercios.Any(cm => cm.ComercioCodigo.Equals(value.ComercioCodigo)))
            {
                var comercio = dBContext.Comercios.Where(cm => cm.ComercioCodigo == value.ComercioCodigo).FirstOrDefault();
                if (comercio.ComercioPassword != null)
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
        public int Registro([FromBody] Comercio value)
        {
            if (dBContext.Comercios.Any(cm => cm.ComercioCodigo.Equals(value.ComercioCodigo)))
            {
                var comercio = dBContext.Comercios.Where(cm => cm.ComercioCodigo == value.ComercioCodigo).FirstOrDefault();
                if (comercio.ComercioPassword != null)
                {
                    return 1;
                }
                else
                {
                    var find = dBContext.Comercios.Find(comercio.ComercioCodigo);
                    find.ComercioSalt = Convert.ToBase64String(Common.GetRandomSalt(16));
                    find.ComercioPassword = Convert.ToBase64String(Common.SaltHashPassword(
                    Encoding.ASCII.GetBytes(value.ComercioPassword), Convert.FromBase64String(find.ComercioSalt)));
                    dBContext.Comercios.Update(find);
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
