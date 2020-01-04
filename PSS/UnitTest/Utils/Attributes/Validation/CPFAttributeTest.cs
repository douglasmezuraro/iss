using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSS.Utils.Attributes.Validation;

namespace UnitTest.Utils.Attributes.Validation
{
    [TestClass]
    public class CPFAttributeTest
    {
        private readonly CPFAttribute _attribute = new CPFAttribute();

        [TestMethod]
        public void TestEmptyCPF()
        {
            Assert.IsFalse(_attribute.IsValid(""));
        }

        [TestMethod]
        public void TestFormatedEmptyCPF()
        {
            Assert.IsFalse(_attribute.IsValid("   .   .   -  "));
        }

        [TestMethod]
        public void TestUnformatedCPF()
        {
            Assert.IsFalse(_attribute.IsValid("08698570020"));
        }

        [TestMethod]
        public void TestValidCPF()
        {
            Assert.IsTrue(_attribute.IsValid("086.985.700-20"));
        }
    }
}
