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
            var orders = db.SaleOrders.Include(p => p.User)
                                          .Include(p => p.Freight)
                                          .Include(p => p.Items.Select(i => i.Product))
                                          .Where(p => p.IsActive)
                                          .OrderBy(p => p.Id);

            return View(orders.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            SaleOrder order = db.SaleOrders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }

            order.Freight = db.SaleOrderFreights.Find(order.FreightId);
            order.User = db.Users.Find(order.UserId);
            order.Items = db.Items.Include(i => i.Product).Where(o => o.SaleOrderId == order.Id).ToList();

            return View(order);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SaleOrder order)
        {
            if (ModelState.IsValid)
            {
                order.FinalizeOrder();

                foreach (var item in order.Items)
                {
                    db.Products.Attach(item.Product);
                    db.Entry(item.Product).State = EntityState.Modified;
                }

                db.SaleOrders.Add(order);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(order);
        }

        public ActionResult Cancel(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            SaleOrder order = db.SaleOrders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }

            order.CancelOrder();
            db.Entry(order).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Return(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            SaleOrder order = db.SaleOrders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }

            order.ReturnOrder();

            return RedirectToAction("Index");
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        public override string ToString()
        {
            return "SaleOrders";
        }

        public ActionResult FinalizeOrder()
        {
            return Create();
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
