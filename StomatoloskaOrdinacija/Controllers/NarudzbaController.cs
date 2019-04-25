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
    public class NarudzbaController : Controller
    {
        private OrdinacijaDb db = new OrdinacijaDb();
        NarudzbeService service = new NarudzbeService();

        // GET: Narudzba
        public ActionResult Index()
        {
            var res = service.GetPopisNarudzba();
            return View(res);
        }

        // GET: Narudzba/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NarudzbaDTO narudzbaDTO = service.GetNarudzbaById(id);
            if (narudzbaDTO == null)
            {
                return HttpNotFound();
            }
            return View(narudzbaDTO);
        }

        // GET: Narudzba/Create
        public ActionResult Create()
        {
            var narudzba = service.GetEmptyNarudzba();
            return View(narudzba);
        }

        // POST: Narudzba/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Datum,Sati,Minute,Opis,PacijentID,ZahvatID,Dolazak")] NarudzbaDTO narudzbaDTO)
        {
            if (ModelState.IsValid)
            {
                service.CreateNewNarudzba(narudzbaDTO);

                return RedirectToAction("Index");
            }

            service.FillDDLPacijentZahvat(narudzbaDTO);

            return View(narudzbaDTO);
        }

        // GET: Narudzba/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NarudzbaDTO narudzbaDTO = service.GetNarudzbaById(id);
            if (narudzbaDTO == null)
            {
                return HttpNotFound();
            }
            //ViewBag.PacijentID = new SelectList(db.Pacijents, "ID", "Ime", narudzbaDTO.PacijentID);
            //ViewBag.ZahvatID = new SelectList(db.Zahvats, "ID", "Sifra", narudzbaDTO.ZahvatID);
            return View(narudzbaDTO);
        }

        // POST: Narudzba/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Datum,Sati,Minute,Opis,PacijentID,ZahvatID,Dolazak")] NarudzbaDTO narudzbaDTO)
        {
            if (ModelState.IsValid)
            {
                service.EditNarudzba(narudzbaDTO);

                return RedirectToAction("Index");
            }
            //ViewBag.PacijentID = new SelectList(db.Pacijents, "ID", "Ime", narudzbaDTO.PacijentID);
            //ViewBag.ZahvatID = new SelectList(db.Zahvats, "ID", "Sifra", narudzbaDTO.ZahvatID);
            return View(narudzbaDTO);
        }

        // GET: Narudzba/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            NarudzbaDTO narudzbaDTO = service.GetNarudzbaById(id);

            if (narudzbaDTO == null)
            {
                return HttpNotFound();
            }
            return View(narudzbaDTO);
        }

        // POST: Narudzba/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NarudzbaDTO narudzbaDTO = service.GetNarudzbaById(id);

            service.DeleteNarudzba(narudzbaDTO);

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
