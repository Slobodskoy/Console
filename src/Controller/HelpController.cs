using Notes.Infrastructure;
using Notes.Model;
using Notes.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.Controller
{
    public class HelpController : IController
    {
        private readonly IControllerFactory controllerFactory;
        private readonly IView<Help, IController> pageView;

        public HelpController(IControllerFactory controllerFactory, IView<Help, IController> pageView)
        {
            this.controllerFactory = controllerFactory;
            this.pageView = pageView;
            this.pageView.Info.AppName = "My Notes";
            this.pageView.Info.PageName = "Help";
            this.pageView.Controller = this;
        }

        public void Run()
        {
            var help = new Help { HelpText = "This is help text"};
            pageView.Model = help;
            pageView.Render();
        }

        public void RunCommand(string command)
        {
            int commandId;
            int.TryParse(command, out commandId);
            if (commandId==0)
            {
                var controller = controllerFactory.GetController(commandId);
                controller.Run();
            }
        }
    }
}
