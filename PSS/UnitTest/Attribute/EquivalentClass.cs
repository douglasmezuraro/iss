using System;

namespace UnitTest.Attribute
{
    /// <summary>
    /// This class aims to show which test equivalence classes the method covers
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    class EquivalentClass : System.Attribute
    {
        public readonly byte[] Classes;

        public EquivalentClass() : this(null)
        {
           
        }

        public EquivalentClass(params byte[] Classes)
        {
            this.Classes = Classes;
        }
    }
}
