using Newtonsoft.Json;
using System;
using System.Windows;
using ZonaClient.Models;
using ZonaClient.Services;

namespace ZonaClient.IU
{
    /// <summary>
    /// Lógica de interacción para LoginUsuario.xaml
    /// </summary>
    public partial class LoginUsuario : Window
    {
        #region Fields
        private readonly string _documento;
        private DataStoreUsuario dataStoreUsuario = new DataStoreUsuario();
        private Usuario usuario;
        #endregion

        public LoginUsuario(string documento)
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
            LoginAsync();
        }

        private async void LoginAsync()
        {
            usuario = new Usuario
            {
                UsuarioIdentificacion = txtDocumento.Text,
                UsuarioPassword = txtPassword.Password
            };
            var response = await dataStoreUsuario.LoginUsuarioAsync(usuario);
            if (response == "2")
                MessageBox.Show("Lo siento, Pusiste una Contraseña Incorrecta", "Upps, Problema de Contraseñas");
            else if (response == "0")
            {
                MessageBox.Show($"Usuario con Identificacion número {usuario.UsuarioIdentificacion} No encontrado", "Upps, Problema de Usuario");
            }
            else
            {
                try
                {
                    usuario = JsonConvert.DeserializeObject<Usuario>(response);
                    App.Current.Properties.Clear();
                    App.Current.Properties.Add("usuario", usuario);
                    App.Current.Properties.Add("usuarioIdentificacion", usuario.UsuarioIdentificacion);
                    Application.Current.MainWindow.Close();
                    Application.Current.MainWindow = new DashBoard(1);
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
