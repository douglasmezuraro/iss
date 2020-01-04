using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSS.Utils.Attributes.Validation;

namespace UnitTest.Utils.Attributes.Validation
{
    [TestClass]
    public class CNPJAttributeTest
    {
        private readonly CNPJAttribute _attribute = new CNPJAttribute();

        [TestMethod]
        public void TestEmptyCNPJ()
        {
            Assert.IsFalse(_attribute.IsValid(""));
        }

        [TestMethod]
        public void TestFormatedEmptyCNPJ()
        {
            Assert.IsFalse(_attribute.IsValid("  .   .   /    -  "));
        }

        [TestMethod]
        public void TestUnformatedCNPJ()
        {
            Assert.IsFalse(_attribute.IsValid("75170583000106"));
        }

        [TestMethod]
        public void TestValidCNPJ()
        {
            Assert.IsTrue(_attribute.IsValid("75.170.583/0001-06"));
        }
    }
}
