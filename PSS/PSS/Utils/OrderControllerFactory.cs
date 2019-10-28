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
                case UserType.Customer : return null;
                default                : throw new ArgumentException(); 
            }
        }
    }
}