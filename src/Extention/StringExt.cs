using Notes.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.Extention
{
    public static class StringExt
    {
        public static ControllerTypes GetControllerType(this string s)
        {
            int index;
            if (int.TryParse(s, out index) && Enum.IsDefined(typeof(ControllerTypes), index))
            {
                return (ControllerTypes)index;
            }
            return ControllerTypes.Unknow;
        }
    }
}
