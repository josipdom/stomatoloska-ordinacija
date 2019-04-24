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
        public ActionResult Index()
        {
            var res = service.GetPopisTrajanjeZahvata();
            return View(res);
        }

        // GET: TrajanjeZahvata/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrajanjeZahvata/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Trajanje")] TrajanjeZahvataDTO trajanjeZahvataDTO)
        {
            if (ModelState.IsValid)
            {
                service.CreateNewTrajanjeZahvata(trajanjeZahvataDTO);

                return RedirectToAction("Index");
            }

            return View(trajanjeZahvataDTO);
        }

        // GET: TrajanjeZahvata/Edit/5
        public ActionResult Edit(int id)
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
        public ActionResult Edit([Bind(Include = "ID,Trajanje")] TrajanjeZahvataDTO trajanjeZahvataDTO)
        {
            if (ModelState.IsValid)
            {
                service.EditTrajanjeZahvata(trajanjeZahvataDTO);

                return RedirectToAction("Index");
            }
            return View(trajanjeZahvataDTO);
        }

        // GET: TrajanjeZahvata/Delete/5
        public ActionResult Delete(int id)
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
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrajanjeZahvataDTO trajanjeZahvataDTO = service.GetTrajanjeZahvataById(id);

            service.DeleteTrajanjeZahvata(trajanjeZahvataDTO);

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
