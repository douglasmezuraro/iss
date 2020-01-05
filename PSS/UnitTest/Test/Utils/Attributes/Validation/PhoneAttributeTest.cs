using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSS.Utils.Attributes.Validation;
using UnitTest.Attribute;

namespace UnitTest.Test.Utils.Attributes.Validation
{
    [TestClass]
    public class PhoneAttributeTest
    {
        [EquivalentClass(02)]
        [TestCase("", false)]

        [EquivalentClass(04)]
        [TestCase("abcdefghijklmn", false)]

        [EquivalentClass(06)]
        [TestCase("(bcdefghijklmn", false)]

        [EquivalentClass(08)]
        [TestCase("(44defghijklmn", false)]

        [EquivalentClass(10)]
        [TestCase("(44)efghijklmn", false)]

        [EquivalentClass(12)]
        [TestCase("(44) fghijklmn", false)]

        [EquivalentClass(14)]
        [TestCase("(44) 3227jklmn", false)]

        [EquivalentClass(16)]
        [TestCase("(44) 3227-klmn", false)]

        [EquivalentClass(01, 03, 05, 07, 09, 11, 13, 15)]
        [TestCase("(44) 3227-5149", true)]

        [TestMethod]
        /**            
          +----------------------------------------+----------------+----------------+
          | condition                              |   valid class  |  invalid class |
          +----------------------------------------+----+-----------+----+-----------+
          | lenght t of phone                      | 01 |  t == 14  | 02 |  t <> 14  |
          +----------------------------------------+----+-----------+----+-----------+
          | character [0] is parentesis            | 03 |    yes    | 04 |    nope   |
          +----------------------------------------+----+-----------+----+-----------+
          | characters [1..2] are numeric          | 05 |    yes    | 06 |    nope   |
          +----------------------------------------+----+-----------+----+-----------+
          | character [3] is parentesis            | 07 |    yes    | 08 |    nope   | 
          +----------------------------------------+----+-----------+----+-----------+
          | character [4] is a blank-space         | 09 |    yes    | 10 |    nope   |
          +----------------------------------------+----+-----------+----+-----------+
          | characters [5..8] are numeric          | 11 |    yes    | 12 |    nope   | 
          +----------------------------------------+----+-----------+----+-----------+
          | character [9] are a dash               | 13 |    yes    | 14 |    nope   |
          +----------------------------------------+----+-----------+----+-----------+
          | characters [10..13] are numeric        | 15 |    yes    | 16 |    nope   | 
          +----------------------------------------+----+-----------+----+-----------+
        **/
        public void TestPhone(string phone, bool expected)
        {
            var attribute = new PhoneAttribute();
            var actual = attribute.IsValid(phone);

            Assert.AreEqual(expected, actual);
        }
    }
}
