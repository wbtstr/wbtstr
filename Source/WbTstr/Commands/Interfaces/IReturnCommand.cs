namespace WbTstr.Commands.Interfaces
{
    public interface IReturnCommand<T> : ICommand
    {
        T Execute(object webDriverObj);
    }
}
