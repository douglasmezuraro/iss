using PSS.Reports.Models;
using SGCO.Context;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace PSS.Reports.Controllers
{
    public sealed class StockController : Controller
    {
        private DBContext _context = new DBContext();

        public ActionResult Details(int id)
        {
            var Query = new StringBuilder();
            
            Query.AppendLine("SELECT")
                 .AppendLine("      PRODUCTS.ID AS ID,")
                 .AppendLine("      PRODUCTS.DESCRIPTION AS DESCRIPTION,")
                 .AppendLine("      IIF(PURCHASEORDERS.ID IS NULL, SALEORDERS.DATE, PURCHASEORDERS.DATE) AS DATE,")
                 .AppendLine("      COALESCE(PRODUCTS.STOCK, 0) AS ACTUAL,")
                 .AppendLine("      COALESCE(IIF(PURCHASEORDERS.ID IS NULL, NULL, ITEMS.QUANTITY), 0) AS ENTRY,")
                 .AppendLine("      COALESCE(IIF(SALEORDERS.ID IS NULL, NULL, ITEMS.QUANTITY), 0) AS OUT,")
                 .AppendLine("      COALESCE(IIF(PURCHASEORDERS.ID IS NULL, PRODUCTS.STOCK + ITEMS.QUANTITY, PRODUCTS.STOCK - ITEMS.QUANTITY), 0) AS PREVIOUS")
                 .AppendLine("FROM")
                 .AppendLine("      ITEMS")
                 .AppendLine("JOIN")
                 .AppendLine("      PRODUCTS ON ITEMS.PRODUCTID = PRODUCTS.ID")
                 .AppendLine("LEFT JOIN")
                 .AppendLine("      PURCHASEORDERS ON ITEMS.PURCHASEORDERID = PURCHASEORDERS.ID")
                 .AppendLine("LEFT JOIN")
                 .AppendLine("      SALEORDERS ON ITEMS.SALEORDERID = SALEORDERS.ID")
                 .AppendLine("WHERE")
                 .AppendLine("     PRODUCTS.ID = @ID")
                 .AppendLine("ORDER BY")
                 .AppendLine("      ITEMS.ID;");

            var data = _context.Database.SqlQuery<Stock>(Query.ToString(), new SqlParameter("@ID", id)).ToList();

            return View(data);
        }
    }
}
