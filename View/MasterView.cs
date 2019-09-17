using Notes.Extention;
using Notes.Infrastructure;
using Notes.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.View
{
    public class MasterView<T>
        where T: Base
    {
        protected T _info;
        public MasterView(T info)
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
            ConsoleExt.Br();
            ConsoleExt.H(_info.AppName);
            ConsoleExt.Br();
        }
    }
}
