namespace Notes.Controller
{
    public interface IControllerFactory
    {
        IController GetController(int controllerId);
    }
}