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
        private readonly Page<Help> page;

        public HelpController(IControllerFactory controllerFactory)
        {
            this.controllerFactory = controllerFactory;
            page = new Page<Help>("Help");
            page.AppName = "My Notes";
        }

        public void Run()
        {
            var help = new Help { HelpText = "This is help text"};
            var view = new HelpView(page, help, this);
            view.Render();
        }

        internal void RunCommand(string command)
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
