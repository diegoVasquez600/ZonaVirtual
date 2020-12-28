using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ZonaClient.Models;
using ZonaClient.Services;

namespace ZonaClient.IU
{
    /// <summary>
    /// Lógica de interacción para NuevaTransaccion.xaml
    /// </summary>
    public partial class NuevaTransaccion : Window
    {
        #region Fields
        DataStoreTransaccion dataStoreTransaccion;
        Transaccion transaccion;
        private readonly string usuario;
        #endregion
        public NuevaTransaccion(string usuario)
        {
            InitializeComponent();
            dataStoreTransaccion = new DataStoreTransaccion();
            FillData();
            this.usuario = usuario;
        }

        private void FillData()
        {
            List<CmbModel> mediosPago = new List<CmbModel>();
            mediosPago.Add(
            new CmbModel()
            {
                Text = "PSE",
                Value = 29
            });
            mediosPago.Add(new CmbModel()
            {
                Text = "Tarjeta de Credito",
                Value = 32
            });
            mediosPago.Add(new CmbModel()
            {
                Text = "Gana",
                Value = 41
            });
            mediosPago.Add(new CmbModel()
            {
                Text = "Caja",
                Value = 42
            });
            foreach (var item in mediosPago)
            {
                CmbMedioPago.Items.Add(item);
            }
        }

        private void buttonPagar_Click(object sender, RoutedEventArgs e)
        {
            PagoAsync();
        }

        private async void PagoAsync()
        {
            if (!txtCodigoComercio.Text.Equals(""))
            {
                Random rnd = new Random();
                int[] estadoTransaccion = new int[5];
                estadoTransaccion[0] = 1;
                estadoTransaccion[1] = 999;
                estadoTransaccion[2] = 1000;
                estadoTransaccion[3] = 1001;
                transaccion = new Transaccion
                {
                    TransFecha = Convert.ToString(DateTime.Now),
                    ComercioCodigo = Convert.ToInt32(txtCodigoComercio.Text),
                    TransMedioPago = Convert.ToInt32((CmbMedioPago.SelectedValue as CmbModel).Value.ToString()),
                    TransCodigo = rnd.Next().ToString(),
                    TransEstado = estadoTransaccion[rnd.Next(0, 3)],
                    UsuarioIdentificacion = usuario,
                    TransConcepto = txtConcepto.Text,
                    TransTotal = Convert.ToDouble(txtMonto.Text)
                };

                var response = await dataStoreTransaccion.AddTransaccionAsync(transaccion);
                MessageBox.Show(response, "Respuesta de tu Transaccion", MessageBoxButton.OK);
                Close();
            }
            else
            {
                MessageBox.Show("Debes ingresar un Codigo de Comercio para continuar", "Te falto algo", MessageBoxButton.OK);
            }
        }
    }
}
