using Notes.Controller;
using Notes.DB;
using Notes.Model;
using System;
using Xunit;

namespace NotesTests
{
    public class ContollerFactoryTest
    {
        [Theory]
        [InlineData(0, typeof(StartController))]
        [InlineData(1, typeof(ViewAllController))]
        [InlineData(2, typeof(ViewNoteController))]
        [InlineData(3, typeof(CreateNoteController))]
        [InlineData(4, typeof(DeleteNoteController))]
        [InlineData(5, typeof(HelpController))]
        public void GetController_WhenId_ReturnController(int id, Type type)
        {
            var repository = new MemoryRepository();
            var factory = new ControllerFactory(repository);
            var result = factory.GetController(0);
            Assert.Equal(typeof(StartController), result.GetType());
        }
    }
}
