using Notes.Controller;
using Notes.Extention;
using Notes.Infrastructure;
using Notes.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.View
{
    public class HelpView : PageView<Help, IController>, IView<Help, IController>
    {
        public HelpView() : base(new PageInfo(), null) { }
        public HelpView(PageInfo pageInfo, Help model, IController controller) : base(pageInfo, model)
        {
            this.Controller = controller;
        }

        public override void Render()
        {
            base.Render();
            Console.WriteLine("Help:");
            Console.WriteLine(Model.HelpText);
            Console.WriteLine(Controller.NextStepsHelpString);
            var command = Console.ReadLine();
            Controller.GoNextStep(command.GetControllerType());
        }
    }
}
