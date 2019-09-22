using Notes.Extention;
using Notes.Infrastructure;
using Notes.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.View
{
    public class MasterView        
    {
        protected AppBaseInfo _info;

        public MasterView() { }
        public MasterView(AppBaseInfo info)
        {
            _info = info;
        }

        public virtual void Render()
        {
            Console.Clear();
            RenderHead();
        }

        private void RenderHead()
        {
            ConsoleExt.Hr();
            ConsoleExt.H(_info.AppName);
            ConsoleExt.Hr();
        }
    }
}
