﻿using System;
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
    public class CijenaZahvataController : Controller
    {
        private OrdinacijaDb db = new OrdinacijaDb();
        CijeneZahvataService service = new CijeneZahvataService();

        // GET: CijenaZahvata
        public ActionResult Popis()
        {
            var res = service.GetPopisCijenaZahvata();
            return View(res);
        }

        // GET: CijenaZahvata/Create
        public ActionResult Izradi()
        {
            return View();
        }

        // POST: CijenaZahvata/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Izradi([Bind(Include = "ID,Cijena")] CijenaZahvataDTO cijenaZahvataDTO)
        {
            if (ModelState.IsValid)
            {
                service.CreateNewCijenaZahvata(cijenaZahvataDTO);

                return RedirectToAction("Popis");
            }

            return View(cijenaZahvataDTO);
        }

        // GET: CijenaZahvata/Edit/5
        public ActionResult Uredi(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CijenaZahvataDTO cijenaZahvataDTO = service.GetCijenaZahvataById(id);
            if (cijenaZahvataDTO == null)
            {
                return HttpNotFound();
            }
            return View(cijenaZahvataDTO);
        }

        // POST: CijenaZahvata/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Uredi([Bind(Include = "ID,Cijena")] CijenaZahvataDTO cijenaZahvataDTO)
        {
            if (ModelState.IsValid)
            {
                service.EditCijenaZahvata(cijenaZahvataDTO);

                return RedirectToAction("Popis");
            }
            return View(cijenaZahvataDTO);
        }

        // GET: CijenaZahvata/Delete/5
        public ActionResult Izbrisi(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CijenaZahvataDTO cijenaZahvataDTO = service.GetCijenaZahvataById(id);
            if (cijenaZahvataDTO == null)
            {
                return HttpNotFound();
            }
            return View(cijenaZahvataDTO);
        }

        // POST: CijenaZahvata/Delete/5
        [HttpPost, ActionName("Izbrisi")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CijenaZahvataDTO cijenaZahvataDTO = service.GetCijenaZahvataById(id);

            service.DeleteCijenaZahvata(cijenaZahvataDTO);

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
