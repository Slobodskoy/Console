using Notes.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.Controller
{
    public interface IController
    {
        void Run();
        void GoNextStep(ControllerTypes ctype);

        string NextStepsHelpString { get; }
    }
}
