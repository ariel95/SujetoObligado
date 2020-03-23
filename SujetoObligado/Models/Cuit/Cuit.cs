using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace SujetoObligado.Models.Cuit
{
    public class Cuit
    {
        public static void Limpiar(ref string cuit) {
			try
			{
				string patron = @"[^\w]";
				Regex regex = new Regex(patron);
				cuit = regex.Replace(cuit, "");
			}
			catch (Exception e)
			{

				throw e;
			}
        }

		public static bool EsCuitValido(string cuit) {
			try
			{
				bool tiene11Caracteres = false;
				bool esNumero = false;
				int ejem = 0;

				if (cuit.Length == 11)
					tiene11Caracteres = true;

				if (int.TryParse(cuit, out ejem))
					esNumero = true;

				return esNumero && tiene11Caracteres;
			}
			catch (Exception e)
			{
				throw new Exception("El valor ingresado no es un cuit válido");
			}
		}
		


	}
}