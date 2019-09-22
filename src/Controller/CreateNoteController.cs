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
    public class CreateNoteController : BaseController, ICreateNoteController
    {
        private readonly IRepository repository;
        private readonly IView<Note, ICreateNoteController> pageView;

        public override IEnumerable<ControllerTypes> NextSteps
        {
            get => new ControllerTypes[] { ControllerTypes.StartController, ControllerTypes.CreateNoteController, ControllerTypes.HelpController };
        }

        public CreateNoteController(IControllerFactory controllerFactory, IRepository repository, IView<Note, ICreateNoteController> pageView)
        {
            this.controllerFactory = controllerFactory;
            this.repository = repository;
            this.pageView = pageView;
            this.pageView.Info.AppName = "My Notes";
            this.pageView.Info.PageName = "Create new note";
            this.pageView.Controller = this;
        }

        public override void Run()
        {
            var note = new Note();
            pageView.Model = note;
            pageView.Render();
        }

        public void AddNote(Note model)
        {
            repository.AddNote(model);
        }
    }
}
