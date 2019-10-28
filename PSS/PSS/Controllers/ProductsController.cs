using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PSS.Models;
using SGCO.Context;

namespace PSS.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private Context db = new Context();

        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category)
                                      .Include(p => p.Manufacturer)
                                      .Include(p => p.Provider)
                                      .Include(p => p.Unit)
                                      .Where(p => p.IsActive)
                                      .OrderBy(p => p.Id);

            return View(products.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            product.Category = db.Categories.Find(product.CategoryId);
            product.Manufacturer = db.Manufacturers.Find(product.ManufacturerId);
            product.Provider = db.Providers.Find(product.ProviderId);
            product.Unit = db.Units.Find(product.UnitId);

            return View(product);
        }

        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories.Where(c => c.IsActive).OrderBy(c => c.Name), "Id", "Name");
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers.Where(m => m.IsActive).OrderBy(c => c.ShortName), "Id", "ShortName");
            ViewBag.ProviderId = new SelectList(db.Providers.Where(p => p.IsActive).OrderBy(c => c.ShortName), "Id", "ShortName");
            ViewBag.UnitId = new SelectList(db.Units.Where(u => u.IsActive).OrderBy(c => c.Description), "Id", "Description");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories.Where(c => c.IsActive).OrderBy(c => c.Name), "Id", "Name", product.CategoryId);
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers.Where(m => m.IsActive).OrderBy(c => c.ShortName), "Id", "ShortName", product.ManufacturerId);
            ViewBag.ProviderId = new SelectList(db.Providers.Where(p => p.IsActive).OrderBy(c => c.ShortName), "Id", "ShortName", product.ProviderId);
            ViewBag.UnitId = new SelectList(db.Units.Where(u => u.IsActive).OrderBy(c => c.Description), "Id", "Description", product.UnitId);

            return View(product);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            ViewBag.CategoryId = new SelectList(db.Categories.Where(c => c.IsActive).OrderBy(c => c.Name), "Id", "Name", product.CategoryId);
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers.Where(m => m.IsActive).OrderBy(c => c.ShortName), "Id", "ShortName", product.ManufacturerId);
            ViewBag.ProviderId = new SelectList(db.Providers.Where(p => p.IsActive).OrderBy(c => c.ShortName), "Id", "ShortName", product.ProviderId);
            ViewBag.UnitId = new SelectList(db.Units.Where(u => u.IsActive).OrderBy(c => c.Description), "Id", "Description", product.UnitId);

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories.Where(c => c.IsActive).OrderBy(c => c.Name), "Id", "Name", product.CategoryId);
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers.Where(m => m.IsActive).OrderBy(c => c.ShortName), "Id", "ShortName", product.ManufacturerId);
            ViewBag.ProviderId = new SelectList(db.Providers.Where(p => p.IsActive).OrderBy(c => c.ShortName), "Id", "ShortName", product.ProviderId);
            ViewBag.UnitId = new SelectList(db.Units.Where(u => u.IsActive).OrderBy(c => c.Description), "Id", "Description", product.UnitId);

            return View(product);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            product.Category = db.Categories.Find(product.CategoryId);
            product.Manufacturer = db.Manufacturers.Find(product.ManufacturerId);
            product.Provider = db.Providers.Find(product.ProviderId);
            product.Unit = db.Units.Find(product.UnitId);

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            product.IsActive = false;
            db.Entry(product).State = EntityState.Modified;
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
