using System;
using System.Collections.Generic;

#nullable disable

namespace Zona.API.Models
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Comercio
    {
        /// <summary>
        /// 
        /// </summary>
        public Comercio()
        {
            Transaccions = new HashSet<Transaccion>();
        }
        /// <summary>
        /// 
        /// </summary>
        public int ComercioCodigo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ComericoNombre { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ComercioNit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ComercioDireccion { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ComercioPassword { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ComercioSalt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<Transaccion> Transaccions { get; set; }
    }
}
