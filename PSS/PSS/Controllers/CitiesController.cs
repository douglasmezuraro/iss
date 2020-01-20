using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PSS.Models;
using SGCO.Context;

namespace PSS.Controllers
{
    [Authorize]
    public sealed class CitiesController : Controller
    {
        private readonly DBContext _context = new DBContext();

        public ActionResult Index()
        {
            var cities = _context.Cities.Include(c => c.State).Include(c => c.State.Country).Where(c => c.IsActive).OrderBy(c => c.Name);
            return View(cities.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            City city = _context.Cities.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }

            city.State = _context.States.Find(city.StateId);

            return View(city);
        }

        public ActionResult Create()
        {
            ViewBag.StateId = new SelectList(_context.States.Where(s => s.IsActive).OrderBy(s => s.Name), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(City city)
        {
            if (ModelState.IsValid)
            {
                _context.Cities.Add(city);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.StateId = new SelectList(_context.States.Where(s => s.IsActive).OrderBy(s => s.Name), "Id", "Name", city.StateId);

            return View(city);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            City city = _context.Cities.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }

            ViewBag.StateId = new SelectList(_context.States.Where(s => s.IsActive).OrderBy(s => s.Name), "Id", "Name", city.StateId);

            return View(city);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(City city)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(city).State = EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.StateId = new SelectList(_context.States.Where(s => s.IsActive).OrderBy(s => s.Name), "Id", "Name", city.StateId);

            return View(city);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            City city = _context.Cities.Find(id);
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
            City city = _context.Cities.Find(id);
            city.IsActive = false;
            _context.Entry(city).State = EntityState.Modified;
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
