using System;
using System.Collections.Generic;

#nullable disable

namespace ZonaClient.Models
{
    public partial class Comercio
    {
        public Comercio()
        {
            Transaccions = new HashSet<Transaccion>();
        }

        public int ComercioCodigo { get; set; }
        public string ComericoNombre { get; set; }
        public string ComercioNit { get; set; }
        public string ComercioDireccion { get; set; }
        public string ComercioPassword { get; set; }
        public string ComercioSalt { get; set; }

        public virtual ICollection<Transaccion> Transaccions { get; set; }
    }
}
