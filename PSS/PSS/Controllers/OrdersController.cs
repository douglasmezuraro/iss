using System.Web.Mvc;
using PSS.Utils;

namespace PSS.Controllers
{
    public class OrdersController : Controller
    {
        private Controller controller = new OrderControllerFactory().CreateController();

        public ActionResult Index()
        {
            return RedirectToAction("Index", controller.ToString());
        }

        public ActionResult Create()
        {
            return RedirectToAction("Create", controller.ToString());
        }
    }
}