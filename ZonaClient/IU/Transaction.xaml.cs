using System.Windows;
using ZonaClient.ViewModels;

namespace ZonaClient.IU
{
    /// <summary>
    /// Interaction logic for Transaction.xaml
    /// </summary>
    public partial class Transaction : Window
    {
        /// <summary>
        /// Constructor Transaction
        /// </summary>
        /// <remarks>
        /// Initialize the Method InitializeComponent, and the BindingContext for the ViewModel TransactionViewModel
        /// </remarks>
        public Transaction()
        {
            InitializeComponent();
            DataContext = new TransactionViewModel();
        }
    }
}
