using System.Windows;
using System.Windows.Controls;
using ZonaClient.Models;
using ZonaClient.ViewModels;

namespace ZonaClient.IU
{
    /// <summary>
    /// Lógica de interacción para MisPagos.xaml
    /// </summary>
    public partial class MisPagos : Page
    {
        private readonly string usuario;

        public MisPagos(string _usuario)
        {
            InitializeComponent();
            DataContext = new MisPagosViewModel(_usuario);
            usuario = _usuario;
        }

        public Usuario Usuario { get; }

        private void nuevoPagoButton_Click(object sender, RoutedEventArgs e)
        {
            NuevaTransaccion nuevaTransaccion = new NuevaTransaccion(usuario);
            nuevaTransaccion.ShowDialog();
        }
    }
}
