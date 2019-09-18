using Notes.Controller;
using Notes.Infrastructure;
using Notes.Model;
using System;
using System.Linq;

namespace Notes.View
{
    public class StartPageView : PageView<Page<CommandList>, CommandList>
    {
        private readonly StartController controller;

        public StartPageView(Page<CommandList> page, CommandList model, StartController controller) : base(page, model)
        {
            this.controller = controller;
        }

        public override void Render()
        {
            base.Render();
            Console.WriteLine("Command list:");
            if (model != null && model.Commands != null)
            {
                foreach (var (key, value) in model.Commands)
                {
                    Console.WriteLine($"[{key}]\t{value}");
                }
            }

            var command = Console.ReadLine();
            controller.RunCommand(command);
        }
    }
}
