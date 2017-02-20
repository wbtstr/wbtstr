using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WbTstr.Session.Performers;
using WbTstr.Session.Performers.Interfaces;
using WbTstr.Session.Recorders;
using WbTstr.Session.Trackers;

namespace WbTstr.Fixtures
{
    public abstract class SimpleWbTstrFixture<P> : WbTstrFixture<SimpleSessionRecorder, P, SimpleSessionTracker>
        where P : class, ISessionPerformer, new()
    {

    }

    public abstract class SimpleWbTstrFixture: SimpleWbTstrFixture<SequentialSessionPerformer>
    {
                        
    }
}
