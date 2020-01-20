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
    public sealed class StatesController : Controller
    {
        private readonly DBContext _context = new DBContext();

        public ActionResult Index()
        {
            var states = _context.States.Include(s => s.Country).Where(s => s.IsActive).OrderBy(s => s.Name);
            return View(states.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            State state = _context.States.Find(id);
            if (state == null)
            {
                return HttpNotFound();
            }

            return View(state);
        }

        public ActionResult Create()
        {
            ViewBag.CountryId = new SelectList(_context.Countries.Where(s => s.IsActive).OrderBy(s => s.Name), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(State state)
        {
            if (ModelState.IsValid)
            {
                _context.States.Add(state);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.CountryId = new SelectList(_context.Countries.Where(s => s.IsActive).OrderBy(s => s.Name), "Id", "Name", state.CountryId);

            return View(state);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            State state = _context.States.Find(id);
            if (state == null)
            {
                return HttpNotFound();
            }

            ViewBag.CountryId = new SelectList(_context.Countries.Where(s => s.IsActive).OrderBy(s => s.Name), "Id", "Name", state.CountryId);

            return View(state);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(State state)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(state).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CountryId = new SelectList(_context.Countries.Where(s => s.IsActive).OrderBy(s => s.Name), "Id", "Name", state.CountryId);

            return View(state);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            State state = _context.States.Find(id);
            if (state == null)
            {
                return HttpNotFound();
            }

            return View(state);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            State state = _context.States.Find(id);
            state.IsActive = false;
            _context.Entry(state).State = EntityState.Modified;
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
