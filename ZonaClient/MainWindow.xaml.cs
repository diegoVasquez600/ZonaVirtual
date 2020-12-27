using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ZonaClient.IU;
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
            if (itemUsr.IsSelected)
            {
                if (txtDocumento.Text.ToString() != "")
                {
                    LoginUsuario loginUsuario = new LoginUsuario(txtDocumento.Text.ToString());
                    loginUsuario.ShowDialog();
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
                    LoginComercio loginComercio = new LoginComercio(txtDocumento.Text.ToString());
                    loginComercio.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Debes Ingresar el NIT de tu Comercio", "Upps, Falto algo", MessageBoxButton.OK);
                }
            }
        }
    }
}
