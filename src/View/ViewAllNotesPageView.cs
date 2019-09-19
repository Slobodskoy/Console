using Notes.Controller;
using Notes.Infrastructure;
using Notes.Model;
using System;
using System.Collections.Generic;

namespace Notes.View
{
    public class ViewAllNotesPageView : PageView<List<Note>>, IView<List<Note>>
    {
        private readonly IController controller;

        public ViewAllNotesPageView() : base(new PageInfo(), null) { }
        public ViewAllNotesPageView(PageInfo pageInfo, List<Note> model, IController controller) : base(pageInfo, model)
        {
            this.controller = controller;
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
            Console.WriteLine("Input command: [0] - return to start, [5] - help");
            var command = Console.ReadLine();
            controller.RunCommand(command);
        }
    }
}
