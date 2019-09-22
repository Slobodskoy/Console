using Notes.Infrastructure;
using Notes.Model;
using Notes.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.Controller
{
    public class StartController : BaseController, IController
    {
        private readonly IView<CommandList, IController> pageView;
        private CommandList commandList = new CommandList();

        public override IEnumerable<ControllerTypes> NextSteps
        {
            get => new ControllerTypes[] {
                ControllerTypes.CreateNoteController,
                ControllerTypes.DeleteNoteController,
                ControllerTypes.EditNoteController,
                ControllerTypes.HelpController,
                ControllerTypes.ViewAllController,
                ControllerTypes.ViewNoteController };
        }

        public StartController(IControllerFactory controllerFactory, IView<CommandList, IController> pageView)
        {
            commandList.Commands = new Dictionary<ControllerTypes, string> {
                { ControllerTypes.ViewAllController, "View all records" },
                { ControllerTypes.ViewNoteController, "View record by Id" },
                { ControllerTypes.CreateNoteController, "Create new record" },
                { ControllerTypes.EditNoteController, "Edit note" },
                { ControllerTypes.DeleteNoteController, "Delete record by Id" },
                { ControllerTypes.HelpController, "Help" },
            };
            this.controllerFactory = controllerFactory;
            this.pageView = pageView;
            this.pageView.Info.AppName = "My Notes";
            this.pageView.Info.PageName = "Start page";
            this.pageView.Controller = this;
        }

        public override void Run()
        {
            pageView.Model = commandList;
            pageView.Render();
        }
    }
}
