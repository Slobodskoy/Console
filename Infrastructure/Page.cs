using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.Infrastructure
{
    public class Page<T> : Base
    {
        public Page(string pageName)
        {
            PageName = pageName;
        }
        public string PageName { get; private set; }
        public T Content { get; set; }
    }
}
