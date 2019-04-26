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
    public class RadnoVrijemeController : Controller
    {
        private OrdinacijaDb db = new OrdinacijaDb();
        RadnoVrijemeService service = new RadnoVrijemeService();

        // GET: RadnoVrijeme/Edit/5
        public ActionResult Uredi(/*int id*/)
        {
            var id = service.GetRadnoVrijemeId();
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RadnoVrijemeDTO radnoVrijemeDTO = service.GetRadnoVrijemeById(id);
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
        public ActionResult Uredi([Bind(Include = "ID,VrijemeOd,VrijemeDo")] RadnoVrijemeDTO radnoVrijemeDTO)
        {
            if (ModelState.IsValid)
            {
                service.EditRadnoVrijeme(radnoVrijemeDTO);

                return RedirectToAction("Kalendar", "Naslovnica");
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
