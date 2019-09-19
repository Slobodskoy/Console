using Notes.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.View
{
    public interface IView<T, V>
    {
        PageInfo Info { get; set; }
        T Model { get; set; }
        V Controller { get; set; }
        void Render();
    }
}
