using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Zona.API.DAO
{
    public class PagoDAO
    {
        #region fields
        private ConnectionDB connection = new ConnectionDB();
        SqlDataReader Reader;
        DataTable table = new DataTable();
        SqlCommand command = new SqlCommand(); 
        #endregion
        public DataTable GetPagosUsuario(string _usuarioIdentificacion)
        {
            command.Connection = connection.AbrirConection();
            command.CommandText = "PagosUsuario";
            command.Parameters.AddWithValue("@usuarioIdentificacion", _usuarioIdentificacion);
            command.CommandType = CommandType.StoredProcedure;
            Reader = command.ExecuteReader();
            table.Load(Reader);
            Reader.Close();
            connection.CerrarConection();
            return table;
        }

        public DataTable GetPagosComercio(int comercioCodigo)
        {
            command.Connection = connection.AbrirConection();
            command.CommandText = "PagosComercio";
            command.Parameters.AddWithValue("@comercio_codigo", comercioCodigo);
            command.CommandType = CommandType.StoredProcedure;
            Reader = command.ExecuteReader();
            table.Load(Reader);
            Reader.Close();
            connection.CerrarConection();
            return table;
        }
    }
}
