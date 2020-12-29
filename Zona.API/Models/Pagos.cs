namespace Zona.API.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Pagos
    {
        public string Trans_codigo { get; set; }
        public string Trans_fecha { get; set; }
        public string Trans_concepto { get; set; }
        public float Trans_total { get; set; }
        public string usuario_identificacion { get; set; }
        public string nombre_medio_pago { get; set; }
        public string estado { get; set; }
    }
}
