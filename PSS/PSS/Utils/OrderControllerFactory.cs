using PSS.Controllers;
using PSS.Models;
using System.Web.Mvc;

namespace PSS.Utils
{
    public class OrderControllerFactory
    {
        public Controller CreateController()
        {
            switch (Global.User.UserType)
            {
                case UserType.Admin   : return new PurchaseOrdersController(); 
                case UserType.Client  : return new SaleOrdersController();               
                case UserType.Visitor : return new SaleOrdersController();         
                default               : return new HomeController(); 
            }
        }
    }
}