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
    /// Lógica de interacción para Registro.xaml
    /// </summary>
    public partial class Registro : Window
    {
        #region Fields
        // 1 for Usuario, 2 for Comercio
        private readonly int _action;
        private readonly string _documento;
        DataStoreUsuario dataStoreUsuario = new DataStoreUsuario();
        Usuario usuario;
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
            }else if(_action == 2)
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
                    if(response == "1")
                    {
                        MessageBox.Show($"Registrado Correctamente, ya puedes iniciar sesión", "Felicitaciones", MessageBoxButton.OK);
                        Close();
                    }
                 }
                else if (_action == 2)
                {

                }
            }
            else
            {
                MessageBox.Show($"Al parecer las contraseñas no coninciden", "Upps, Un problema de Contraseña", MessageBoxButton.OK);
            }
        }
    }
}
