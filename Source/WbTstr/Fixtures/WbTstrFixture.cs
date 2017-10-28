using System;
using WbTstr.Session.Performers;
using WbTstr.Session.Performers.Interfaces;
using WbTstr.Session.Recorders;
using WbTstr.Session.Trackers;

namespace WbTstr.Fixtures
{
    public abstract class WbTstrFixture<P> : WbTstrFixtureBase<FluentSessionRecorder, P, ConsoleSessionTracker>
        where P : class, ISessionPerformer, new()
    {
    }

    public abstract class WbTstrFixture: WbTstrFixture<SequentialSessionPerformer>
    {                         
    }
}
