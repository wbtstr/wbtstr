using WbTstr.Session.Performers.Interfaces;

namespace WbTstr.Session.Recorders.Interfaces
{
    public interface ISessionRecorder
    {
        ISessionRecorder Initialize(ISessionPerformer performer);
    }
}
