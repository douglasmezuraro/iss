using PSS.Controllers;
using PSS.Models;
using System.Web.Mvc;
using System;

namespace PSS.Utils
{
    public class OrderControllerFactory
    {
        public Controller CreateController()
        {
            switch (Global.User.UserType)
            {
                case UserType.Admin    : return new PurchaseOrdersController(); 
                case UserType.Customer : return null; // new SaleOrdersController(); // TODO: Refatorar controlador de pedido de venda
                default                : throw new ArgumentException(); 
            }
        }
    }
}