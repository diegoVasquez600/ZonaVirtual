using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ZonaClient.Models;
using ZonaClient.Services;

namespace ZonaClient.ViewModels
{
    public class MisPagosViewModel : BaseViewModel
    {
        #region Fields
        DataStorePago dataStorePago = new DataStorePago();
        private readonly string userIdentificacion;
        Usuario usuario = new Usuario();
        readonly IEnumerable<Pago> pagos;
        #endregion


        #region Properties
        /// <summary>
        /// Propertie PagosCollection is the collection of data from the response of Pagos
        /// </summary>
        public ObservableCollection<Pago> PagosCollection { get; set; }
        #endregion

        public MisPagosViewModel(string _userIdentificacion)
        {
            userIdentificacion = _userIdentificacion;
            _ = CargarPagosAsync(userIdentificacion);

        }

        private async Task<ObservableCollection<Pago>> CargarPagosAsync(string _userIdentificacion)
        {
            PagosCollection = new ObservableCollection<Pago>();
            usuario.UsuarioIdentificacion = _userIdentificacion;
            var response = await dataStorePago.GetPagosUsuario(usuario);
            foreach (var pago in response)
            {
                PagosCollection.Add(new Pago()
                {
                    Trans_codigo = pago.Trans_codigo,
                    Trans_fecha = pago.Trans_fecha,
                    Trans_concepto = pago.Trans_concepto,
                    Trans_total = pago.Trans_total,
                    usuario_identificacion = pago.usuario_identificacion,
                    nombre_medio_pago = pago.nombre_medio_pago,
                    estado = pago.estado
                });
            }
            return PagosCollection;
        }
    }
}
