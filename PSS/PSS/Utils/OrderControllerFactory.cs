using PSS.Controllers;
using PSS.Models;
using System.Web.Mvc;

namespace PSS.Utils
{
    public class OrderControllerFactory
    {
        public Controller CreateController(User user)
        {
            switch ((UserType.UserTypeEnum)user.UserTypeId)
            {
                case UserType.UserTypeEnum.Admin   : return new PurchaseOrdersController(); 
                case UserType.UserTypeEnum.Client  : return new SaleOrdersController();               
                case UserType.UserTypeEnum.Visitor : return new SaleOrdersController();         
                default : return new HomeController(); 
            }
        }
    }
}