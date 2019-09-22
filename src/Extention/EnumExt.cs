using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Notes.Extention
{
    public static class EnumExt
    {
        public static string ToName(this Enum enumVal)
        {
            var type = enumVal.GetType();
            var memberInfo = type.GetMember(enumVal.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                var attributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributes != null && attributes.Any())
                {
                    return ((DescriptionAttribute)attributes[0]).Description;
                }
            }
            return string.Empty;
        }
    }
}
