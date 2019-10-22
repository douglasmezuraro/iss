using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PSS.Models;
using SGCO.Context;

namespace PSS.Controllers
{
    public class UnitsController : Controller
    {
        private Context db = new Context();

        public ActionResult Index()
        {
            return View(db.Units.Where(u => u.IsActive).ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Unit unit = db.Units.Find(id);

            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Unit unit)
        {
            if (ModelState.IsValid)
            {
                db.Units.Add(unit);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(unit);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Unit unit = db.Units.Find(id);

            if (unit == null)
            {
                return HttpNotFound();
            }

            return View(unit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Unit unit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unit).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(unit);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Unit unit = db.Units.Find(id);

            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Unit unit = db.Units.Find(id);
            unit.IsActive = false;
            db.Entry(unit).State = EntityState.Modified;         
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
