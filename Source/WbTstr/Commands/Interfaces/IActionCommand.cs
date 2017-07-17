namespace WbTstr.Commands.Interfaces
{
    public interface IActionCommand : ICommand
    {
        void Execute(object webDriverObj);
    }
}
