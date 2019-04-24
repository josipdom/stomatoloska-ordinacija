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
using StomatoloskaOrdinacija.Domain.Repository;

namespace StomatoloskaOrdinacija.Controllers
{
    public class RadnoVrijemeController : Controller
    {
        private OrdinacijaDb db = new OrdinacijaDb();
        RadnoVrijemeRepository rvr = new RadnoVrijemeRepository();

        //// GET: RadnoVrijeme
        //public ActionResult Index()
        //{
        //    return View(db.RadnoVrijemeDTOes.ToList());
        //}

        //// GET: RadnoVrijeme/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    RadnoVrijemeDTO radnoVrijemeDTO = db.RadnoVrijemeDTOes.Find(id);
        //    if (radnoVrijemeDTO == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(radnoVrijemeDTO);
        //}

        //// GET: RadnoVrijeme/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: RadnoVrijeme/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ID,VrijemeOd,VrijemeDo")] RadnoVrijemeDTO radnoVrijemeDTO)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.RadnoVrijemeDTOes.Add(radnoVrijemeDTO);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(radnoVrijemeDTO);
        //}

        // GET: RadnoVrijeme/Edit/5
        public ActionResult Edit(/*int id*/)
        {
            var id = rvr.GetRadnoVrijemeId();
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RadnoVrijemeDTO radnoVrijemeDTO = rvr.GetRadnoVrijemeById(id);
            if (radnoVrijemeDTO == null)
            {
                return HttpNotFound();
            }
            return View(radnoVrijemeDTO);
        }

        // POST: RadnoVrijeme/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,VrijemeOd,VrijemeDo")] RadnoVrijemeDTO radnoVrijemeDTO)
        {
            if (ModelState.IsValid)
            {
                rvr.EditRadnoVrijeme(radnoVrijemeDTO);

                return RedirectToAction("Index", "Home");
            }
            return View(radnoVrijemeDTO);
        }

        //// GET: RadnoVrijeme/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    RadnoVrijemeDTO radnoVrijemeDTO = db.RadnoVrijemeDTOes.Find(id);
        //    if (radnoVrijemeDTO == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(radnoVrijemeDTO);
        //}

        //// POST: RadnoVrijeme/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    RadnoVrijemeDTO radnoVrijemeDTO = db.RadnoVrijemeDTOes.Find(id);
        //    db.RadnoVrijemeDTOes.Remove(radnoVrijemeDTO);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
