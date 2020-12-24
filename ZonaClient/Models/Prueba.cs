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
        internal int ComercioCodigo { get; set; }
        internal string ComercioNombre { get; set; }
        internal string ComercioNit { get; set; }
        internal string ComercioDireccion { get; set; }
        internal int TransCodigo { get; set; }
        internal int TransMedioPago { get; set; }
        internal int TransEstado { get; set; }
        internal float TransTotal { get; set; }
        internal DateTime TransFecha { get; set; }
        internal string TransConcepto { get; set; }
        internal string UsuarioIdentificacion { get; set; }
        internal string UsuarioNombre { get; set; }
        internal string UsuarioEmail { get; set; }
    }
}
