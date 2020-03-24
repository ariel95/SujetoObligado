using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SujetoObligado.Services
{
    public class Connection
    {
        public SqlConnection conexion = new SqlConnection();

        public SqlConnection ObtenerConexion(string connection)
        {
            conexion = new SqlConnection(connection);
            try
            {
                conexion.Open();
                return conexion;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DescargarConexion()
        {
            conexion.Dispose();
            return true;
        }

        internal SqlConnection ObtenerConexion(object obtenerConexionSujetoObligado)
        {
            throw new NotImplementedException();
        }
    }
}