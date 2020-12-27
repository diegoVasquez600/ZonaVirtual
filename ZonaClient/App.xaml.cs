using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ZonaClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// ZonaBackendUrl 
        /// </summary>
        public static string ZonaPruebaUrl = "http://pbiz.zonavirtual.com/api/";
        public static string AzureBackendUrl = "https://zonaapi.azurewebsites.net/api/";
        public static string LocalBackendUrl = "https://localhost:44367/api/";

    }
}
