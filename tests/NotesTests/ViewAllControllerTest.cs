using Moq;
using Notes.Controller;
using Notes.DB;
using Notes.Infrastructure;
using Notes.Model;
using Notes.View;
using System;
using System.Collections.Generic;
using Xunit;

namespace NotesTests
{
    public class ViewAllControllerTest
    {
        [Fact]
        public void Run_ThenViewRender()
        {
            var mock = new Mock<IRepository>();
            var factory = new ControllerFactory(mock.Object);
            var view = new Mock<IView<List<Note>, IController>>();
            view.Setup(v => v.Info).Returns(new PageInfo());
            view.Setup(v => v.Model).Returns(new List<Note> { new Note() });
            view.Setup(v => v.Render());
            var controller = new ViewAllController(factory, mock.Object, view.Object);
            controller.Run();
            view.Verify(v => v.Render(), Times.Once());
        }

        [Fact]
        public void Run_ThenRepositoryGetNotesCall()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(r => r.GetNotes());
            var factory = new ControllerFactory(mock.Object);
            var view = new Mock<IView<List<Note>, IController>>();
            view.Setup(v => v.Info).Returns(new PageInfo());
            view.Setup(v => v.Model).Returns(new List<Note> { new Note() });
            view.Setup(v => v.Render());
            var controller = new ViewAllController(factory, mock.Object, view.Object);
            controller.Run();
            mock.Verify(v => v.GetNotes(), Times.Once());
        }

        [Theory]
        [InlineData(ControllerTypes.StartController)]
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
