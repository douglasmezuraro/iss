using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSS.Utils.Attributes.Validation;
using UnitTest.Attribute;

namespace UnitTest.Test.Utils.Attributes.Validation
{
    /*
     * 
     *  +-------------------------------------------+----------------+----------------+
     *  | condition                                 |   valid class  |  invalid class |
     *  +-------------------------------------------+----+-----------+----+-----------+
     *  | lenght t of CEP                           | 01 |  t == 9   | 02 |   t <> 9  |
     *  +-------------------------------------------+----+-----------+----+-----------+
     *  | characters [0..4] are numeric             | 03 |    yes    | 04 |    nope   |
     *  +-------------------------------------------+----+-----------+----+-----------+
     *  | character [5] is a dash                   | 05 |    yes    | 06 |    nope   |
     *  +-------------------------------------------+----+-----------+----+-----------+
     *  | characters [6..8] are numeric             | 07 |    yes    | 08 |    nope   |
     *  +-------------------------------------------+----+-----------+----+-----------+
     *  
     */

    [TestClass]
    public class CEPAttributeTest
    {
        [EquivalentClass(02)]
        [TestCase("", false)]

        [EquivalentClass(04)]
        [TestCase("abcdefghi", false)]

        [EquivalentClass(06)]
        [TestCase("87053fghi", false)]

        [EquivalentClass(08)]
        [TestCase("87053-ghi", false)]

        [EquivalentClass(01, 03, 05, 07)]
        [TestCase("87053-518", true)]

        [TestMethod]   
        public void TestCEP(string cep, bool expected)
        {
            var attribute = new CEPAttribute();
            var actual = attribute.IsValid(cep);

            Assert.AreEqual(expected, actual);
        }
    }
}
