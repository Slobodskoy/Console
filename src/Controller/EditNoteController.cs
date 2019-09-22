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
    public class EditNoteController : BaseController, IEditNoteController
    {
        private readonly IRepository repository;
        private readonly IView<Note, IEditNoteController> pageView;

        public override IEnumerable<ControllerTypes> NextSteps
        {
            get => new ControllerTypes[] { ControllerTypes.StartController, ControllerTypes.HelpController };
        }

        public EditNoteController(IControllerFactory controllerFactory, IRepository repository, IView<Note, IEditNoteController> pageView)
        {
            this.controllerFactory = controllerFactory;
            this.repository = repository;
            this.pageView = pageView;
            this.pageView.Info.AppName = "My Notes";
            this.pageView.Info.PageName = "Edit note by id";
            this.pageView.Controller = this;
        }

        public override void Run()
        {
            pageView.Model = null;
            pageView.Render();
        }

        public void Run(int id)
        {
            var result = repository.GetNoteById(id);
            pageView.Model = new Note { Id = result?.Id ?? 0, Title = result?.Title, Text = result?.Text };
            pageView.Render();
        }

        public Note GetNoteById(int id)
        {
            return repository.GetNoteById(id);
        }

        public bool UpdateNote(Note note)
        {
            return repository.UpdateNode(note);
        }
    }
}
