using Notes.Model;

namespace Notes.Controller
{
    public interface IControllerFactory
    {
        IController GetController(ControllerTypes type);
    }
}