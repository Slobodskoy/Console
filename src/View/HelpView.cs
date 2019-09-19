using Notes.Controller;
using Notes.Infrastructure;
using Notes.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.View
{
    public class HelpView : PageView<Help>, IView<Help>
    {
        private readonly IController controller;

        public HelpView() : base(new PageInfo(), null) { }
        public HelpView(PageInfo pageInfo, Help model, IController controller) : base(pageInfo, model)
        {
            this.controller = controller;
        }

        public override void Render()
        {
            base.Render();
            Console.WriteLine("Help:");
            Console.WriteLine(Model.HelpText);
            Console.WriteLine("Input command: [0] - return to start");
            var command = Console.ReadLine();
            controller.RunCommand(command);
        }
    }
}
