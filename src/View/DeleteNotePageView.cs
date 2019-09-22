using System;
using System.Collections.Generic;
using System.Text;
using Notes.Controller;
using Notes.Extention;
using Notes.Infrastructure;
using Notes.Model;

namespace Notes.View
{
    public class DeleteNotePageView : PageView<Note, IDeleteNoteController>, IView<Note, IDeleteNoteController>
    {
        public DeleteNotePageView() : base(new PageInfo(), null)  { }
        public DeleteNotePageView(PageInfo pageInfo, Note model, IDeleteNoteController controller) : base(pageInfo, model)
        {
            this.Controller = controller;
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
                    Controller.Run(id);
                    return;
                }
            }
            else if (Model.Id == 0)
            {
                Console.WriteLine("Not found");
            }
            else
            {
                Console.WriteLine($"Note deleted");
            }
            Console.WriteLine(Controller.NextStepsHelpString);
            var command = Console.ReadLine();
            Controller.GoNextStep(command.GetControllerType());
        }
    }
}
