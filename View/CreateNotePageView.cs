using Notes.Controller;
using Notes.Infrastructure;
using Notes.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.View
{
    public class CreateNotePageView : PageView<Page<Note>, Note>
    {
        private readonly CreateNoteController controller;

        public CreateNotePageView(Page<Note> page, Note model, CreateNoteController controller) : base(page, model)
        {
            this.controller = controller;
        }

        public override void Render()
        {
            base.Render();
            Console.WriteLine("Input note title:");
            model.Title = Console.ReadLine();
            controller.AddNote(model);
            Console.WriteLine("Add next note [3], go to start - [0], help - [5]");
            var command = Console.ReadLine();
            controller.RunCommand(command);
        }
    }
}
