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
    public sealed class SaleOrdersController : Controller
    {
        private readonly DBContext _context = new DBContext();

        public ActionResult Index()
        {
            var orders = _context.SaleOrders.Include(p => p.User)
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

            SaleOrder order = _context.SaleOrders.Find(id);
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
            
            order.Payment = _context.SaleOrderPayments.Find(PaymentId);
            order.Freight = _context.SaleOrderFreights.Find(FreightId);
            order.Freight.City = _context.Cities.Find(order.Freight.CityId);
            order.User = _context.Users.Find(order.UserId);
            order.Items = _context.Items.Include(i => i.Product).Where(o => o.SaleOrderId == order.Id).ToList();

            return View(order);
        }

        public ActionResult Create()
        {
            if (Global.User.Cart.Items.Count == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "O carrinho de compras está vazio.");
            }

            ViewBag.CityId = new SelectList(_context.Cities.Where(c => c.IsActive).OrderBy(c => c.Name), "Id", "Name");

            return View(new SaleOrder());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SaleOrder order)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in order.Items)
                {
                    item.Product.Stocks = _context.Stocks.Where(s => s.ProductId == item.ProductId).ToList();
                }

                order.FinalizeOrder();

                _context.SaleOrders.Add(order);

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

            SaleOrder order = _context.SaleOrders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }

            if (order.UserId != Global.User.Id)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }

            order.CancelOrder();
            
            _context.Entry(order).State = EntityState.Modified;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Return(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            SaleOrder order = _context.SaleOrders.Find(id);
            order.Items = _context.Items.Where(i => i.SaleOrderId == order.Id).Include(i => i.Product).ToList();

            foreach (var item in order.Items)
            {
                item.Product.Stocks = _context.Stocks.Where(s => s.ProductId == item.ProductId).ToList();
            }

            if (order == null)
            {
                return HttpNotFound();
            }

            if (order.UserId != Global.User.Id)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }

            order.ReturnOrder();

            foreach (var item in order.Items)
            {
                foreach (var stock in item.Product.Stocks)
                {
                    if (stock.Id == 0)
                    {
                        _context.Entry(stock).State = EntityState.Added;
                    }
                }                
            }

            _context.Entry(order).Property(o => o.OrderStatus).IsModified = true;
            _context.Entry(order).State = EntityState.Detached;
            _context.SaveChanges();

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
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
