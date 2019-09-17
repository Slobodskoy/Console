using Notes.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.DB
{
    public interface IRepository
    {
        List<Note> GetNotes();
        Note GetNoteById(int id);
        int AddNote(Note note);
        void DeleteNode(int id);
    }
}
