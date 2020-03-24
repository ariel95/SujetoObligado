using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SujetoObligado.Services
{
    public class Configuration
    {
        internal static string ObtenerConexion(string connection)
        {
            //Get connection string from web.config file  
            string con =  ConfigurationManager.ConnectionStrings[connection].ConnectionString;
            return con;
        }
    }
}