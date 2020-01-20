
using SGCO.Context;
using System.Linq;
using System.Web.Mvc;

namespace PSS.Reports.Controllers
{
    public sealed class StockController : Controller
    {
        private DBContext _context = new DBContext();

        public ActionResult Details(int id)
        {
            var data = _context.Stocks.Where(s => s.ProductId == id).OrderBy(s => s.Id).ToList();
            return View(data);
        }
    }
}
