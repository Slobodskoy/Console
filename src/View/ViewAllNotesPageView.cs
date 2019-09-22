using Notes.Controller;
using Notes.Extention;
using Notes.Infrastructure;
using Notes.Model;
using System;
using System.Collections.Generic;

namespace Notes.View
{
    public class ViewAllNotesPageView : PageView<List<Note>, IController>, IView<List<Note>, IController>
    {
        public ViewAllNotesPageView() : base(new PageInfo(), null) { }
        public ViewAllNotesPageView(PageInfo pageInfo, List<Note> model, IController controller) : base(pageInfo, model)
        {
            this.Controller = controller;
        }

        public override void Render()
        {
            base.Render();
            Console.WriteLine($"Id\tTitle");
            Console.WriteLine($"==\t=====");
            foreach (var item in Model)
            {
                Console.WriteLine($"{item.Id}\t{item.Title}");
            }
            Console.WriteLine(Controller.NextStepsHelpString);
            var command = Console.ReadLine();
            Controller.GoNextStep(command.GetControllerType());
        }
    }
}
