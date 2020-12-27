using System.Windows;

namespace ZonaClient.IU
{
    /// <summary>
    /// Lógica de interacción para LoginComercio.xaml
    /// </summary>
    public partial class LoginComercio : Window
    {

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
    }
}
