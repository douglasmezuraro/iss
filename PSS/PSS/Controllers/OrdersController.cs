using System.Web.Mvc;
using PSS.Models;
using PSS.Utils;

namespace PSS.Controllers
{
    public class OrdersController : Controller
    {
        public ActionResult Index()
        {
            var user = (User)Session["User"];
            var factory = new OrderControllerFactory();
            var controller = factory.CreateController(user);

            return RedirectToAction("Index", controller.ToString());
        }
    }
}