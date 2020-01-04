using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSS.Utils.Attributes.Validation;

namespace UnitTest.Utils.Attributes.Validation
{
    /* 
     * Classe válida: intervalo de string com 9 caracteres no seguinte formato: 00000-000
     */

    [TestClass]
    public class CEPAttributeTest
    {
        private readonly CEPAttribute _attribute = new CEPAttribute();

        [TestMethod]
        public void TestEmptyCEP()
        {
            Assert.IsFalse(_attribute.IsValid(""));
        }

        [TestMethod]
        public void TestFormatedEmptyCEP()
        {
            Assert.IsFalse(_attribute.IsValid("     -   "));
        }

        [TestMethod]
        public void TestUnformatedCEP()
        {
            Assert.IsFalse(_attribute.IsValid("87053518"));
        }
       
        [TestMethod]
        public void TestValidCEP()
        {
            Assert.IsTrue(_attribute.IsValid("87053-518"));
        }
    }
}
