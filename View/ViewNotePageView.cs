using Notes.Controller;
using Notes.Infrastructure;
using Notes.Model;
using System;

namespace Notes.View
{
    public class ViewNotePageView : PageView<Page<Note>, Note>
    {
        private readonly ViewNoteController controller;

        public ViewNotePageView(Page<Note> page, Note model, ViewNoteController controller) : base(page, model)
        {
            this.controller = controller;
        }

        public override void Render()
        {
            base.Render();
            if (model == null)
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
            else if (model.Id == 0)
            {
                Console.WriteLine("Not found");
            }
            else
            {
                Console.WriteLine($"Id\tTitle");
                Console.WriteLine($"==\t=====");
                Console.WriteLine($"{model.Id}\t{model.Title}");
            }
            Console.WriteLine("Input command: [0] - return to start, [5] - help");
            var command = Console.ReadLine();
            controller.RunCommand(command);
        }

    }
}
