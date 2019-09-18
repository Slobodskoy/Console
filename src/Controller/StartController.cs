using Notes.Infrastructure;
using Notes.Model;
using Notes.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.Controller
{
    public class StartController : IController
    {
        private readonly IControllerFactory controllerFactory;
        private readonly Page<CommandList> page;
        private CommandList commandList = new CommandList();
        public StartController(IControllerFactory controllerFactory)
        {
            commandList.Commands = new Dictionary<int, string> {
                { 1, "View all records" },
                { 2, "View record by Id" },
                { 3, "Create new record" },
                { 4, "Delete record by Id" },
                { 5, "Help" },
            };
            this.controllerFactory = controllerFactory;
            page = new Page<CommandList>("Start page");
            page.AppName = "My Notes";
        }

        public void Run()
        {  
            var view = new StartPageView(page, commandList, this);
            view.Render();
        }

        public void RunCommand(string command)
        {
            int commandId = 0;
            int.TryParse(command, out commandId);
            if (commandList.Commands.ContainsKey(commandId))
            {
                var controller = controllerFactory.GetController(commandId);
                controller.Run();
            }
        }
    }
}
