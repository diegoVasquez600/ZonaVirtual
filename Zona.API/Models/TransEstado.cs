using System.Collections.Generic;

#nullable disable

namespace Zona.API.Models
{
    public partial class TransEstado
    {
        public TransEstado()
        {
            Transaccions = new HashSet<Transaccion>();
        }

        public int EstadoCodigo { get; set; }
        public string Estado { get; set; }

        public virtual ICollection<Transaccion> Transaccions { get; set; }
    }
}
