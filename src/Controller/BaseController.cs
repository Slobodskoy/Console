using Notes.Extention;
using Notes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Notes.Controller
{
    public abstract class BaseController
    {
        protected IControllerFactory controllerFactory;
        public abstract void Run();

        public abstract IEnumerable<ControllerTypes> NextSteps {get; }

        public virtual string NextStepsHelpString
        {
            get
            {
                if (NextSteps != null && NextSteps.Any())
                {
                    return "Input command: " + string.Concat(NextSteps.Select(type => $"[{(int)type}] {type.ToName()}\t"));
                }
                return string.Empty;
            }
        }
        public void GoNextStep(ControllerTypes ctype)
        {
            if (NextSteps.Contains(ctype))
            {
                var controller = controllerFactory.GetController(ctype);
                controller.Run();
            }
        }
    }
}
