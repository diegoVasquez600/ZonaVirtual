using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
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
            PruebaCollection = new ObservableCollection<Prueba>();
            var response = await dataStorePrueba.GetDataAsync();
            
            foreach(var data in response)
            {
                PruebaCollection.Add(new Prueba 
                { 
                    ComercioCodigo = data.ComercioCodigo,
                    ComercioNombre = data.ComercioNombre,
                    ComercioNit = data.ComercioNit,
                    ComercioDireccion = data.ComercioDireccion,
                    TransCodigo = data.TransCodigo,
                    TransMedioPago = data.TransMedioPago,
                    TransEstado = data.TransEstado,
                    TransTotal = data.TransTotal,
                    TransFecha = data.TransFecha,
                    TransConcepto = data.TransConcepto,
                    UsuarioIdentificacion = data.UsuarioIdentificacion,
                    UsuarioNombre = data.UsuarioNombre,
                    UsuarioEmail = data.UsuarioEmail
                });
            }
            return PruebaCollection;
        } 
        #endregion
    }
}
