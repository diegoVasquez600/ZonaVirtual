using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ZonaClient.IU;
using ZonaClient.Models;
using ZonaClient.Services;
using ZonaClient.ViewModels;

namespace ZonaClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Constructor calls the Method <c>InitializeComponent()</c>
        /// </summary>
        #region Fields
        DataStoreUsuario dataStoreUsuario = new DataStoreUsuario();
        DataStoreComercio dataStoreComercio = new DataStoreComercio();
        Usuario usuario = new Usuario();
        Comercio comercio = new Comercio();
        #endregion
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        #region Events
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Transaction transaction = new Transaction();
            transaction.ShowDialog();
        }
        #endregion

        private void cmbTipo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (itemUsr.IsSelected)
            {
                panelDocumento.Visibility = Visibility.Visible;
                lblDocumento.Content = "Ingrese su Identificacion";
            }
            else if (itemCom.IsSelected)
            {
                panelDocumento.Visibility = Visibility.Visible;
                lblDocumento.Content = "Ingrese su NIT";
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void btnVld_Click(object sender, RoutedEventArgs e)
        {
            ValidarUsuarioAsync();
        }

        private async void ValidarUsuarioAsync()
        {
            if (itemUsr.IsSelected)
            {
                if (txtDocumento.Text.ToString() != "")
                {
                    usuario.UsuarioIdentificacion = txtDocumento.Text;
                    var response = await dataStoreUsuario.VerificateUsuarioAsync(usuario);
                    if (response == "1")
                    {
                        LoginUsuario loginUsuario = new LoginUsuario(txtDocumento.Text.ToString());
                        loginUsuario.ShowDialog();
                    }
                    else if (response == "0")
                        MessageBox.Show($"Al parecer el número de documento {txtDocumento.Text} no se encuentra en nuestra Base de datos", "Upps, No te encuentro", MessageBoxButton.OK);
                    else if (response == "2")
                    {
                        MessageBox.Show($"Te encontramos en la Base de datos, a continuación crea una contraseña", "Upps, Debes Crear una Contraseña", MessageBoxButton.OK);
                        Registro registro = new Registro(1, txtDocumento.Text);
                        registro.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Debes Ingresar tu Número de Documento", "Upps, Falto algo", MessageBoxButton.OK);
                }
            }
            else if (itemCom.IsSelected)
            {
                if (txtDocumento.Text.ToString() != "")
                {
                    comercio.ComercioNit = txtDocumento.Text;
                    var response = await dataStoreComercio.VerificateComercioAsync(comercio);
                    if (response == "1")
                    {
                        LoginComercio loginComercio = new LoginComercio(txtDocumento.Text.ToString());
                        loginComercio.ShowDialog();
                    }
                    else if (response == "0")
                        MessageBox.Show($"Al parecer el NIT {txtDocumento.Text} no se encuentra en nuestra Base de datos", "Upps, No te encuentro", MessageBoxButton.OK);
                    else if (response == "2")
                    {
                        MessageBox.Show($"Te encontramos en la Base de datos, a continuación crea una contraseña", "Upps, Debes Crear una Contraseña", MessageBoxButton.OK);
                        Registro registro = new Registro(2, txtDocumento.Text);
                        registro.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Debes Ingresar el NIT de tu Comercio", "Upps, Falto algo", MessageBoxButton.OK);
                }
            }
        }
    }
}
