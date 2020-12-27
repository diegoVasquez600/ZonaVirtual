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
    /// Lógica de interacción para LoginUsuario.xaml
    /// </summary>
    public partial class LoginUsuario : Window
    {
        private readonly string _documento;

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
    }
}
