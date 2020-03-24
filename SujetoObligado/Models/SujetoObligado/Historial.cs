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
                cmd.CommandText = "Qry_Persona_SEEK_xIdUsuario";
                cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = idUsuario;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    try
                    {
                        var cuit = Convert.ToString(dt.Rows[i]["Cuit"]);
                        personaAux = lista.Find(x => x.Cuit == cuit);
                        if (personaAux == null)
                        {
                            personaAux = new PersonaSO();
                            personaAux.Cuit = cuit;
                            personaAux.FechaModificacion = Convert.ToDateTime(dt.Rows[i]["FechaModificacion"]);
                            lista.Add(personaAux);
                        }

                        DetallePersonaSO detalleAux = new DetallePersonaSO();
                        detalleAux.Tipo = Convert.ToString(dt.Rows[i]["Tipo"]);
                        detalleAux.Mensaje = Convert.ToString(dt.Rows[i]["Mensaje"]);
                        detalleAux.Estado = Convert.ToBoolean(dt.Rows[i]["Estado"]);
                        

                        personaAux.Detalle.Add(detalleAux);
                    }
                    catch (Exception e)
                    {
                        //TODO: EXCEPCION DE DETALLE NULL POR NO SER SUJETO OBLIGADO
                    }
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