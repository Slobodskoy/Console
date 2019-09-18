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
    public class ViewAllController : IController
    {
        private readonly IRepository repository;
        private readonly Page<List<Note>> page;
        private readonly IControllerFactory controllerFactory;

        public ViewAllController(IControllerFactory controllerFactory, IRepository repository)
        {
            this.controllerFactory = controllerFactory;
            this.repository = repository;
            page = new Page<List<Note>>("View all notes");
            page.AppName = "My Notes";
        }
        public void Run()
        {
            var view = new ViewAllNotesPageView(page, repository.GetNotes(), this);
            view.Render();
        }

        internal void RunCommand(string command)
        {
            int commandId;
            int.TryParse(command, out commandId);
            if ((new[] { 0, 5 }).Contains(commandId))
            {
                var controller = controllerFactory.GetController(commandId);
                controller.Run();
            }
        }
    }
}
