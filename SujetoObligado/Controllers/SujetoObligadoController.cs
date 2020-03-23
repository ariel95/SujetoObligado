using Newtonsoft.Json;
using SujetoObligado.Models.API_Externa;
using SujetoObligado.Models.SujetoObligado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SujetoObligado.Controllers
{
    public class SujetoObligadoController : Controller
    {
        private string baseUrl = "https://sro.uif.gob.ar/SROAPI/";// + "30500003193";

        // GET: SujetoObligado
        public async System.Threading.Tasks.Task<ActionResult> Index(string cuit = "30500003193")
        {
            List<SujetoObligadoUIF> sujetoObligado = null;
            PersonaSO persona = null;

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

            if (sujetoObligado != null && sujetoObligado.Count > 0) {
                persona = new PersonaSO(sujetoObligado);
            }

            return View(sujetoObligado);
        }

        // GET: SujetoObligado/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SujetoObligado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SujetoObligado/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SujetoObligado/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SujetoObligado/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SujetoObligado/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SujetoObligado/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
