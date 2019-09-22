using Notes.Controller;
using Notes.Extention;
using Notes.Infrastructure;
using Notes.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.View
{
    public class CreateNotePageView : PageView<Note, ICreateNoteController>, IView<Note, ICreateNoteController>
    {
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
            Console.WriteLine("Input note text:");
            Model.Text = Console.ReadLine();
            Controller.AddNote(Model);
            Console.WriteLine(Controller.NextStepsHelpString);
            var command = Console.ReadLine();
            Controller.GoNextStep(command.GetControllerType());
        }
    }
}
