using Notes.Infrastructure;
using Notes.Model;
using Notes.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.Controller
{
    public class HelpController : BaseController, IController
    {
        private readonly IView<Help, IController> pageView;

        public override IEnumerable<ControllerTypes> NextSteps
        {
            get => new ControllerTypes[] { ControllerTypes.StartController };
        }

        public HelpController(IControllerFactory controllerFactory, IView<Help, IController> pageView)
        {
            this.controllerFactory = controllerFactory;
            this.pageView = pageView;
            this.pageView.Info.AppName = "My Notes";
            this.pageView.Info.PageName = "Help";
            this.pageView.Controller = this;
        }

        public override void Run()
        {
            var help = new Help { HelpText = "This is help text"};
            pageView.Model = help;
            pageView.Render();
        }
    }
}
