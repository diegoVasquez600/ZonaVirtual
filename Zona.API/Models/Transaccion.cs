using System;
using System.Collections.Generic;

#nullable disable

namespace Zona.API.Models
{
    public partial class Transaccion
    {
        public int TransId { get; set; }
        public string TransCodigo { get; set; }
        public int TransMedioPago { get; set; }
        public int TransEstado { get; set; }
        public string TransFecha { get; set; }
        public string TransConcepto { get; set; }
        public string UsuarioIdentificacion { get; set; }
        public int ComercioCodigo { get; set; }
        public double TransTotal { get; set; }

        public virtual Comercio ComercioCodigoNavigation { get; set; }
        public virtual TransEstado TransEstadoNavigation { get; set; }
        public virtual TransMedioPago TransMedioPagoNavigation { get; set; }
    }
}
