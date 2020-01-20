using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PSS.Models;
using SGCO.Context;

namespace PSS.Controllers
{
    [Authorize]
    public sealed class ProductsController : Controller
    {
        private readonly DBContext _context = new DBContext();

        public ActionResult Index()
        {
            var products = _context.Products.Include(p => p.Category)
                                            .Include(p => p.Manufacturer)
                                            .Include(p => p.Provider)
                                            .Include(p => p.Unit)                        
                                            .Where(p => p.IsActive)
                                            .OrderBy(p => p.Description).ToList();

            foreach (var product in products)
            {
                product.Stocks = _context.Stocks.Where(s => s.ProductId == product.Id).ToList();
            }

            return View(products);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = _context.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            product.Category = _context.Categories.Find(product.CategoryId);
            product.Manufacturer = _context.Manufacturers.Find(product.ManufacturerId);
            product.Provider = _context.Providers.Find(product.ProviderId);
            product.Unit = _context.Units.Find(product.UnitId);
            product.Stocks.AddRange(_context.Stocks.Where(s => s.ProductId == product.Id).ToArray());

            return View(product);
        }

        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_context.Categories.Where(c => c.IsActive).OrderBy(c => c.Name), "Id", "Name");
            ViewBag.ManufacturerId = new SelectList(_context.Manufacturers.Where(m => m.IsActive).OrderBy(c => c.ShortName), "Id", "ShortName");
            ViewBag.ProviderId = new SelectList(_context.Providers.Where(p => p.IsActive).OrderBy(c => c.ShortName), "Id", "ShortName");
            ViewBag.UnitId = new SelectList(_context.Units.Where(u => u.IsActive).OrderBy(c => c.Description), "Id", "Description");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(_context.Categories.Where(c => c.IsActive).OrderBy(c => c.Name), "Id", "Name", product.CategoryId);
            ViewBag.ManufacturerId = new SelectList(_context.Manufacturers.Where(m => m.IsActive).OrderBy(c => c.ShortName), "Id", "ShortName", product.ManufacturerId);
            ViewBag.ProviderId = new SelectList(_context.Providers.Where(p => p.IsActive).OrderBy(c => c.ShortName), "Id", "ShortName", product.ProviderId);
            ViewBag.UnitId = new SelectList(_context.Units.Where(u => u.IsActive).OrderBy(c => c.Description), "Id", "Description", product.UnitId);

            return View(product);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = _context.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            ViewBag.CategoryId = new SelectList(_context.Categories.Where(c => c.IsActive).OrderBy(c => c.Name), "Id", "Name", product.CategoryId);
            ViewBag.ManufacturerId = new SelectList(_context.Manufacturers.Where(m => m.IsActive).OrderBy(c => c.ShortName), "Id", "ShortName", product.ManufacturerId);
            ViewBag.ProviderId = new SelectList(_context.Providers.Where(p => p.IsActive).OrderBy(c => c.ShortName), "Id", "ShortName", product.ProviderId);
            ViewBag.UnitId = new SelectList(_context.Units.Where(u => u.IsActive).OrderBy(c => c.Description), "Id", "Description", product.UnitId);

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                product.Stocks = null;
                _context.Entry(product).State = EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(_context.Categories.Where(c => c.IsActive).OrderBy(c => c.Name), "Id", "Name", product.CategoryId);
            ViewBag.ManufacturerId = new SelectList(_context.Manufacturers.Where(m => m.IsActive).OrderBy(c => c.ShortName), "Id", "ShortName", product.ManufacturerId);
            ViewBag.ProviderId = new SelectList(_context.Providers.Where(p => p.IsActive).OrderBy(c => c.ShortName), "Id", "ShortName", product.ProviderId);
            ViewBag.UnitId = new SelectList(_context.Units.Where(u => u.IsActive).OrderBy(c => c.Description), "Id", "Description", product.UnitId);

            return View(product);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = _context.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            product.Category = _context.Categories.Find(product.CategoryId);
            product.Manufacturer = _context.Manufacturers.Find(product.ManufacturerId);
            product.Provider = _context.Providers.Find(product.ProviderId);
            product.Unit = _context.Units.Find(product.UnitId);
            product.Stocks.AddRange(_context.Stocks.Where(s => s.ProductId == product.Id).ToArray());

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = _context.Products.Find(id);
            product.IsActive = false;
            _context.Entry(product).State = EntityState.Modified;
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
