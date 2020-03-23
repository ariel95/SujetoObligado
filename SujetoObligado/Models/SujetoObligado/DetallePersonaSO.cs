using SujetoObligado.Models.API_Externa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SujetoObligado.Models.SujetoObligado
{
    public class DetallePersonaSO
    {
        private int id;
        private int idPersona;
        private string tipo;
        private bool estado;
        private string mensaje;
        private DateTime fechaCreacion;
        private DateTime fechaModificacion;
        private DateTime fechaAlta;

        public DetallePersonaSO() { 
        
        }
        public DetallePersonaSO(SujetoObligadoUIF so_uif)
        {
            this.Tipo = so_uif.TipoSujeto;
            this.Mensaje = so_uif.Mensaje;
            this.Estado = so_uif.Estado == "Habilitado";
            this.FechaCreacion = DateTime.Parse(so_uif.FechaCreacion);
        }

        public int Id { get => id; set => id = value; }
        public int IdPersona { get => idPersona; set => idPersona = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public bool Estado { get => estado; set => estado = value; }
        public string Mensaje { get => mensaje; set => mensaje = value; }
        public DateTime FechaCreacion { get => fechaCreacion; set => fechaCreacion = value; }
        public DateTime FechaModificacion { get => fechaModificacion; set => fechaModificacion = value; }
        public DateTime FechaAlta { get => fechaAlta; set => fechaAlta = value; }
    }
}