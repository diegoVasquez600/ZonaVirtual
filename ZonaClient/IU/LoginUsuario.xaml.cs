using System.Windows;

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
