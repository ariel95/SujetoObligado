using Newtonsoft.Json;
using SujetoObligado.Models.API_Externa;
using SujetoObligado.Models.SujetoObligado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using SujetoObligado.Models.Cuit;

namespace SujetoObligado.Controllers
{
    public class SujetoObligadoController : Controller
    {
        private string baseUrl = "https://sro.uif.gob.ar/SROAPI/";

        // GET: SujetoObligado
        public async System.Threading.Tasks.Task<ActionResult> Resultado(string cuit)
        {
            List<SujetoObligadoUIF> sujetoObligado = null;
            PersonaSO persona;
            Cuit.Limpiar(ref cuit);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("api/sujetoObligado/consulta/" + cuit);

                
                if (Res.IsSuccessStatusCode) {
                    var response = Res.Content.ReadAsStringAsync().Result;
                    sujetoObligado = JsonConvert.DeserializeObject<List<SujetoObligadoUIF>>(response);
                }
            }

            if (sujetoObligado != null && sujetoObligado.Count > 0) 
                persona = new PersonaSO(sujetoObligado);
            else
                persona = new PersonaSO();

            persona.Cuit = cuit;

            //TODO: Guardar en el historial de consulta
            persona.GuardarConsulta();

            return View(persona);
        }
        
    }
}
