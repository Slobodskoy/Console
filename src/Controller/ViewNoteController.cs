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
    public class ViewNoteController : IController
    {
        private readonly IControllerFactory controllerFactory;
        private readonly IRepository repository;
        private readonly Page<Note> page;

        public ViewNoteController(IControllerFactory controllerFactory, IRepository repository)
        {
            this.controllerFactory = controllerFactory;
            this.repository = repository;
            this.page = new Page<Note>("View note by id");
            this.page.AppName = "My Notes";
        }

        public void Run()
        {

            var view = new ViewNotePageView(page, null, this);
            view.Render();
        }

        public void Run(int id)
        {
            var view = new ViewNotePageView(page, repository.GetNoteById(id) ?? new Note { Id = 0 }, this);
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
