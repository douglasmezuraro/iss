using System.Linq;
using System.Net;
using System.Web.Mvc;
using PSS.Models;
using SGCO.Context;
using PSS.Utils;

namespace PSS.Controllers
{
    public class CartController : Controller
    {
        private Context db = new Context();

        public ActionResult Index()
        {
            return View(Global.Cart.Items.ToList());
        }

        public ActionResult AddToCart(Item item)
        {
            var _item = Global.Cart.Items.FirstOrDefault(i => i.ProductId == item.ProductId);

            if (_item == null)
            {
                item.Product = db.Products.Find(item.ProductId);
                Global.Cart.Items.Add(item);
            }
            else
            {
                _item.Quantity += item.Quantity;
            }

            return RedirectToAction("Index", "Products");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var item = Global.Cart.Items.FirstOrDefault(p => p.Product.Id == id);

            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var item = Global.Cart.Items.First(i => i.Product.Id == id);

            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Item item)
        {
            var _item = Global.Cart.Items.First(i => i.Product.Id == item.ProductId);
            _item.Quantity = item.Quantity;

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var item = Global.Cart.Items.FirstOrDefault(i => i.Product.Id == id);

            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            Global.Cart.Items.Remove(Global.Cart.Items.FirstOrDefault(i => i.Product.Id == id));

            return RedirectToAction("Index");
        }
    }
}
