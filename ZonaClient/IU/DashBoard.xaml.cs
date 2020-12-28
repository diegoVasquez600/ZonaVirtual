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

namespace ZonaClient.IU
{
    /// <summary>
    /// Lógica de interacción para DashBoard.xaml
    /// </summary>
    public partial class DashBoard : Window
    {
        public DashBoard()
        {
            InitializeComponent();
            ValidateUser();
        }

        #region Methods
        private void ValidateUser()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Events

        private void PagosButton_Click(object sender, RoutedEventArgs e)
        {

        }

        #endregion

    }
}
