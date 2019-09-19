using Notes.Controller;
using Notes.Infrastructure;
using Notes.Model;
using System;

namespace Notes.View
{
    public class ViewNotePageView : PageView<Note>, IView<Note>
    {
        private readonly IViewNoteController controller;

        public ViewNotePageView() : base(new PageInfo(), null) { }
        public ViewNotePageView(PageInfo pageInfo, Note model, IViewNoteController controller) : base(pageInfo, model)
        {
            this.controller = controller;
        }

        public override void Render()
        {
            base.Render();
            if (Model == null)
            {
                Console.WriteLine("Input note Id:");
                int id;
                var idStr = Console.ReadLine();
                if (int.TryParse(idStr, out id))
                {
                    controller.Run(id);
                    return;
                }
            }
            else if (Model.Id == 0)
            {
                Console.WriteLine("Not found");
            }
            else
            {
                Console.WriteLine($"Id\tTitle");
                Console.WriteLine($"==\t=====");
                Console.WriteLine($"{Model.Id}\t{Model.Title}");
            }
            Console.WriteLine("Input command: [0] - return to start, [5] - help");
            var command = Console.ReadLine();
            controller.RunCommand(command);
        }

    }
}
