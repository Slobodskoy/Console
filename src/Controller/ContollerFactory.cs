using Notes.DB;
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
            _controllerList.Add(0, new StartController(this));
            _controllerList.Add(1, new ViewAllController(this, repository));
            _controllerList.Add(2, new ViewNoteController(this, repository));
            _controllerList.Add(3, new CreateNoteController(this, repository));                       
            _controllerList.Add(4, new DeleteNoteController(this, repository));
            _controllerList.Add(5, new HelpController(this));
        }
        public IController GetController(int controllerId)
        {
            return (_controllerList.ContainsKey(controllerId)) ? _controllerList[controllerId] : _controllerList[0];
        }
    }
}
