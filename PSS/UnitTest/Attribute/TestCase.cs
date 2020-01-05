using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Attribute
{
    public class TestCase : DataRowAttribute
    {
        public TestCase(object value) : base(value)
        {
            // empty
        }

        public TestCase(object value, params object[] values) : base(value, values)
        {
            // empty
        }
    }
}
