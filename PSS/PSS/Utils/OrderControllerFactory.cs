using PSS.Controllers;
using PSS.Models;
using System.Web.Mvc;
using PSS.Utils;

namespace PSS.Utils
{
    public class OrderControllerFactory
    {
        public Controller CreateController()
        {
            switch ((UserType.UserTypeEnum)Global.User.UserTypeId)
            {
                case UserType.UserTypeEnum.Admin   : return new PurchaseOrdersController(); 
                case UserType.UserTypeEnum.Client  : return new SaleOrdersController();               
                case UserType.UserTypeEnum.Visitor : return new SaleOrdersController();         
                default : return new HomeController(); 
            }
        }
    }
}