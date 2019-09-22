using Notes.DB;
using Notes.Infrastructure;
using Notes.Model;
using Notes.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Notes.Controller
{
    public class ViewAllController : BaseController, IController
    {
        private readonly IRepository repository;
        private readonly IView<List<Note>, IController> pageView;

        public override IEnumerable<ControllerTypes> NextSteps
        {
            get => new ControllerTypes[] {
                ControllerTypes.StartController,
                ControllerTypes.HelpController};
        }

        public ViewAllController(IControllerFactory controllerFactory, IRepository repository, IView<List<Note>, IController> pageView)
        {
            this.controllerFactory = controllerFactory;
            this.repository = repository;
            this.pageView = pageView;
            this.pageView.Info.AppName = "My Notes";
            this.pageView.Info.PageName = "View all notes";
            this.pageView.Controller = this;
        }
        public override void Run()
        {
            pageView.Model = repository.GetNotes();
            pageView.Render();
        }
    }
}
