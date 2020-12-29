using System.Windows;
using ZonaClient.Models;
using ZonaClient.Services;

namespace ZonaClient.IU
{
    /// <summary>
    /// Lógica de interacción para Registro.xaml
    /// </summary>
    public partial class Registro : Window
    {
        #region Fields
        // 1 for Usuario, 2 for Comercio
        private readonly int _action;
        private readonly string _documento;
        DataStoreUsuario dataStoreUsuario = new DataStoreUsuario();
        DataStoreComercio dataStoreComercio = new DataStoreComercio();
        Usuario usuario;
        Comercio comercio;
        #endregion

        public Registro(int action, string documento)
        {
            InitializeComponent();
            _action = action;
            _documento = documento;
            ValidarTipoUsuario();
        }

        private void ValidarTipoUsuario()
        {
            if (_action == 1)
            {
                lblDocumento.Content = "Número de Identificación";
                txtDocumento.Text = _documento;
            }
            else if (_action == 2)
            {
                lblDocumento.Content = "NIT";
                txtDocumento.Text = _documento;
            }
        }

        private void RegistroButton_Click(object sender, RoutedEventArgs e)
        {
            ExecutePutAsync();
        }

        private async void ExecutePutAsync()
        {
            if (txtPassword.Password.Equals(txtPassword2.Password))
            {
                if (_action == 1)
                {
                    usuario = new Usuario()
                    {
                        UsuarioIdentificacion = txtDocumento.Text,
                        UsuarioPassword = txtPassword.Password
                    };
                    var response = await dataStoreUsuario.RegisterUsuarioAsync(usuario);
                    if (response == "1")
                    {
                        MessageBox.Show($"Registrado Correctamente, ya puedes iniciar sesión", "Felicitaciones", MessageBoxButton.OK);
                        Close();
                    }
                }
                else if (_action == 2)
                {
                    comercio = new Comercio()
                    {
                        ComercioNit = txtDocumento.Text,
                        ComercioPassword = txtPassword.Password
                    };
                    var response = await dataStoreComercio.RegisterComercioAsync(comercio);
                    if (response == "1")
                    {
                        MessageBox.Show($"Registrado Correctamente, ya puedes iniciar sesión", "Felicitaciones", MessageBoxButton.OK);
                        Close();
                    }
                    else if (response == "0")
                    {
                        MessageBox.Show($"Por alguna razon no pudimos registrarte, intentalo nuevamente", "Upps, ha ocurrido un error", MessageBoxButton.OK);
                    }
                }
            }
            else
            {
                MessageBox.Show($"Al parecer las contraseñas no coninciden", "Upps, Un problema de Contraseña", MessageBoxButton.OK);
            }
        }
    }
}
