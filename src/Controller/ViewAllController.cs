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
        private readonly IView<List<Note>> pageView;
        private readonly IControllerFactory controllerFactory;

        public ViewAllController(IControllerFactory controllerFactory, IRepository repository, IView<List<Note>> pageView)
        {
            this.controllerFactory = controllerFactory;
            this.repository = repository;
            this.pageView = pageView;
            this.pageView.Info.AppName = "My Notes";
            this.pageView.Info.PageName = "View all notes";
        }
        public void Run()
        {
            pageView.Model = repository.GetNotes();
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
