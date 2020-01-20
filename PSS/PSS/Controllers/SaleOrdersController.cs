﻿using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PSS.Models;
using PSS.Utils;
using SGCO.Context;

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

            order.Freight = _context.SaleOrderFreights.Find(order.FreightId);
            order.Freight.City = _context.Cities.Find(order.Freight.CityId);
            order.Payment = _context.SaleOrderPayments.Find(order.PaymentId);
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

            return View();
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

                _context.SaveChanges();

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
