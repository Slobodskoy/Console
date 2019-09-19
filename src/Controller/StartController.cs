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
        private readonly IView<CommandList, IController> pageView;
        private CommandList commandList = new CommandList();
        public StartController(IControllerFactory controllerFactory, IView<CommandList, IController> pageView)
        {
            commandList.Commands = new Dictionary<int, string> {
                { 1, "View all records" },
                { 2, "View record by Id" },
                { 3, "Create new record" },
                { 4, "Delete record by Id" },
                { 5, "Help" },
            };
            this.controllerFactory = controllerFactory;
            this.pageView = pageView;
            this.pageView.Info.AppName = "My Notes";
            this.pageView.Info.PageName = "Start page";
            this.pageView.Controller = this;
        }

        public void Run()
        {  
            pageView.Model = commandList;
            pageView.Render();
        }

        public void RunCommand(string command)
        {
            int commandId;
            int.TryParse(command, out commandId);
            if (commandList.Commands.ContainsKey(commandId))
            {
                var controller = controllerFactory.GetController(commandId);
                controller.Run();
            }
        }
    }
}
