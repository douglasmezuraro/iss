using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PSS.Models;
using SGCO.Context;

namespace PSS.Controllers
{
    public class CartController : Controller
    {
        private Context db = new Context();

        public ActionResult Index()
        {
            if (Session["Cart"] == null)
            {
                Session["Cart"] = new Cart();
            }

            var cart = (Cart)Session["Cart"];

            return View(cart.Items.ToList());
        }

        public ActionResult AddToCart(Item item)
        {
            if (Session["Cart"] == null)
            {
                Session["Cart"] = new Cart();
            }

            item.Product = db.Products.Find(item.ProductId);
            var cart = (Cart)Session["Cart"];
            cart.Items.Add(item);

            return RedirectToAction("Index", "Products");
        }

        public ActionResult Details(int id)
        {
            return View();
        }


        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
