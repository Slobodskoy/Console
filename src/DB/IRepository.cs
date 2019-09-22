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
        bool DeleteNode(int id);

        bool UpdateNode(Note note);
    }
}
