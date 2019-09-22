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
    public class StartControllerTest
    {
        [Fact]
        public void Run_ThenViewRender()
        {
            var mock = new Mock<IRepository>();
            var factory = new ControllerFactory(mock.Object);
            var view = new Mock<IView<CommandList, IController>> ();
            view.Setup(v => v.Info).Returns(new PageInfo());
            view.Setup(v => v.Model).Returns(new CommandList());
            view.Setup(v => v.Render());
            var controller = new StartController(factory, view.Object);
            controller.Run();
            view.Verify(v => v.Render(), Times.Once());
        }

        [Theory]
        [InlineData(ControllerTypes.CreateNoteController)]
        [InlineData(ControllerTypes.EditNoteController)]
        [InlineData(ControllerTypes.DeleteNoteController)]
        [InlineData(ControllerTypes.ViewAllController)]
        [InlineData(ControllerTypes.ViewNoteController)]
        [InlineData(ControllerTypes.HelpController)]
        public void RunCommand_WhenCommand_ThenFactoryRun(ControllerTypes command)
        {
            var controllerMock = new Mock<IController>();
            controllerMock.Setup(c => c.Run());

            var mock = new Mock<IControllerFactory>();
            
            mock.Setup(a => a.GetController(It.Is<ControllerTypes>(i => i == command))).Returns(controllerMock.Object);

            var mockRep = new Mock<IRepository>();
            var view = new Mock<IView<CommandList, IController>> ();
            view.Setup(v => v.Info).Returns(new PageInfo());            

            var controller = new StartController(mock.Object, view.Object);
            controller.GoNextStep(command);
            mock.Verify(m => m.GetController(It.Is<ControllerTypes>(i => i == command)), Times.Once());
        }
    }
}
