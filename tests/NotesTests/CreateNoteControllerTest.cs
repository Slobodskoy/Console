using Moq;
using Notes.Controller;
using Notes.DB;
using Notes.Model;
using System;
using Xunit;

namespace NotesTests
{
    public class CreateNoteControllerTest
    {
        [Fact]
        public void AddNote_WhenCall_ThenRepositoryRun()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(a => a.AddNote(It.IsAny<Note>()));

            var factory = new ControllerFactory(mock.Object);
            var controller = new CreateNoteController(factory, mock.Object);
            controller.AddNote(new Note { Title = "Test" });
            mock.Verify(m => m.AddNote(It.IsAny<Note>()), Times.Once());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(3)]
        [InlineData(5)]
        public void RunCommand_WhenCommand_ThenFactoryRun(int command)
        {
            var controllerMock = new Mock<IController>();
            controllerMock.Setup(c => c.Run());

            var mock = new Mock<IControllerFactory>();
            
            mock.Setup(a => a.GetController(It.Is<int>(i => i == command))).Returns(controllerMock.Object);

            var mockRep = new Mock<IRepository>();
            var controller = new CreateNoteController(mock.Object, mockRep.Object);
            controller.RunCommand($"{command}");
            mock.Verify(m => m.GetController(It.Is<int>(i => i == command)), Times.Once());
        }
    }
}
