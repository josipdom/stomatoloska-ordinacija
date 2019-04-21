using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StomatoloskaOrdinacija.DAL;
using StomatoloskaOrdinacija.Domain.DTOs;
using StomatoloskaOrdinacija.Domain.Services;

namespace StomatoloskaOrdinacija.Controllers
{
    public class PacijentiController : Controller
    {
        private OrdinacijaDb db = new OrdinacijaDb();
        StomatoloskaOrdinacijaService service = new StomatoloskaOrdinacijaService();

        // GET: Pacijenti
        public ActionResult Index()
        {
            var res = service.GetPopisPacijenata();
            return View(res);
        }

        // GET: Pacijenti/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PacijentDTO pacijentDTO = service.GetPacijentById(id);

            if (pacijentDTO == null)
            {
                return HttpNotFound();
            }

            return View(pacijentDTO);
        }

        // GET: Pacijenti/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pacijenti/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Ime,Prezime,DatumRodjenja,Telefon,Adresa")] PacijentDTO pacijentDTO)
        {
            if (ModelState.IsValid)
            {
                service.CreateNewPacijent(pacijentDTO);

                return RedirectToAction("Index");
            }

            return View(pacijentDTO);
        }

        // GET: Pacijenti/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PacijentDTO pacijentDTO = service.GetPacijentById(id);

            if (pacijentDTO == null)
            {
                return HttpNotFound();
            }
            return View(pacijentDTO);
        }

        // POST: Pacijenti/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Ime,Prezime,DatumRodjenja,Telefon,Adresa")] PacijentDTO pacijentDTO)
        {
            if (ModelState.IsValid)
            {

                service.EditPacijent(pacijentDTO);

                return RedirectToAction("Index");
            }
            return View(pacijentDTO);
        }

        // GET: Pacijenti/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PacijentDTO pacijentDTO = service.GetPacijentById(id);
            if (pacijentDTO == null)
            {
                return HttpNotFound();
            }
            return View(pacijentDTO);
        }

        // POST: Pacijenti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PacijentDTO pacijentDTO = service.GetPacijentById(id);

            service.DeletePacijent(pacijentDTO);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
