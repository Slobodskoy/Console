using Notes.Controller;
using Notes.Extention;
using Notes.Infrastructure;
using Notes.Model;
using System;

namespace Notes.View
{
    public class ViewNotePageView : PageView<Note, IViewNoteController>, IView<Note, IViewNoteController>
    {
        public ViewNotePageView() : base(new PageInfo(), null) { }
        public ViewNotePageView(PageInfo pageInfo, Note model, IViewNoteController controller) : base(pageInfo, model)
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
                Console.WriteLine($"Id\tTitle\tText");
                Console.WriteLine($"==\t=====\t====");
                Console.WriteLine($"{Model.Id}\t{Model.Title}\t{Model.Text}");
            }
            Console.WriteLine(Controller.NextStepsHelpString);
            var command = Console.ReadLine();
            Controller.GoNextStep(command.GetControllerType());
        }

    }
}
