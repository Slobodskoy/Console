using Notes.Controller;
using Notes.Extention;
using Notes.Infrastructure;
using Notes.Model;
using System;
using System.Linq;

namespace Notes.View
{
    public class StartPageView : PageView<CommandList, IController>, IView<CommandList, IController>
    {
        public StartPageView() : base(new PageInfo(), null) { }
        public StartPageView(PageInfo pageInfo, CommandList model, IController controller) : base(pageInfo, model)
        {
            this.Controller = controller;
        }

        public override void Render()
        {
            base.Render();
            Console.WriteLine("Command list:");
            if (Model != null && Model.Commands != null)
            {
                foreach (var (key, value) in Model.Commands)
                {
                    Console.WriteLine($"[{(int)key}]\t{value}");
                }
            }

            var command = Console.ReadLine();
            Controller.GoNextStep(command.GetControllerType());
        }
    }
}
