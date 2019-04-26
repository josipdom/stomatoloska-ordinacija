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
    public class TrajanjeZahvataController : Controller
    {
        private OrdinacijaDb db = new OrdinacijaDb();
        TrajanjeZahvataService service = new TrajanjeZahvataService();

        // GET: TrajanjeZahvata
        public ActionResult Popis()
        {
            var res = service.GetPopisTrajanjeZahvata();
            return View(res);
        }

        // GET: TrajanjeZahvata/Create
        public ActionResult Izradi()
        {
            return View();
        }

        // POST: TrajanjeZahvata/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Izradi([Bind(Include = "ID,Trajanje")] TrajanjeZahvataDTO trajanjeZahvataDTO)
        {
            if (ModelState.IsValid)
            {
                service.CreateNewTrajanjeZahvata(trajanjeZahvataDTO);

                return RedirectToAction("Popis");
            }

            return View(trajanjeZahvataDTO);
        }

        // GET: TrajanjeZahvata/Edit/5
        public ActionResult Uredi(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrajanjeZahvataDTO trajanjeZahvataDTO = service.GetTrajanjeZahvataById(id);
            if (trajanjeZahvataDTO == null)
            {
                return HttpNotFound();
            }
            return View(trajanjeZahvataDTO);
        }

        // POST: TrajanjeZahvata/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Uredi([Bind(Include = "ID,Trajanje")] TrajanjeZahvataDTO trajanjeZahvataDTO)
        {
            if (ModelState.IsValid)
            {
                service.EditTrajanjeZahvata(trajanjeZahvataDTO);

                return RedirectToAction("Popis");
            }
            return View(trajanjeZahvataDTO);
        }

        // GET: TrajanjeZahvata/Delete/5
        public ActionResult Izbrisi(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrajanjeZahvataDTO trajanjeZahvataDTO = service.GetTrajanjeZahvataById(id);
            if (trajanjeZahvataDTO == null)
            {
                return HttpNotFound();
            }
            return View(trajanjeZahvataDTO);
        }

        // POST: TrajanjeZahvata/Delete/5
        [HttpPost, ActionName("Izbrisi")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrajanjeZahvataDTO trajanjeZahvataDTO = service.GetTrajanjeZahvataById(id);

            service.DeleteTrajanjeZahvata(trajanjeZahvataDTO);

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
