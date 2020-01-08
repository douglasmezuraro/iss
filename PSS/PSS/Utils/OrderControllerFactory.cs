using PSS.Controllers;
using PSS.Models;
using System.Web.Mvc;
using System;

namespace PSS.Utils
{
    public class OrderControllerFactory
    {
        public Controller CreateController() => CreateController(Global.User.UserType);

        public Controller CreateController(UserType userType)
        {
            switch (userType)
            {
                case UserType.Admin: return new PurchaseOrdersController();
                case UserType.Customer: return new SaleOrdersController();
            }

            throw new ArgumentException("O usuário deve ser ou administador ou cliente");
        }
    }

}