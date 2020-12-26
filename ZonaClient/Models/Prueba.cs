using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZonaClient.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Prueba
    {
            public int Comercio_codigo { get; set; }
            public string Comercio_nombre { get; set; }
            public string Comercio_nit { get; set; }
            public string Comercio_direccion { get; set; }
            public string Trans_codigo { get; set; }
            public int Trans_medio_pago { get; set; }
            public int Trans_estado { get; set; }
            public float Trans_total { get; set; }
            public string Trans_fecha { get; set; }
            public string Trans_concepto { get; set; }
            public string Usuario_identificacion { get; set; }
            public string Usuario_nombre { get; set; }
            public string Usuario_email { get; set; }
    }
}
