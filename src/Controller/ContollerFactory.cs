using Notes.DB;
using Notes.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.Controller
{
    public class ControllerFactory : IControllerFactory
    {
        private Dictionary<int, IController> _controllerList;

        public ControllerFactory(IRepository repository)
        {
            _controllerList = new Dictionary<int, IController>();
            _controllerList.Add(0, new StartController(this, new StartPageView()));
            _controllerList.Add(1, new ViewAllController(this, repository, new ViewAllNotesPageView()));
            _controllerList.Add(2, new ViewNoteController(this, repository, new ViewNotePageView()));
            _controllerList.Add(3, new CreateNoteController(this, repository, new CreateNotePageView()));                       
            _controllerList.Add(4, new DeleteNoteController(this, repository, new DeleteNotePageView()));
            _controllerList.Add(5, new HelpController(this, new HelpView()));
        }
        public IController GetController(int controllerId)
        {
            return (_controllerList.ContainsKey(controllerId)) ? _controllerList[controllerId] : _controllerList[0];
        }
    }
}
