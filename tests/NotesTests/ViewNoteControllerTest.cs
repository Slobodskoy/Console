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
    public class ViewNoteControllerTest
    {

        [Fact]
        public void Run_ThenViewRender()
        {
            var mock = new Mock<IRepository>();
            var factory = new ControllerFactory(mock.Object);
            var view = new Mock<IView<Note, IViewNoteController>>();
            view.Setup(v => v.Info).Returns(new PageInfo());
            view.Setup(v => v.Model).Returns(new Note());
            view.Setup(v => v.Render());
            var controller = new ViewNoteController(factory, mock.Object, view.Object);
            controller.Run();
            view.Verify(v => v.Render(), Times.Once());
        }

        [Fact]
        public void Run_WhenWithId_ThenRepositoryRun()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(a => a.GetNoteById(It.IsAny<int>()));

            var factory = new ControllerFactory(mock.Object);
            var view = new Mock<IView<Note, IViewNoteController>>();
            view.Setup(v => v.Info).Returns(new PageInfo());
            view.Setup(v => v.Model).Returns(new Note());

            var controller = new ViewNoteController(factory, mock.Object, view.Object);
            controller.Run(1);
            mock.Verify(m => m.GetNoteById(It.IsAny<int>()), Times.Once());
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
            var view = new Mock<IView<Note, IViewNoteController>>();
            view.Setup(v => v.Info).Returns(new PageInfo());
            view.Setup(v => v.Model).Returns(new Note());
            var controller = new ViewNoteController(mock.Object, mockRep.Object, view.Object);
            controller.GoNextStep(command);
            mock.Verify(m => m.GetController(It.Is<ControllerTypes>(i => i == command)), Times.Once());
        }
    }
}
