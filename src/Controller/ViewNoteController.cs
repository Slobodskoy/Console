using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Notes.DB;
using Notes.Infrastructure;
using Notes.Model;
using Notes.View;

namespace Notes.Controller
{
    public class ViewNoteController : BaseController, IViewNoteController
    {
        private readonly IRepository repository;
        private readonly IView<Note, IViewNoteController> pageView;

        public override IEnumerable<ControllerTypes> NextSteps
        {
            get => new ControllerTypes[] {
                ControllerTypes.StartController,
                ControllerTypes.HelpController};
        }

        public ViewNoteController(IControllerFactory controllerFactory, IRepository repository, IView<Note, IViewNoteController> pageView)
        {
            this.controllerFactory = controllerFactory;
            this.repository = repository;
            this.pageView = pageView;
            this.pageView.Info.AppName = "My Notes";
            this.pageView.Info.PageName = "View note by id";
            this.pageView.Controller = this;
        }

        public override void Run()
        {
            pageView.Model = null;
            pageView.Render();
        }

        public void Run(int id)
        {
            pageView.Model = repository.GetNoteById(id) ?? new Note { Id = 0 };
            pageView.Render();
        }
    }
}
