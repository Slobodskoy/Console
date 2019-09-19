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
    public class CreateNoteController : ICreateNoteController
    {
        private readonly IControllerFactory controllerFactory;
        private readonly IRepository repository;
        private readonly IView<Note, ICreateNoteController> pageView;

        public CreateNoteController(IControllerFactory controllerFactory, IRepository repository, IView<Note, ICreateNoteController> pageView)
        {
            this.controllerFactory = controllerFactory;
            this.repository = repository;
            this.pageView = pageView;
            this.pageView.Info.AppName = "My Notes";
            this.pageView.Info.PageName = "Create new note";
            this.pageView.Controller = this;
        }

        public void Run()
        {
            var note = new Note();
            pageView.Model = note;
            pageView.Render();
        }

        public void AddNote(Note model)
        {
            repository.AddNote(model);
        }

        public void RunCommand(string command)
        {
            int commandId;
            int.TryParse(command, out commandId);
            if ((new[] { 0, 3, 5 }).Contains(commandId) )
            {
                var controller = controllerFactory.GetController(commandId);
                controller.Run();
            }
        }
    }
}
