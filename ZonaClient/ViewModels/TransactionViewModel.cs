using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using ZonaClient.Models;
using ZonaClient.Services;

namespace ZonaClient.ViewModels
{

    /// <summary>
    /// Class TransactionViewModel
    /// </summary>
    /// <remarks>
    /// Is the ViewModel for Transaction.xaml
    /// </remarks>
    public class TransactionViewModel : BaseViewModel
    {
        #region Fields
        DataStorePrueba dataStorePrueba = new DataStorePrueba();
        DataStoreComercio dataStoreComercio = new DataStoreComercio();
        DataStoreUsuario dataStoreUsuario = new DataStoreUsuario();
        DataStoreTransaccion dataStoreTransaccion = new DataStoreTransaccion();
        #endregion

        #region Properties
        /// <summary>
        /// Propertie PruebaCollection is the collection of data from the response of Zona prueba Backend
        /// </summary>
        public ObservableCollection<Prueba> PruebaCollection { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor TransactionViewModel 
        /// </summary>
        /// <remarks>
        /// Initialize the Method 
        /// </remarks>
        public TransactionViewModel()
        {
            _ = CargarDataAsync();
        }

        #endregion

        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// if the execution is correct returns and ObservableCollection of the model Prueba else returns Null
        /// </returns>
        private async Task<ObservableCollection<Prueba>> CargarDataAsync()
        {
            var response = await dataStorePrueba.GetDataAsync();
            await SaveDataAsync(response);
            return PruebaCollection;
        }

        private async Task SaveDataAsync(IEnumerable<Prueba> response)
        {
            try
            {
                Comercio comercio;
                Usuario usuario;
                Transaccion transaccion;
                foreach (var dt in response)
                {
                    comercio = new Comercio()
                    {
                        ComercioCodigo = dt.Comercio_codigo,
                        ComericoNombre = dt.Comercio_nombre,
                        ComercioNit = dt.Comercio_nit,
                        ComercioDireccion = dt.Comercio_direccion,
                    };

                    usuario = new Usuario()
                    {
                        UsuarioNombre = dt.Usuario_nombre,
                        UsuarioIdentificacion = dt.Usuario_identificacion,
                        UsuarioEmail = dt.Usuario_email,
                    };

                    transaccion = new Transaccion()
                    {
                        TransCodigo = dt.Trans_codigo,
                        TransEstado = dt.Trans_estado,
                        ComercioCodigo = dt.Comercio_codigo,
                        UsuarioIdentificacion = dt.Usuario_identificacion,
                        TransConcepto = dt.Trans_concepto,
                        TransFecha = dt.Trans_fecha,
                        TransMedioPago = dt.Trans_medio_pago,
                        TransTotal = dt.Trans_total
                    };

                    var messageCm = await dataStoreComercio.AddComercioAsync(comercio);
                    var messageUsr = await dataStoreUsuario.AddUsuarioAsync(usuario);
                    var messageTsn = await dataStoreTransaccion.AddTransaccionAsync(transaccion);
                    Debug.WriteLine($"Insertar Dato en ZonaDB via Zona.API\n" +
                        $"{messageCm}\n" +
                        $"{messageUsr}\n" +
                        $"{messageTsn}\n");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        #endregion
    }
}
