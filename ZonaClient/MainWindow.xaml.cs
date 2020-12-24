﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ZonaClient.IU;

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
        }

        #region Events
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Transaction transaction = new Transaction();
            transaction.ShowDialog();
        } 
        #endregion
    }
}
