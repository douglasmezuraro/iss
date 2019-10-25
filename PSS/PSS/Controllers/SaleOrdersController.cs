using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PSS.Models;
using SGCO.Context;

namespace PSS.Controllers
{
    public class SaleOrdersController : Controller
    {
        private Context db = new Context();

        public ActionResult Index()
        {
            var saleOrders = db.SaleOrders.Include(s => s.OrderStatus).Include(s => s.User);
            return View(saleOrders.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            SaleOrder saleOrder = db.SaleOrders.Find(id);
            if (saleOrder == null)
            {
                return HttpNotFound();
            }

            return View(saleOrder);
        }

        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "Password");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SaleOrder saleOrder)
        {
            if (ModelState.IsValid)
            {
                db.SaleOrders.Add(saleOrder);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "Password", saleOrder.UserId);

            return View(saleOrder);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            SaleOrder saleOrder = db.SaleOrders.Find(id);
            if (saleOrder == null)
            {
                return HttpNotFound();
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "Password", saleOrder.UserId);

            return View(saleOrder);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SaleOrder saleOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(saleOrder).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "Password", saleOrder.UserId);

            return View(saleOrder);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            SaleOrder saleOrder = db.SaleOrders.Find(id);
            if (saleOrder == null)
            {
                return HttpNotFound();
            }

            return View(saleOrder);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SaleOrder saleOrder = db.SaleOrders.Find(id);
            db.SaleOrders.Remove(saleOrder);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        public override string ToString()
        {
            return "SaleOrders";
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
