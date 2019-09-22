using System;
using System.Collections.Generic;
using System.Text;
using Notes.Controller;
using Notes.Extention;
using Notes.Infrastructure;
using Notes.Model;

namespace Notes.View
{
    public class EditNotePageView : PageView<Note, IEditNoteController>, IView<Note, IEditNoteController>
    {
        public EditNotePageView() : base(new PageInfo(), null)  { }
        public EditNotePageView(PageInfo pageInfo, Note model, IEditNoteController controller) : base(pageInfo, model)
        {
            this.Controller = controller;
        }

        public override void Render()
        {
            base.Render();
            if (Model == null)
            {
                RequestEditedNoteId();
            }
            else if (Model.Id != 0)
            {
                UpdateNote(); 
            }
            else
            {
                Console.WriteLine("Not found");
            }
            Console.WriteLine(Controller.NextStepsHelpString);
            var command = Console.ReadLine();
            Controller.GoNextStep(command.GetControllerType());
        }

        private void RequestEditedNoteId()
        {
            Console.WriteLine("Input edited note Id:");
            int id;
            var idStr = Console.ReadLine();
            if (int.TryParse(idStr, out id))
            {
                var note = Controller.GetNoteById(id);
                if (note == null)
                {
                    Console.WriteLine($"Not found");
                }
                else
                {
                    Controller.Run(id);
                }
            }
        }

        private void UpdateNote()
        {
            Console.WriteLine($"Old note text:");
            Console.WriteLine(Model.Text);
            Console.WriteLine("New note text:");
            Model.Text = Console.ReadLine();
            if (Controller.UpdateNote(Model))
            {
                Console.WriteLine("Done");
            }
            else
            {
                Console.WriteLine("Note not updated");
            }
        }
    }
}
