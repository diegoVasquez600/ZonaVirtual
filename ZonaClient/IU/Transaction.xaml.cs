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
