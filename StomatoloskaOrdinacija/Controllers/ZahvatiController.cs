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
    public class ZahvatiController : Controller
    {
        private OrdinacijaDb db = new OrdinacijaDb();
        ZahvatiService service = new ZahvatiService();

        // GET: Zahvati
        public ActionResult Popis()
        {
            var res = service.GetPopisZahvata();
            return View(res);
        }

        // GET: Zahvati/Details/5
        public ActionResult Detalji(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZahvatDTO zahvatDTO = service.GetZahvatById(id);
            if (zahvatDTO == null)
            {
                return HttpNotFound();
            }
            return View(zahvatDTO);
        }

        // GET: Zahvati/Create
        public ActionResult Izradi()
        {
            var zahvat = service.GetEmptyZahvat();
            return View(zahvat);
        }

        // POST: Zahvati/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Izradi([Bind(Include = "ID,Sifra,Naziv,CijenaID,TrajanjeID,Cijena,Trajanje")] ZahvatDTO zahvatDTO)
        {
            if (ModelState.IsValid)
            {
                service.CreateNewZahvat(zahvatDTO);

                return RedirectToAction("Popis");
            }

            service.FillDDLPacijentTrajanje(zahvatDTO);
            return View(zahvatDTO);
        }

        // GET: Zahvati/Edit/5
        public ActionResult Uredi(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZahvatDTO zahvatDTO = service.GetZahvatById(id);
            if (zahvatDTO == null)
            {
                return HttpNotFound();
            }
            return View(zahvatDTO);
        }

        // POST: Zahvati/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Uredi([Bind(Include = "ID,Sifra,Naziv,CijenaID,TrajanjeID,Cijena,Trajanje")] ZahvatDTO zahvatDTO)
        {
            if (ModelState.IsValid)
            {
                service.EditZahvat(zahvatDTO);

                return RedirectToAction("Popis");
            }
            return View(zahvatDTO);
        }

        // GET: Zahvati/Delete/5
        public ActionResult Izbrisi(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZahvatDTO zahvatDTO = service.GetZahvatById(id);
            if (zahvatDTO == null)
            {
                return HttpNotFound();
            }
            return View(zahvatDTO);
        }

        // POST: Zahvati/Delete/5
        [HttpPost, ActionName("Izbrisi")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ZahvatDTO zahvatDTO = service.GetZahvatById(id);

            service.DeleteZahvat(zahvatDTO);

            return RedirectToAction("Popis");
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
