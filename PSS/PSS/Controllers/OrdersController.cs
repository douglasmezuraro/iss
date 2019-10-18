using System.Web.Mvc;
using PSS.Utils;

namespace PSS.Controllers
{
    public class OrdersController : Controller
    {
        public ActionResult Index()
        {
            var controller = new OrderControllerFactory().CreateController();

            return RedirectToAction("Index", controller.ToString());
        }
    }
}