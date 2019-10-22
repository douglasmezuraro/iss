using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PSS.Models;
using SGCO.Context;

namespace PSS.Controllers
{
    public class ManufacturersController : Controller
    {
        private Context db = new Context();

        public ActionResult Index()
        {
            var manufacturers = db.Manufacturers.Include(m => m.City).Where(m => m.IsActive);

            return View(manufacturers.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Manufacturer manufacturer = db.Manufacturers.Find(id);
            if (manufacturer == null)
            {
                return HttpNotFound();
            }

            manufacturer.City = db.Cities.Find(manufacturer.CityId);

            return View(manufacturer);
        }

        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(db.Cities.Where(c => c.IsActive), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                manufacturer.IsActive = true;
                db.Manufacturers.Add(manufacturer);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.Cities.Where(c => c.IsActive), "Id", "Name", manufacturer.CityId);

            return View(manufacturer);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Manufacturer manufacturer = db.Manufacturers.Find(id);
            if (manufacturer == null)
            {
                return HttpNotFound();
            }

            ViewBag.CityId = new SelectList(db.Cities.Where(c => c.IsActive), "Id", "Name", manufacturer.CityId);

            return View(manufacturer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                manufacturer.IsActive = true;
                db.Entry(manufacturer).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.Cities.Where(c => c.IsActive), "Id", "Name", manufacturer.CityId);

            return View(manufacturer);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Manufacturer manufacturer = db.Manufacturers.Find(id);
            if (manufacturer == null)
            {
                return HttpNotFound();
            }

            return View(manufacturer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Manufacturer manufacturer = db.Manufacturers.Find(id);
            manufacturer.IsActive = false;
            db.Entry(manufacturer).State = EntityState.Modified;
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
