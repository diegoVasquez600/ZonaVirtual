using System.Collections.Generic;

#nullable disable

namespace Zona.API.Models
{
    public partial class TransMedioPago
    {
        public TransMedioPago()
        {
            Transaccions = new HashSet<Transaccion>();
        }

        public int MedioPagoCodigo { get; set; }
        public string NombreMedioPago { get; set; }

        public virtual ICollection<Transaccion> Transaccions { get; set; }
    }
}
