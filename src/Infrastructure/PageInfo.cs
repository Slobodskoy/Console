using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.Infrastructure
{
    public class PageInfo : AppBaseInfo
    {
        public PageInfo() { }
        public PageInfo(string pageName)
        {
            PageName = pageName;
        }
        public string PageName { get; set; }
    }
}
