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
     *  | lenght t of CNPJ                          | 01 |  t == 18  | 02 |  t <> 18  |
     *  +-------------------------------------------+----+-----------+----+-----------+
     *  | characters [0..1] are numeric             | 03 |    yes    | 04 |    nope   |
     *  +-------------------------------------------+----+-----------+----+-----------+
     *  | character [2] is a dot                    | 05 |    yes    | 06 |    nope   |
     *  +-------------------------------------------+----+-----------+----+-----------+
     *  | characters [3..5] are numeric             | 07 |    yes    | 08 |    nope   | 
     *  +-------------------------------------------+----+-----------+----+-----------+
     *  | character [6] is a dot                    | 09 |    yes    | 10 |    nope   |
     *  +-------------------------------------------+----+-----------+----+-----------+
     *  | characters [7..9] are numeric             | 11 |    yes    | 12 |    nope   | 
     *  +-------------------------------------------+----+-----------+----+-----------+
     *  | character [10] is a slash                 | 13 |    yes    | 14 |    nope   |
     *  +-------------------------------------------+----+-----------+----+-----------+
     *  | characters [11..14] are numeric           | 15 |    yes    | 16 |    nope   | 
     *  +-------------------------------------------+----+-----------+----+-----------+
     *  | character [15] is a dash                  | 17 |    yes    | 18 |    nope   |
     *  +-------------------------------------------+----+-----------+----+-----------+
     *  | characters [16..17] are numeric           | 19 |    yes    | 20 |    nope   | 
     *  +-------------------------------------------+----+-----------+----+-----------+
     *   
     */

    [TestClass]
    public class CNPJAttributeTest
    {
        [EquivalentClass(02)]
        [TestCase("", false)]

        [EquivalentClass(04)]
        [TestCase("abcdefghijklmnopqr", false)]

        [EquivalentClass(06)]
        [TestCase("50cdefghijklmnopqr", false)]

        [EquivalentClass(08)]
        [TestCase("50.defghijklmnopqr", false)]

        [EquivalentClass(10)]
        [TestCase("50.467ghijklmnopqr", false)]

        [EquivalentClass(12)]
        [TestCase("50.467.hijklmnopqr", false)]

        [EquivalentClass(14)]
        [TestCase("50.467.430klmnopqr", false)]

        [EquivalentClass(16)]
        [TestCase("50.467.430/lmnopqr", false)]

        [EquivalentClass(18)]
        [TestCase("50.467.430/0001pqr", false)]

        [EquivalentClass(20)]
        [TestCase("50.467.430/0001-qr", false)]

        [EquivalentClass(01, 03, 05, 07, 09, 11, 13, 15, 17, 19)]
        [TestCase("50.467.430/0001-96", true)]

        [TestMethod]
        public void TestCNPJ(string cnpj, bool expected)
        {
            var attribute = new CNPJAttribute();
            var actual = attribute.IsValid(cnpj);

            Assert.AreEqual(expected, actual);
        }
    }
}
