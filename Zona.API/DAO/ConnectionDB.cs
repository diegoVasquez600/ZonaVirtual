using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.IO;

namespace Zona.API.DAO
{
    class ConnectionDB
    {
        string configurationBuilder = new ConfigurationBuilder()
            .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"), false)
            .Build().GetSection("ConnectionStrings:ZonaDB").Value;

        public SqlConnection AbrirConection()
        {
            SqlConnection conection = new SqlConnection(configurationBuilder);
            if (conection.State == ConnectionState.Closed)
                conection.Open();
            return conection;
        }
        public SqlConnection CerrarConection()
        {
            SqlConnection conection = new SqlConnection(configurationBuilder);
            if (conection.State == ConnectionState.Open)
                conection.Close();
            return conection;
        }
    }
}
