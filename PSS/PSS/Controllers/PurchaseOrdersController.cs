using PSS.Models;
using PSS.Utils;
using SGCO.Context;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace PSS.Controllers
{
    [Authorize]
    public sealed class PurchaseOrdersController : Controller
    {
        private readonly DBContext _context = new DBContext();

        public ActionResult Index()
        {
            var orders = _context.PurchaseOrders.Include(p => p.User)
                                                .Include(p => p.Freight)
                                                .Include(p => p.Payment)
                                                .Include(p => p.Items.Select(i => i.Product))
                                                .Where(p => p.IsActive)
                                                .Where(p => p.UserId == Global.User.Id)
                                                .OrderBy(p => p.Date);

            foreach (var order in orders)
            {
                foreach (var item in order.Items)
                {
                    var stocks = _context.Stocks.Where(s => s.ProductId == item.ProductId);

                    foreach (var stock in stocks)
                    {
                        item.Product.Stocks.Add(stock);
                    }
                }
            }                                                

            return View(orders.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PurchaseOrder order = _context.PurchaseOrders.Find(id); 
            if (order == null)
            {
                return HttpNotFound();
            }

            if (order.UserId != Global.User.Id)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }

            int PaymentId = order.PaymentId; //TODO: Gambiarra até entender porque o find do pagamento está alterando o FreightId do objeto "order"
            int FreightId = order.FreightId;    
            
            order.Payment = _context.PurchaseOrderPayments.Find(PaymentId);
            order.Freight = _context.PurchaseOrderFreights.Find(FreightId);
            order.Freight.City = _context.Cities.Find(order.Freight.CityId);
            order.User = _context.Users.Find(order.UserId);
            order.Items = _context.Items.Include(i => i.Product).Where(o => o.PurchaseOrderId == order.Id).ToList();

            return View(order);
        }

        public ActionResult Create()
        {
            if (Global.User.Cart.Items.Count == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "O carrinho de compras está vazio.");
            }

            ViewBag.CityId = new SelectList(_context.Cities.Where(c => c.IsActive).OrderBy(c => c.Name), "Id", "Name");

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
                    item.Product.Stocks = _context.Stocks.Where(s => s.ProductId == item.ProductId).ToList();
                }

                order.FinalizeOrder();

                _context.PurchaseOrders.Add(order);

                 foreach (var item in order.Items)
                 {
                     _context.Entry(item.Product).State = EntityState.Modified;
                 }

                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(_context.Cities.Where(c => c.IsActive).OrderBy(c => c.Name), "Id", "Name", order.Freight.CityId);

            return View(order);
        }

        public ActionResult Cancel(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PurchaseOrder order = _context.PurchaseOrders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }

            if (order.UserId != Global.User.Id)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }
          
            order.CancelOrder();

            _context.Entry(order).Property(o => o.OrderStatus).IsModified = true;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Return(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PurchaseOrder order = _context.PurchaseOrders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }

            if (order.UserId != Global.User.Id)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }

            order.ReturnOrder();

            _context.Entry(order).State = EntityState.Modified;
            _context.SaveChanges();

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
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
