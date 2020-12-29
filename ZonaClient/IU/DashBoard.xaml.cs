using System.Windows;

namespace ZonaClient.IU
{
    /// <summary>
    /// Lógica de interacción para DashBoard.xaml
    /// </summary>
    public partial class DashBoard : Window
    {
        private readonly int action;

        public DashBoard(int _action)
        {
            InitializeComponent();
            ValidateUser();
            action = _action;
        }

        #region Methods
        private void ValidateUser()
        {
            if (action == 1)
            {
                PagosButton.Visibility = Visibility.Visible;
            }
            else if (action == 2)
            {
                MisGananciasButton.Visibility = Visibility.Visible;
                MisTransaccionesButton.Visibility = Visibility.Visible;
            }
        }

        #endregion

        #region Events

        private void PagosButton_Click(object sender, RoutedEventArgs e)
        {
            if (action == 1)
            {
                var usuarioIdentificacion = Application.Current.Properties["usuarioIdentificacion"].ToString();
                frame.Content = new MisPagos(usuarioIdentificacion);
            }
            else
                return;
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
