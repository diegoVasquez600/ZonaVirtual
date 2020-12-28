using Newtonsoft.Json;
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

namespace ZonaClient.IU
{
    /// <summary>
    /// Lógica de interacción para DashBoard.xaml
    /// </summary>
    public partial class DashBoard : Window
    {
        private readonly int _action;

        public DashBoard(int action)
        {
            InitializeComponent();
            ValidateUser();
            _action = action;
        }

        #region Methods
        private void ValidateUser()
        {
            if (_action ==1)
            {
                PagosButton.Visibility = Visibility.Visible;
            }
        }

        #endregion

        #region Events

        private void PagosButton_Click(object sender, RoutedEventArgs e)
        {
            var usuarioIdentificacion = Application.Current.Properties["usuarioIdentificacion"].ToString();
            frame.Content = new MisPagos(usuarioIdentificacion);
        }

        #endregion

        private void MisGananciasButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MisTransaccionesButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
