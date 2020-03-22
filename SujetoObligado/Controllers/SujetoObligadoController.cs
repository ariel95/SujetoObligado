using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SujetoObligado.Controllers
{
    public class SujetoObligadoController : Controller
    {
        // GET: SujetoObligado
        public ActionResult Index()
        {
            return View();
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
