using PSS.Utils;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PSS.Models;
using SGCO.Context;

namespace PSS.Controllers
{
    public class PurchaseOrdersController : Controller
    {
        private Context db = new Context();


        public ActionResult Index()
        {
            var purchaseOrders = db.PurchaseOrders.Include(p => p.OrderStatus).Include(p => p.User).Include(p => p.Items.Select(i => i.Product)).Where(p => p.IsActive);
        
            return View(purchaseOrders.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PurchaseOrder purchaseOrder = db.PurchaseOrders.Find(id);
            if (purchaseOrder == null)
            {
                return HttpNotFound();
            }

            return View(purchaseOrder);
        }

        public ActionResult Create()
        {
            ViewBag.OrderStatusId = new SelectList(db.OrderStatuses.Where(o => o.IsActive), "Id", "Description");
            ViewBag.UserId = new SelectList(db.Users.Where(u => u.IsActive), "Id", "Password");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TotalValue,Date,OrderStatusId,UserId,IsActive")] PurchaseOrder purchaseOrder)
        {
            if (ModelState.IsValid)
            {
                purchaseOrder.FinalizeOrder();

                foreach (var item in purchaseOrder.Items)
                {
                    db.Entry(item.Product).State = EntityState.Modified;
                }
          
                db.PurchaseOrders.Add(purchaseOrder);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.OrderStatusId = new SelectList(db.OrderStatuses.Where(o => o.IsActive), "Id", "Description", purchaseOrder.OrderStatusId);
            ViewBag.UserId = new SelectList(db.Users.Where(u => u.IsActive), "Id", "Password", purchaseOrder.UserId);

            return View(purchaseOrder);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PurchaseOrder purchaseOrder = db.PurchaseOrders.Find(id);
            if (purchaseOrder == null)
            {
                return HttpNotFound();
            }

            ViewBag.OrderStatusId = new SelectList(db.OrderStatuses.Where(o => o.IsActive), "Id", "Description", purchaseOrder.OrderStatusId);
            ViewBag.UserId = new SelectList(db.Users.Where(u => u.IsActive), "Id", "Password", purchaseOrder.UserId);

            return View(purchaseOrder);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TotalValue,Date,OrderStatusId,UserId,IsActive")] PurchaseOrder purchaseOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchaseOrder).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.OrderStatusId = new SelectList(db.OrderStatuses.Where(o => o.IsActive), "Id", "Description", purchaseOrder.OrderStatusId);
            ViewBag.UserId = new SelectList(db.Users.Where(u => u.IsActive), "Id", "Password", purchaseOrder.UserId);

            return View(purchaseOrder);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PurchaseOrder purchaseOrder = db.PurchaseOrders.Find(id);
            if (purchaseOrder == null)
            {
                return HttpNotFound();
            }

            return View(purchaseOrder);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PurchaseOrder order = db.PurchaseOrders.Find(id);

            order.IsActive = false;
            db.Entry(order).State = EntityState.Modified;

            foreach (var item in order.Items)
            {
                item.IsActive = false;
                db.Entry(item).State = EntityState.Modified;
            }    
 
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        public override string ToString()
        {
            return "PurchaseOrders";
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
