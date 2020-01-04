using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSS.Utils.Attributes.Validation;

namespace UnitTest.Utils.Attributes.Validation
{
    [TestClass]
    public class PhoneAttributeTest
    {
        private readonly PhoneAttribute _attribute = new PhoneAttribute();

        [TestMethod]
        public void TestEmptyPhone()
        {
            Assert.IsFalse(_attribute.IsValid(""));
        }

        [TestMethod]
        public void TestFormatedEmptyEightNumberPhone()
        {
            Assert.IsFalse(_attribute.IsValid("(  )     -    "));
        }

        [TestMethod]
        public void TestUnformatedEightNumberPhone()
        {
            Assert.IsFalse(_attribute.IsValid("4432275149"));
        }

        [TestMethod]
        public void TestValidEightNumberPhone()
        {
            Assert.IsTrue(_attribute.IsValid("(44) 3227-5149"));
        }

        [TestMethod]
        public void TestFormatedEmptyNineNumberPhone()
        {
            Assert.IsFalse(_attribute.IsValid("(  )      -    "));
        }

        [TestMethod]
        public void TestUnformatedNineNumberPhone()
        {
            Assert.IsFalse(_attribute.IsValid("44999477765"));
        }

        [TestMethod]
        public void TestFormatedNineNumberPhone()
        {
            Assert.IsTrue(_attribute.IsValid("(44) 99947-7765"));
        }
    }
}
