using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.Controller
{
    public interface IDeleteNoteController : IController
    {
        void Run(int id);
    }
}
