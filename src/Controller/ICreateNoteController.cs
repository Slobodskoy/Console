using Notes.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.Controller
{
    public interface ICreateNoteController : IController
    {
        void AddNote(Note model);        
    }
}
