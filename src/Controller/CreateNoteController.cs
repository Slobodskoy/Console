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
    public class CreateNoteController : IController
    {
        private readonly IControllerFactory controllerFactory;
        private readonly IRepository repository;
        private readonly Page<Note> page;

        public CreateNoteController(IControllerFactory controllerFactory, IRepository repository)
        {
            this.controllerFactory = controllerFactory;
            this.repository = repository;
            page = new Page<Note>("Create new record");
            page.AppName = "My Notes";
        }

        public void Run()
        {
            var note = new Note();
            var view = new CreateNotePageView(page, note, this);
            view.Render();
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
