using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSS.Utils.Attributes.Validation;
using UnitTest.Attribute;

namespace UnitTest.Test.Utils.Attributes.Validation
{
    /*
     * 
     *  +----------------------------------------+----------------+----------------+
     *  | condition                              |   valid class  |  invalid class |
     *  +----------------------------------------+----+-----------+----+-----------+
     *  | lenght t of CPF                        | 01 |  t == 14  | 02 |  t <> 14  |
     *  +----------------------------------------+----+-----------+----+-----------+
     *  | characters [0..2] are numeric          | 03 |    yes    | 04 |    nope   |
     *  +----------------------------------------+----+-----------+----+-----------+
     *  | character [3] is a dot                 | 05 |    yes    | 06 |    nope   |
     *  +----------------------------------------+----+-----------+----+-----------+
     *  | characters [4..6] are numeric          | 07 |    yes    | 08 |    nope   | 
     *  +----------------------------------------+----+-----------+----+-----------+
     *  | character [7] is a dot                 | 09 |    yes    | 10 |    nope   |
     *  +----------------------------------------+----+-----------+----+-----------+
     *  | characters [8..10] are numeric         | 11 |    yes    | 12 |    nope   | 
     *  +----------------------------------------+----+-----------+----+-----------+
     *  | character [11] is a dash               | 13 |    yes    | 14 |    nope   |
     *  +----------------------------------------+----+-----------+----+-----------+
     *  | characters [12..13] are numeric        | 15 |    yes    | 16 |    nope   | 
     *  +----------------------------------------+----+-----------+----+-----------+
     *
     */

    [TestClass]
    public class CPFAttributeTest
    {
        [EquivalentClass(02)]
        [TestCase("", false)]

        [EquivalentClass(04)]
        [TestCase("abcdefghijklmn", false)]

        [EquivalentClass(06)]
        [TestCase("101defghijklmn", false)]

        [EquivalentClass(08)]
        [TestCase("101.efghijklmn", false)]

        [EquivalentClass(10)]
        [TestCase("101.229hijklmn", false)]

        [EquivalentClass(12)]
        [TestCase("101.229.ijklmn", false)]

        [EquivalentClass(14)]
        [TestCase("101.229.339lmn", false)]

        [EquivalentClass(16)]
        [TestCase("101.229.339-mn", false)]

        [EquivalentClass(01, 03, 05, 07, 09, 11, 13, 15)]
        [TestCase("101.229.339-40", true)]

        [TestMethod]
        public void TestCPF(string cpf, bool expected)
        {
            var attribute = new CPFAttribute();
            var actual = attribute.IsValid(cpf);

            Assert.AreEqual(expected, actual);
        }
    }
}
