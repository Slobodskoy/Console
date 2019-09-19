using Moq;
using Notes.Controller;
using Notes.DB;
using Notes.Infrastructure;
using Notes.Model;
using Notes.View;
using System;
using Xunit;

namespace NotesTests
{
    public class DeleteNoteControllerTest
    {
        [Fact]
        public void Run_WhenWithId_ThenRepositoryRun()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(a => a.DeleteNode(It.IsAny<int>()));

            var factory = new ControllerFactory(mock.Object);
            var view = new Mock<IView<Note, IDeleteNoteController>>();
            view.Setup(v => v.Info).Returns(new PageInfo());
            view.Setup(v => v.Model).Returns(new Note());

            var controller = new DeleteNoteController(factory, mock.Object, view.Object);
            controller.Run(1);
            mock.Verify(m => m.DeleteNode(It.IsAny<int>()), Times.Once());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(5)]
        public void RunCommand_WhenCommand_ThenFactoryRun(int command)
        {
            var controllerMock = new Mock<IController>();
            controllerMock.Setup(c => c.Run());

            var mock = new Mock<IControllerFactory>();
            
            mock.Setup(a => a.GetController(It.Is<int>(i => i == command))).Returns(controllerMock.Object);

            var mockRep = new Mock<IRepository>();
            var view = new Mock<IView<Note, IDeleteNoteController>>();
            view.Setup(v => v.Info).Returns(new PageInfo());
            view.Setup(v => v.Model).Returns(new Note());
            var controller = new DeleteNoteController(mock.Object, mockRep.Object, view.Object);
            controller.RunCommand($"{command}");
            mock.Verify(m => m.GetController(It.Is<int>(i => i == command)), Times.Once());
        }
    }
}
