using StomatoloskaOrdinacija.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StomatoloskaOrdinacija.Controllers
{
    public class NarudzbeController : Controller
    {
        // GET: Narudzbe
        public ActionResult Index()
        {
            StomatoloskaOrdinacijaService service = new StomatoloskaOrdinacijaService();
            var res = service.GetPopisNarudzba();

            return View(res);
        }

        // GET: Narudzbe/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Narudzbe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Narudzbe/Create
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

        // GET: Narudzbe/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Narudzbe/Edit/5
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

        // GET: Narudzbe/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Narudzbe/Delete/5
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
