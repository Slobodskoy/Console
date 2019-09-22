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
    public class CreateNoteControllerTest
    {
        [Fact]
        public void Run_ThenViewRender()
        {
            var mock = new Mock<IRepository>();
            var factory = new ControllerFactory(mock.Object);
            var view = new Mock<IView<Note, ICreateNoteController>>();
            view.Setup(v => v.Info).Returns(new PageInfo());
            view.Setup(v => v.Model).Returns(new Note());
            view.Setup(v => v.Render());
            var controller = new CreateNoteController(factory, mock.Object, view.Object);
            controller.Run();
            view.Verify(v => v.Render(), Times.Once());
        }

        [Fact]
        public void AddNote_WhenCall_ThenRepositoryRun()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(a => a.AddNote(It.IsAny<Note>()));

            var factory = new ControllerFactory(mock.Object);
            var view = new Mock<IView<Note, ICreateNoteController>>();
            view.Setup(v => v.Info).Returns(new PageInfo());
            view.Setup(v => v.Model).Returns(new Note());
            var controller = new CreateNoteController(factory, mock.Object, view.Object);
            controller.AddNote(new Note { Title = "Test" });
            mock.Verify(m => m.AddNote(It.IsAny<Note>()), Times.Once());
        }

        [Theory]
        [InlineData(ControllerTypes.StartController)]
        [InlineData(ControllerTypes.CreateNoteController)]
        [InlineData(ControllerTypes.HelpController)]
        public void RunCommand_WhenCommand_ThenFactoryRun(ControllerTypes command)
        {
            var controllerMock = new Mock<IController>();
            controllerMock.Setup(c => c.Run());

            var mock = new Mock<IControllerFactory>();
            
            mock.Setup(a => a.GetController(It.Is<ControllerTypes>(i => i == command))).Returns(controllerMock.Object);

            var mockRep = new Mock<IRepository>();
            var view = new Mock<IView<Note, ICreateNoteController>>();
            view.Setup(v => v.Info).Returns(new PageInfo());
            view.Setup(v => v.Model).Returns(new Note());

            var controller = new CreateNoteController(mock.Object, mockRep.Object, view.Object);
            controller.GoNextStep(command);
            mock.Verify(m => m.GetController(It.Is<ControllerTypes>(i => i == command)), Times.Once());
        }
    }
}
