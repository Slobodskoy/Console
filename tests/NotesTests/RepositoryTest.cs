using Notes.DB;
using Notes.Model;
using System;
using Xunit;

namespace NotesTests
{
    public class RepositoryTest
    {
        [Fact]
        public void Add_WhenAddNote_StoreInRepository()
        {
            var repository = new MemoryRepository();
            var note1 = new Note { Title = "note1" };
            var id = repository.AddNote(note1);
            var note = repository.GetNoteById(id);
            Assert.Equal(note1, note);
        }

        [Fact]
        public void Add_WhenAddNote_ReturnNewId()
        {
            var repository = new MemoryRepository();
            var note1 = new Note { Title = "note1" };
            repository.AddNote(note1);
            Assert.Equal(1, note1.Id);
            var note2 = new Note { Title = "note2" };
            repository.AddNote(note2);
            Assert.Equal(2, note2.Id);
            var note3 = new Note { Title = "note3" };
            repository.AddNote(note3);
            Assert.Equal(3, note3.Id);
            var note4 = new Note { Title = "note4" };
            repository.AddNote(note4);
            Assert.Equal(4, note4.Id);
            var note5 = new Note { Title = "note5" };
            repository.AddNote(note5);
            Assert.Equal(5, note5.Id);
        }

        [Fact]
        public void GetNotes_WhenEmptyRepository_ReturnEmptyList()
        {
            var repository = new MemoryRepository();
            var list = repository.GetNotes();
            Assert.Empty(list);
        }

        [Fact]
        public void GetNotes_WhenNotEmptyRepository_ReturnAllItems()
        {
            var repository = new MemoryRepository();
            var note1 = new Note { Title = "note1" };
            repository.AddNote(note1);
            var note2 = new Note { Title = "note2" };
            repository.AddNote(note2);
            var note3 = new Note { Title = "note3" };
            repository.AddNote(note3);
            var note4 = new Note { Title = "note4" };
            repository.AddNote(note4);
            var note5 = new Note { Title = "note5" };
            repository.AddNote(note5);

            var list = repository.GetNotes();
            Assert.Equal(5,list.Count);
        }

        [Fact]
        public void GetNoteById_WhenIdNotFound_ReturnNull()
        {
            var repository = new MemoryRepository();
            var note1 = new Note { Title = "note1" };
            repository.AddNote(note1);
            var item = repository.GetNoteById(100);
            Assert.Null(item);
        }

        [Fact]
        public void GetNoteById_WhenIdFound_ReturnItem()
        {
            var repository = new MemoryRepository();
            var note1 = new Note { Title = "note1" };
            repository.AddNote(note1);
            var item = repository.GetNoteById(1);
            Assert.NotNull(item);
        }

        [Fact]
        public void DeleteNode_WhenIdNotFound_ReturnFalse()
        {
            var repository = new MemoryRepository();
            var note1 = new Note { Title = "note1" };
            repository.AddNote(note1);
            var result = repository.DeleteNode(100);
            Assert.False(result);
        }

        [Fact]
        public void DeleteNode_WhenIdFound_ReturnTrue()
        {
            var repository = new MemoryRepository();
            var note1 = new Note { Title = "note1" };
            repository.AddNote(note1);
            var result = repository.DeleteNode(1);
            Assert.True(result);
            var item = repository.GetNoteById(1);
            Assert.Null(item);
        }
    }
}
