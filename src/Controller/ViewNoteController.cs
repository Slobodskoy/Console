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
    public class ViewNoteController : IViewNoteController
    {
        private readonly IControllerFactory controllerFactory;
        private readonly IRepository repository;
        private readonly IView<Note, IViewNoteController> pageView;

        public ViewNoteController(IControllerFactory controllerFactory, IRepository repository, IView<Note, IViewNoteController> pageView)
        {
            this.controllerFactory = controllerFactory;
            this.repository = repository;
            this.pageView = pageView;
            this.pageView.Info.AppName = "My Notes";
            this.pageView.Info.PageName = "View note by id";
            this.pageView.Controller = this;
        }

        public void Run()
        {
            pageView.Model = null;
            pageView.Render();
        }

        public void Run(int id)
        {
            pageView.Model = repository.GetNoteById(id) ?? new Note { Id = 0 };
            pageView.Render();
        }

        public void RunCommand(string command)
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
