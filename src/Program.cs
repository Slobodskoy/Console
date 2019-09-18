using Notes.Controller;
using Notes.DB;
using Notes.Extention;
using System;

namespace Notes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = ConsoleExt.ScreenWidth;
            var repository = new MemoryRepository();
            var ControllerFactory = new ControllerFactory(repository);
            var startController = ControllerFactory.GetController(0);
            startController.Run();
        }
    }
}
