using System;
using System.Linq;
using System.Reflection;

namespace PSS.Utils.Extensions
{
    // Reference: https://stackoverflow.com/questions/13099834/how-to-get-the-display-name-attribute-of-an-enum-member-via-mvc-razor-code

    public static class Extensions
    {
        public static TAttribute GetAttribute<TAttribute>(this Enum enumValue) where TAttribute : Attribute => enumValue.GetType()
                                                                                                                        .GetMember(enumValue.ToString())
                                                                                                                        .First()
                                                                                                                        .GetCustomAttribute<TAttribute>();
    }
}