using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PSS.Models;
using SGCO.Context;

namespace PSS.Controllers
{
    public class ProductsController : Controller
    {
        private Context db = new Context();

        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category)
                                      .Include(p => p.Manufacturer)
                                      .Include(p => p.Provider)
                                      .Include(p => p.Unit)
                                      .Where(p => p.IsActive == true);

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
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "Id", "ShortName");
            ViewBag.ProviderId = new SelectList(db.Providers, "Id", "ShortName");
            ViewBag.UnitId = new SelectList(db.Units, "Id", "Description");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ShortDescription,FullDescription,PurchasePrice,SalePrice,Stock,Weight,Expiration,CategoryId,ManufacturerId,ProviderId,UnitId,IsActive")] Product product)
        {
            if (ModelState.IsValid)
            {
                product.IsActive = true;
                db.Products.Add(product);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "Id", "ShortName", product.ManufacturerId);
            ViewBag.ProviderId = new SelectList(db.Providers, "Id", "ShortName", product.ProviderId);
            ViewBag.UnitId = new SelectList(db.Units, "Id", "Description", product.UnitId);

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

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "Id", "ShortName", product.ManufacturerId);
            ViewBag.ProviderId = new SelectList(db.Providers, "Id", "ShortName", product.ProviderId);
            ViewBag.UnitId = new SelectList(db.Units, "Id", "Description", product.UnitId);

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ShortDescription,FullDescription,PurchasePrice,SalePrice,Stock,Weight,Expiration,CategoryId,ManufacturerId,ProviderId,UnitId,IsActive")] Product product)
        {
            if (ModelState.IsValid)
            {
                product.IsActive = true;
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "Id", "ShortName", product.ManufacturerId);
            ViewBag.ProviderId = new SelectList(db.Providers, "Id", "ShortName", product.ProviderId);
            ViewBag.UnitId = new SelectList(db.Units, "Id", "Description", product.UnitId);

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
