using Notes.DB;
using Notes.Model;
using Notes.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.Controller
{
    public class ControllerFactory : IControllerFactory
    {
        private Dictionary<ControllerTypes, IController> _controllerList;

        public ControllerFactory(IRepository repository)
        {
            _controllerList = new Dictionary<ControllerTypes, IController>();
            _controllerList.Add(ControllerTypes.StartController, new StartController(this, new StartPageView()));
            _controllerList.Add(ControllerTypes.ViewAllController, new ViewAllController(this, repository, new ViewAllNotesPageView()));
            _controllerList.Add(ControllerTypes.ViewNoteController, new ViewNoteController(this, repository, new ViewNotePageView()));
            _controllerList.Add(ControllerTypes.CreateNoteController, new CreateNoteController(this, repository, new CreateNotePageView()));
            _controllerList.Add(ControllerTypes.EditNoteController, new EditNoteController(this, repository, new EditNotePageView()));
            _controllerList.Add(ControllerTypes.DeleteNoteController, new DeleteNoteController(this, repository, new DeleteNotePageView()));
            _controllerList.Add(ControllerTypes.HelpController, new HelpController(this, new HelpView()));
        }
        public IController GetController(ControllerTypes ctype)
        {
            return (_controllerList.ContainsKey(ctype)) ? _controllerList[ctype] : _controllerList[0];
        }
    }
}
