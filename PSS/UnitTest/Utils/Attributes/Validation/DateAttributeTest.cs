using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSS.Utils.Attributes.Validation;

namespace UnitTest.Utils.Attributes.Validation
{
    [TestClass]
    public class DateAttributeTest
    {
        [TestMethod]
        public void TestPastAttributeWithPastDate()
        {
            var attribute = new DateAttribute(Temporality.Past);
            var date = DateTime.Now.AddDays(-1);

            Assert.IsTrue(attribute.IsValid(date));
        }

        [TestMethod]
        public void TestPastAttributeWithActualDate()
        {
            var attribute = new DateAttribute(Temporality.Past);
            var date = DateTime.Now;

            Assert.IsFalse(attribute.IsValid(date));
        }

        [TestMethod]
        public void TestPastAttributeWithFutureDate()
        {
            var attribute = new DateAttribute(Temporality.Past);
            var date = DateTime.Now.AddDays(1);

            Assert.IsFalse(attribute.IsValid(date));
        }

        [TestMethod]
        public void TestActualAttributeWithPastDate()
        {
            var attribute = new DateAttribute(Temporality.Now);
            var date = DateTime.Now.AddDays(-1);

            Assert.IsFalse(attribute.IsValid(date));
        }

        [TestMethod]
        public void TestActualAttributeWithActualDate()
        {
            var attribute = new DateAttribute(Temporality.Now);
            var date = DateTime.Now;

            Assert.IsTrue(attribute.IsValid(date));
        }

        [TestMethod]
        public void TestActualAttributeWithFutureDate()
        {
            var attribute = new DateAttribute(Temporality.Now);
            var date = DateTime.Now.AddDays(1);

            Assert.IsFalse(attribute.IsValid(date));
        }

        [TestMethod]
        public void TestFutureAttributeWithPastDate()
        {
            var attribute = new DateAttribute(Temporality.Future);
            var date = DateTime.Now.AddDays(-1);

            Assert.IsFalse(attribute.IsValid(date));
        }

        [TestMethod]
        public void TestFutureAttributeWithActualDate()
        {
            var attribute = new DateAttribute(Temporality.Future);
            var date = DateTime.Now;

            Assert.IsFalse(attribute.IsValid(date));
        }

        [TestMethod]
        public void TestFutureAttributeWithFutureDate()
        {
            var attribute = new DateAttribute(Temporality.Future);
            var date = DateTime.Now.AddDays(1);

            Assert.IsTrue(attribute.IsValid(date));
        }

    }
}
