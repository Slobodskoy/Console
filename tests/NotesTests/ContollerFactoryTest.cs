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
        [InlineData(ControllerTypes.StartController, typeof(StartController))]
        [InlineData(ControllerTypes.ViewAllController, typeof(ViewAllController))]
        [InlineData(ControllerTypes.ViewNoteController, typeof(ViewNoteController))]
        [InlineData(ControllerTypes.CreateNoteController, typeof(CreateNoteController))]
        [InlineData(ControllerTypes.EditNoteController, typeof(EditNoteController))]
        [InlineData(ControllerTypes.DeleteNoteController, typeof(DeleteNoteController))]
        [InlineData(ControllerTypes.HelpController, typeof(HelpController))]
        public void GetController_WhenId_ReturnController(ControllerTypes controllerType, Type type)
        {
            var repository = new MemoryRepository();
            var factory = new ControllerFactory(repository);
            var result = factory.GetController(controllerType);
            Assert.Equal(type, result.GetType());
        }
    }
}
