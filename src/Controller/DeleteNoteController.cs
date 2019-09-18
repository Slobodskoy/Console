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
    public class DeleteNoteController : IController
    {
        private readonly IControllerFactory controllerFactory;
        private readonly IRepository repository;
        private readonly Page<Note> page;

        public DeleteNoteController(IControllerFactory controllerFactory, IRepository repository)
        {
            this.controllerFactory = controllerFactory;
            this.repository = repository;
            page = new Page<Note>("Delete note by id");
            page.AppName = "My Notes";
        }

        public void Run()
        {
            var view = new DeleteNotePageView(page, null, this);
            view.Render();
        }

        public void Run(int id)
        {
            var result = repository.DeleteNode(id);
            var view = new DeleteNotePageView(page, new Note { Id = result ? id : 0 }, this);
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
