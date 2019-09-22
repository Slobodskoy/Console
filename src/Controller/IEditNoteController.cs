using Notes.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.Controller
{
    public interface IEditNoteController : IController
    {
        void Run(int id);
        Note GetNoteById(int id);
        bool UpdateNote(Note note); 
    }
}
