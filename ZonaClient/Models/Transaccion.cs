using System;
using System.Collections.Generic;

#nullable disable

namespace ZonaClient.Models
{
    public partial class Transaccion
    {
        public int TransCodigo { get; set; }
        public int TransMedioPago { get; set; }
        public int TransEstado { get; set; }
        public DateTime TransFecha { get; set; }
        public string TransConcepto { get; set; }
        public int IdUsuario { get; set; }
        public int ComercioCodigo { get; set; }
        public double TransTotal { get; set; }

        public virtual Comercio ComercioCodigoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual TransEstado TransEstadoNavigation { get; set; }
        public virtual TransMedioPago TransMedioPagoNavigation { get; set; }
    }
}
