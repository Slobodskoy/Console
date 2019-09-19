using Notes.Controller;
using Notes.Infrastructure;
using Notes.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.View
{
    public class CreateNotePageView : PageView<Note>, IView<Note, ICreateNoteController>
    {
        public ICreateNoteController Controller { get; set; }

        public CreateNotePageView() : base(new PageInfo(), null) { }
        public CreateNotePageView(PageInfo pageInfo, Note model, ICreateNoteController controller) : base(pageInfo, model)
        {
            Controller = controller;
        }

        public override void Render()
        {
            base.Render();
            Console.WriteLine("Input note title:");
            Model.Title = Console.ReadLine();
            Controller.AddNote(Model);
            Console.WriteLine("Add next note [3], go to start - [0], help - [5]");
            var command = Console.ReadLine();
            Controller.RunCommand(command);
        }
    }
}
