using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WbTstr.Session.Performers.Interfaces;
using WbTstr.Session.Recorders;
using WbTstr.Session.Trackers;

namespace WbTstr.Fixtures
{
    public abstract class SimpleFixture<P> : CustomFixture<SimpleSessionRecorder, P, SimpleSessionTracker>
        where P : class, ISessionPerformer, new()
    {

    }
}
