using Notes.Controller;
using Notes.Infrastructure;
using Notes.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.View
{
    public class HelpView : PageView<Page<Help>, Help>
    {
        private readonly HelpController controller;

        public HelpView(Page<Help> info, Help model, HelpController controller) : base(info, model)
        {
            this.controller = controller;
        }

        public override void Render()
        {
            base.Render();
            Console.WriteLine("Help:");
            Console.WriteLine(model.HelpText);
            Console.WriteLine("Input command: [0] - return to start");
            var command = Console.ReadLine();
            controller.RunCommand(command);
        }
    }
}
