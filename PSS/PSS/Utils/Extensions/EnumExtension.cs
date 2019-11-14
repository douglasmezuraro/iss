using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace PSS.Utils.Extensions
{
    // reference: http://jake.burgy.me/tidbits/2016/03/10/get-display-name-for-enum-value.html
    public static class EnumExtension
    {
        public static string EnumDisplayFor(this Enum value)
        {
            return value.GetType()
                        .GetMember(value.ToString())
                        .FirstOrDefault()
                        ?.GetCustomAttribute<DisplayAttribute>(false)
                        ?.Name
                        ?? value.ToString();
        }
    }
}