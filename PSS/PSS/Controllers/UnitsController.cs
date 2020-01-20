using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PSS.Models;
using SGCO.Context;

namespace PSS.Controllers
{
    [Authorize]
    public sealed class UnitsController : Controller
    {
        private readonly DBContext _context = new DBContext();

        public ActionResult Index()
        {
            var units = _context.Units.Where(u => u.IsActive).OrderBy(u => u.Description);
            return View(units.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Unit unit = _context.Units.Find(id);
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
                _context.Units.Add(unit);
                _context.SaveChanges();

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

            Unit unit = _context.Units.Find(id);

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
                _context.Entry(unit).State = EntityState.Modified;
                _context.SaveChanges();

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

            Unit unit = _context.Units.Find(id);

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
            Unit unit = _context.Units.Find(id);
            unit.IsActive = false;
            _context.Entry(unit).State = EntityState.Modified;         
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
