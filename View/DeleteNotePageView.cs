using System;
using System.Collections.Generic;
using System.Text;
using Notes.Controller;
using Notes.Infrastructure;
using Notes.Model;

namespace Notes.View
{
    public class DeleteNotePageView : PageView<Page<Note>, Note>
    {
        private DeleteNoteController controller;

        public DeleteNotePageView(Page<Note> page, Note model, DeleteNoteController controller) : base(page, model)
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
                Console.WriteLine($"Note deleted");
            }
            Console.WriteLine("Input command: [0] - return to start, [5] - help");
            var command = Console.ReadLine();
            controller.RunCommand(command);
        }
    }
}
