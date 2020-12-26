using System;
using System.Collections.Generic;

#nullable disable

namespace Zona.API.Models
{
     /// <summary>
     /// 
     /// </summary>
    public partial class Transaccion
    {
        /// <summary>
        /// 
        /// </summary>
        public int TransCodigo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int TransMedioPago { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int TransEstado { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime TransFecha { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TransConcepto { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? IdUsuario { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? ComercioCodigo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double? TransTotal { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Comercio ComercioCodigoNavigation { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Usuario IdUsuarioNavigation { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual TransEstado TransEstadoNavigation { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual TransMedioPago TransMedioPagoNavigation { get; set; }
    }
}
