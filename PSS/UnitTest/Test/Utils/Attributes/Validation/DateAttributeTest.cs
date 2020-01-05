using System;
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
     *  | given the dates "a" and "b" where "a" is the entry and "b" the current date |
     *  +-------------------------------------------+----+-----------+----+-----------+
     *  | temporality is "Temporality.Past"         | 01 |   a < b   | 02 |  a >= b   |
     *  +-------------------------------------------+----+-----------+----+-----------+
     *  | temporality is "Temporality.Now"          | 03 |   a == b  | 04 |  a <> b   |
     *  +-------------------------------------------+----+-----------+----+-----------+
     *  | temporality is "Temporality.Future"       | 05 |   a > b   | 06 |  a <= b   |
     *  +-------------------------------------------+----+-----------+----+-----------+
     *
     */

    [TestClass]
    public class DateAttributeTest
    {
        [EquivalentClass(06)]
        [TestCase(-1, Temporality.Future, false)]

        [EquivalentClass(04)]
        [TestCase(-1, Temporality.Now, false)]

        [EquivalentClass(01)]
        [TestCase(-1, Temporality.Past, true)]

        [EquivalentClass(06)]
        [TestCase(0, Temporality.Future, false)]

        [EquivalentClass(03)]
        [TestCase(0, Temporality.Now, true)]

        [EquivalentClass(02)]
        [TestCase(0, Temporality.Past, false)]

        [EquivalentClass(05)]
        [TestCase(1, Temporality.Future, true)]

        [EquivalentClass(04)]
        [TestCase(1, Temporality.Now, false)]

        [EquivalentClass(02)]
        [TestCase(1, Temporality.Past, false)]

        [TestMethod]
        public void ValidateDate(int days, Temporality temporality, bool expected)
        {
            var attribute = new DateAttribute(temporality);
            var actual = attribute.IsValid(DateTime.Now.AddDays(days));

            Assert.AreEqual(expected, actual);
        }
    }
}
