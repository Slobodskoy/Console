using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Notes.Model;

namespace Notes.DB
{
    public class MemoryRepository : IRepository
    {
        protected SortedDictionary<int, Note> notesDict = new SortedDictionary<int, Note>();
        public int AddNote(Note note)
        {
            var id = notesDict.Keys.LastOrDefault()+1;
            note.Id = id;
            notesDict[id] = note;
            return id;
        }

        public bool DeleteNode(int id)
        {
            return notesDict.Remove(id);
        }

        public Note GetNoteById(int id)
        {
            Note result;
            notesDict.TryGetValue(id, out result);
            return result;
        }

        public List<Note> GetNotes()
        {
            return notesDict.Values.ToList();
        }
    }
}
