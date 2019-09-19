using Notes.Controller;
using Notes.Infrastructure;
using Notes.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.View
{
    public class CreateNotePageView : PageView<Note>, IView<Note>
    {
        private readonly ICreateNoteController controller;

        public CreateNotePageView() : base(new PageInfo(), null) { }
        public CreateNotePageView(PageInfo pageInfo, Note model, ICreateNoteController controller) : base(pageInfo, model)
        {
            this.controller = controller;
        }

        public override void Render()
        {
            base.Render();
            Console.WriteLine("Input note title:");
            Model.Title = Console.ReadLine();
            controller.AddNote(Model);
            Console.WriteLine("Add next note [3], go to start - [0], help - [5]");
            var command = Console.ReadLine();
            controller.RunCommand(command);
        }
    }
}
