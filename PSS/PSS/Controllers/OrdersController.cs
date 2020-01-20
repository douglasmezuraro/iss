using System.Web.Mvc;
using PSS.Utils;

namespace PSS.Controllers
{
    [Authorize]
    public sealed class OrdersController : Controller
    {
        private readonly Controller _controller = new OrderControllerFactory().CreateController();

        public ActionResult Index()
        {
            return RedirectToAction("Index", _controller.ToString());
        }

        public ActionResult Create()
        {
            return RedirectToAction("Create", _controller.ToString());
        }
    }
}