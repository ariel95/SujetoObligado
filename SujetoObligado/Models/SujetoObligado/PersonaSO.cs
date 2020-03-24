using SujetoObligado.Models.API_Externa;
using SujetoObligado.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SujetoObligado.Models.SujetoObligado
{
    public class PersonaSO
    {
        public static Connection objConexion = new Connection();

        private int id;
        private string cuit;
        private string razonSocial;
        private string fechaAlta;
        private List<DetallePersonaSO> detalle; 
        public int Id { get => id; set => id = value; }
        public string Cuit { get => cuit; set => cuit = value; }
        public string RazonSocial { get => razonSocial; set => razonSocial = value; }
        public string FechaAlta { get => fechaAlta; set => fechaAlta = value; }
        public List<DetallePersonaSO> Detalle { get => detalle; set => detalle = value; }

        public PersonaSO() {
            Detalle = new List<DetallePersonaSO>();
        }
        public PersonaSO(List<SujetoObligadoUIF> so_uif) {
            Detalle = new List<DetallePersonaSO>();
            this.Cuit = so_uif.First().Cuit;
            foreach (var item in so_uif) {
                this.Detalle.Add(new DetallePersonaSO(item));
            }
        }

        internal void GuardarConsulta()
        {
            try
            {
                //Guardo en la tabla Persona
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = objConexion.ObtenerConexion(Configuration.ObtenerConexion("SujetoObligado"));
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Qry_Persona_ADD";
                cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = 1; //TODO:Cambiar por usuario real
                cmd.Parameters.Add("@Cuit", SqlDbType.VarChar, 11).Value = this.Cuit;
                cmd.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 100).Value = this.RazonSocial;
                this.Id = (int) cmd.ExecuteScalar();

                //Guardo en la tabla Detalles
                foreach (var item in this.Detalle) {
                    cmd = new SqlCommand();
                    cmd.Connection = objConexion.ObtenerConexion(Configuration.ObtenerConexion("SujetoObligado"));
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Qry_SujetoObligado_ADD";
                    cmd.Parameters.Add("@IdPersona", SqlDbType.Int).Value = this.Id;
                    cmd.Parameters.Add("@Tipo", SqlDbType.VarChar, 255).Value = item.Tipo;
                    cmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = item.Estado;
                    cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 255).Value = item.Mensaje;
                    cmd.Parameters.Add("@FechaCreacion", SqlDbType.DateTime).Value = item.FechaCreacion;
                    cmd.ExecuteScalar();
                }
                
                
                

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