using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PSS.Models;
using PSS.Utils;
using SGCO.Context;

namespace PSS.Controllers
{
    [Authorize]
    public class PurchaseOrdersController : Controller
    {
        private DBContext db = new DBContext();

        public ActionResult Index()
        {
            var orders = db.PurchaseOrders.Include(p => p.User)
                                                  .Include(p => p.Freight)
                                                  .Include(p => p.Payment)
                                                  .Include(p => p.Items.Select(i => i.Product))
                                                  .Where(p => p.IsActive)
                                                  .Where(p => p.UserId == Global.User.Id)
                                                  .OrderBy(p => p.Date);
           // foreach (var order in orders)
           // {
               // foreach (var item in order.Items)
               // {
             //       item.Product.Stocks = db.Stocks.Where(s => s.ProductId == item.ProductId).ToList();
           //     }
         //   }

            return View(orders.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PurchaseOrder order = db.PurchaseOrders.Find(id); 
            if (order == null)
            {
                return HttpNotFound();
            }

            if (order.UserId != Global.User.Id)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }

            int PaymentId = order.PaymentId; //TODO: Gambiarra at� entender porque o find do pagamento est� alterando o
            int FreightId = order.FreightId; //      FreightId do objeto "order"
            
            order.Payment = db.PurchaseOrderPayments.Find(PaymentId);
            order.Freight = db.PurchaseOrderFreights.Find(FreightId);
            order.Freight.City = db.Cities.Find(order.Freight.CityId);
            order.User = db.Users.Find(order.UserId);
            order.Items = db.Items.Include(i => i.Product).Where(o => o.PurchaseOrderId == order.Id).ToList();

            return View(order);
        }

        public ActionResult Create()
        {
            if (Global.User.Cart.Items.Count == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "O carrinho de compras est� vazio.");
            }

            ViewBag.CityId = new SelectList(db.Cities.Where(c => c.IsActive).OrderBy(c => c.Name), "Id", "Name");

            return View(new PurchaseOrder());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PurchaseOrder order)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in order.Items)
                {
                    item.Product.Stocks = db.Stocks.Where(s => s.ProductId == item.ProductId).ToList();
                }

                order.FinalizeOrder();

                db.PurchaseOrders.Add(order);

                 foreach (var item in order.Items)
                 {
                     db.Entry(item.Product).State = EntityState.Modified;
                 }

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.Cities.Where(c => c.IsActive).OrderBy(c => c.Name), "Id", "Name", order.Freight.CityId);

            return View(order);
        }

        public ActionResult Cancel(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PurchaseOrder order = db.PurchaseOrders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }

            if (order.UserId != Global.User.Id)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }
          
            order.CancelOrder();
            db.Entry(order).Property(o => o.OrderStatus).IsModified = true;

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Return(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PurchaseOrder order = db.PurchaseOrders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }

            if (order.UserId != Global.User.Id)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }

            order.ReturnOrder();

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
