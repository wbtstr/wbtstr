using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WbTstr.Session.Performers.Interfaces;
using WbTstr.Session.Trackers.Interfaces;

namespace WbTstr.Session.Recorders.Interfaces
{
    public interface ISessionRecorder
    {
        ISessionRecorder Initialize(ISessionPerformer performer);
    }
}
