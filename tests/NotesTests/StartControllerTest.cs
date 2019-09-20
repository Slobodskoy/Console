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
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void RunCommand_WhenCommand_ThenFactoryRun(int command)
        {
            var controllerMock = new Mock<IController>();
            controllerMock.Setup(c => c.Run());

            var mock = new Mock<IControllerFactory>();
            
            mock.Setup(a => a.GetController(It.Is<int>(i => i == command))).Returns(controllerMock.Object);

            var mockRep = new Mock<IRepository>();
            var view = new Mock<IView<CommandList, IController>> ();
            view.Setup(v => v.Info).Returns(new PageInfo());            

            var controller = new StartController(mock.Object, view.Object);
            controller.RunCommand($"{command}");
            mock.Verify(m => m.GetController(It.Is<int>(i => i == command)), Times.Once());
        }
    }
}
