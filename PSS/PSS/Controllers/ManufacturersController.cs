using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PSS.Models;
using SGCO.Context;

namespace PSS.Controllers
{
    [Authorize]
    public sealed class ManufacturersController : Controller
    {
        private readonly DBContext _context = new DBContext();

        public ActionResult Index()
        {
            var manufacturers = _context.Manufacturers.Include(m => m.City).Where(m => m.IsActive).OrderBy(m => m.ShortName);
            return View(manufacturers.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Manufacturer manufacturer = _context.Manufacturers.Find(id);
            if (manufacturer == null)
            {
                return HttpNotFound();
            }

            manufacturer.City = _context.Cities.Find(manufacturer.CityId);

            return View(manufacturer);
        }

        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(_context.Cities.Where(c => c.IsActive).OrderBy(c => c.Name), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                _context.Manufacturers.Add(manufacturer);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(_context.Cities.Where(c => c.IsActive).OrderBy(c => c.Name), "Id", "Name", manufacturer.CityId);

            return View(manufacturer);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Manufacturer manufacturer = _context.Manufacturers.Find(id);
            if (manufacturer == null)
            {
                return HttpNotFound();
            }

            ViewBag.CityId = new SelectList(_context.Cities.Where(c => c.IsActive).OrderBy(c => c.Name), "Id", "Name", manufacturer.CityId);

            return View(manufacturer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            { 
                _context.Entry(manufacturer).State = EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(_context.Cities.Where(c => c.IsActive).OrderBy(c => c.Name), "Id", "Name", manufacturer.CityId);

            return View(manufacturer);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Manufacturer manufacturer = _context.Manufacturers.Find(id);
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
            Manufacturer manufacturer = _context.Manufacturers.Find(id);
            manufacturer.IsActive = false;
            _context.Entry(manufacturer).State = EntityState.Modified;
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
