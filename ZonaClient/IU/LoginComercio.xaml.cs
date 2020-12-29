using Newtonsoft.Json;
using System;
using System.Windows;
using ZonaClient.Models;
using ZonaClient.Services;

namespace ZonaClient.IU
{
    /// <summary>
    /// Lógica de interacción para LoginComercio.xaml
    /// </summary>
    public partial class LoginComercio : Window
    {
        #region Fields
        DataStoreComercio dataStoreComercio = new DataStoreComercio();
        Comercio comercio;
        #endregion

        private readonly string _documento;
        public LoginComercio(string documento)
        {
            InitializeComponent();
            _documento = documento;
            FillInfo();
        }

        private void FillInfo()
        {
            txtDocumento.Text = _documento;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            LoginComercioAsync();
        }

        private async void LoginComercioAsync()
        {
            comercio = new Comercio()
            {
                ComercioNit = txtDocumento.Text,
                ComercioPassword = txtPassword.Password
            };
            var response = await dataStoreComercio.LoginComercioAsync(comercio);
            if (response == "2")
                MessageBox.Show("Lo siento, Pusiste una Contraseña Incorrecta", "Upps, Problema de Contraseñas");
            else if (response == "0")
            {
                MessageBox.Show($"Usuario con Identificacion número {comercio.ComercioNit} No encontrado", "Upps, Problema de Usuario");
            }
            else
            {
                try
                {
                    comercio = JsonConvert.DeserializeObject<Comercio>(response);
                    App.Current.Properties.Clear();
                    App.Current.Properties.Add("comercio", comercio);
                    App.Current.Properties.Add("comercioNit", comercio.ComercioNit);
                    Application.Current.MainWindow.Close();
                    Application.Current.MainWindow = new DashBoard(2);
                    Application.Current.MainWindow.Show();
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lo sentimos a ocurrido un problema inesperado\n {ex.Message}", "Upps, Algun error");
                }
            }
        }
    }
}
