using StomatoloskaOrdinacija.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StomatoloskaOrdinacija.Controllers
{
    public class PacijentiController : Controller
    {
        // GET: Pacijenti
        public ActionResult Index()
        {
            StomatoloskaOrdinacijaService service = new StomatoloskaOrdinacijaService();
            var res = service.GetPopisPacijenata();

            return View(res);
        }

        // GET: Pacijenti/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pacijenti/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pacijenti/Create
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

        // GET: Pacijenti/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pacijenti/Edit/5
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

        // GET: Pacijenti/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pacijenti/Delete/5
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
