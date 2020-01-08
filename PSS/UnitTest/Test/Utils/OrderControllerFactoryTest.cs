using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSS.Models;
using PSS.Controllers;
using PSS.Utils;
using UnitTest.Attribute;
using System;

namespace UnitTest.Test.Utils
{
    [TestClass]
    public sealed class OrderControllerFactoryTest
    {
        [TestCase(UserType.Admin, typeof(PurchaseOrdersController))]
        [TestCase(UserType.Customer, typeof(SaleOrdersController))]
        [TestMethod]
        public void TestFactory(UserType userType, Type expected)
        {
            var actual = new OrderControllerFactory().CreateController(userType);

            Assert.IsInstanceOfType(actual, expected);
        }

        [TestMethod]
        public void TestException()
        {
            Assert.ThrowsException<ArgumentException>(() => new OrderControllerFactory().CreateController(UserType.Undefined));
        }
    }
}
