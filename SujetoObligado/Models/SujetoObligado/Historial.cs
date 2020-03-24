using SujetoObligado.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SujetoObligado.Models.SujetoObligado
{
    public class Historial
    {

        public static Connection objConexion = new Connection();

        public static List<PersonaSO> Listar(int idUsuario)
        {
            string ultimoCuit = "";
            PersonaSO personaAux = new PersonaSO();
            List<PersonaSO> lista = new List<PersonaSO>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = objConexion.ObtenerConexion(Configuration.ObtenerConexion("SujetoObligado"));
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Qry_SujetoObligado_SEEK";
                cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = idUsuario;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var cuit = Convert.ToString(dt.Rows[i]["Cuit"]);

                    if (ultimoCuit != cuit) {
                        if (ultimoCuit != "") lista.Add(personaAux);
                        personaAux = new PersonaSO();
                        personaAux.Cuit = cuit;
                    }
                    DetallePersonaSO detalleAux = new DetallePersonaSO();
                    detalleAux.Tipo = Convert.ToString(dt.Rows[i]["Tipo"]);
                    detalleAux.Mensaje = Convert.ToString(dt.Rows[i]["Mensaje"]);
                    detalleAux.Estado = Convert.ToBoolean(dt.Rows[i]["Estado"]);

                    personaAux.Detalle.Add(detalleAux);
                    ultimoCuit = cuit;
                    //TODO: Mejorarlo!!! (No funciona con un solo registro)
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objConexion.DescargarConexion();
            }
        }
    }
}