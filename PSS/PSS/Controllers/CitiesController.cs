using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PSS.Models;
using SGCO.Context;

namespace PSS.Controllers
{
    public class CitiesController : Controller
    {
        private Context db = new Context();

        public ActionResult Index()
        {
            var cities = db.Cities.Include(c => c.State).Include(c => c.State.Country).Where(c => c.IsActive).OrderBy(c => c.Id);
            return View(cities.ToList().Where(c => c.IsActive));
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            City city = db.Cities.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }

            city.State = db.States.Find(city.StateId);

            return View(city);
        }

        public ActionResult Create()
        {
            ViewBag.StateId = new SelectList(db.States.Where(s => s.IsActive).OrderBy(s => s.Name), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(City city)
        {
            if (ModelState.IsValid)
            {
                db.Cities.Add(city);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.StateId = new SelectList(db.States.Where(s => s.IsActive).OrderBy(s => s.Name), "Id", "Name", city.StateId);

            return View(city);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            City city = db.Cities.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }

            ViewBag.StateId = new SelectList(db.States.Where(s => s.IsActive).OrderBy(s => s.Name), "Id", "Name", city.StateId);

            return View(city);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(City city)
        {
            if (ModelState.IsValid)
            {
                db.Entry(city).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.StateId = new SelectList(db.States.Where(s => s.IsActive).OrderBy(s => s.Name), "Id", "Name", city.StateId);

            return View(city);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            City city = db.Cities.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }

            return View(city);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            City city = db.Cities.Find(id);
            city.IsActive = false;
            db.Entry(city).State = EntityState.Modified;
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
