using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SujetoObligado.Models.API_Externa
{
	public class SujetoObligadoUIF
	{
		//Example request https://sro.uif.gob.ar/SROAPI/api/sujetoObligado/consulta/30500003193

		private string cuit;
		private string tipoSujeto;
		private string estado;
		private string mensaje;
		private string fechaCreacion;

		public string Cuit { get => cuit; set => cuit = value; }
		public string TipoSujeto { get => tipoSujeto; set => tipoSujeto = value; }
		public string Estado { get => estado; set => estado = value; }
		public string Mensaje { get => mensaje; set => mensaje = value; }
		public string FechaCreacion { get => fechaCreacion; set => fechaCreacion = value; }
	}
}