﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
        DataStoreComercio dataStoreComercio = new DataStoreComercio();
        DataStoreUsuario dataStoreUsuario = new DataStoreUsuario();
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
                    Comercio_codigo = data.Comercio_codigo,
                    Comercio_nombre = data.Comercio_nombre,
                    Comercio_nit = data.Comercio_nit,
                    Comercio_direccion = data.Comercio_direccion,
                    Trans_codigo = data.Trans_codigo,
                    Trans_medio_pago = data.Trans_medio_pago,
                    Trans_estado = data.Trans_estado,
                    Trans_total = data.Trans_total,
                    Trans_fecha = data.Trans_fecha,
                    Trans_concepto = data.Trans_concepto,
                    Usuario_identificacion = data.Usuario_identificacion,
                    Usuario_nombre = data.Usuario_nombre,
                    Usuario_email = data.Usuario_email
                });
                await SaveDataAsync(response);
            }
            return PruebaCollection;
        }

        private async Task SaveDataAsync(IEnumerable<Prueba> response)
        {
            try
            {
                Comercio comercio;
                Usuario usuario;
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

                    var messageCm = await dataStoreComercio.AddComercioAsync(comercio);
                    var messageUsr = await dataStoreUsuario.AddUsuarioAsync(usuario);
                    Debug.WriteLine($"{messageCm}\n" +
                        $"{messageUsr}");
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
