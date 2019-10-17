﻿using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PSS.Models;
using SGCO.Context;

namespace PSS.Controllers
{
    public class ProvidersController : Controller
    {
        private Context db = new Context();

        public ActionResult Index()
        {
            var providers = db.Providers.Include(p => p.City).Where(p => p.IsActive == true);

            return View(providers.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Provider provider = db.Providers.Find(id);
            if (provider == null)
            {
                return HttpNotFound();
            }

            provider.City = db.Cities.Find(provider.CityId);

            return View(provider);
        }

        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ShortName,FullName,CNPJ,Phone,Email,Address,Number,PostalCode,Complement,Reference,CityId,IsActive")] Provider provider)
        {
            if (ModelState.IsValid)
            {
                provider.IsActive = true;
                db.Providers.Add(provider);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", provider.CityId);

            return View(provider);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Provider provider = db.Providers.Find(id);
            if (provider == null)
            {
                return HttpNotFound();
            }

            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", provider.CityId);

            return View(provider);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ShortName,FullName,CNPJ,Phone,Email,Address,Number,PostalCode,Complement,Reference,CityId,IsActive")] Provider provider)
        {
            if (ModelState.IsValid)
            {
                provider.IsActive = true;
                db.Entry(provider).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", provider.CityId);

            return View(provider);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Provider provider = db.Providers.Find(id);
            if (provider == null)
            {
                return HttpNotFound();
            }

            provider.City = db.Cities.Find(provider.CityId);

            return View(provider);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Provider provider = db.Providers.Find(id);
            provider.IsActive = false;
            db.Entry(provider).State = EntityState.Modified;
            db.SaveChanges();
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
