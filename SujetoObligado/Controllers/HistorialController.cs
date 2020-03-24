using SujetoObligado.Models.SujetoObligado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SujetoObligado.Controllers
{
    public class HistorialController : Controller
    {
        // GET: Historial
        public ActionResult Index(int id = 1)
        {

            var lista = Historial.Listar(id);

            return View(lista);
        }

    }
}
