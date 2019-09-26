using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PSS.Models;
using SGCO.Context;

namespace PSS.Controllers
{
    public class SaleOrdersController : Controller
    {
        private Context db = new Context();

        // GET: SaleOrders
        public ActionResult Index()
        {
            var saleOrders = db.SaleOrders.Include(s => s.OrderStatus).Include(s => s.User);
            return View(saleOrders.ToList());
        }

        // GET: SaleOrders/Details/5
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

        // GET: SaleOrders/Create
        public ActionResult Create()
        {
            ViewBag.OrderStatusId = new SelectList(db.OrderStatuses, "Id", "Description");
            ViewBag.UserId = new SelectList(db.Users, "Id", "Password");
            return View();
        }

        // POST: SaleOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TotalValue,Date,OrderStatusId,UserId,IsActive")] SaleOrder saleOrder)
        {
            if (ModelState.IsValid)
            {
                db.SaleOrders.Add(saleOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrderStatusId = new SelectList(db.OrderStatuses, "Id", "Description", saleOrder.OrderStatusId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Password", saleOrder.UserId);
            return View(saleOrder);
        }

        // GET: SaleOrders/Edit/5
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
            ViewBag.OrderStatusId = new SelectList(db.OrderStatuses, "Id", "Description", saleOrder.OrderStatusId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Password", saleOrder.UserId);
            return View(saleOrder);
        }

        // POST: SaleOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TotalValue,Date,OrderStatusId,UserId,IsActive")] SaleOrder saleOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(saleOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrderStatusId = new SelectList(db.OrderStatuses, "Id", "Description", saleOrder.OrderStatusId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Password", saleOrder.UserId);
            return View(saleOrder);
        }

        // GET: SaleOrders/Delete/5
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

        // POST: SaleOrders/Delete/5
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
