using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WbTstr.Session.Trackers.Interfaces;

namespace WbTstr.Session.Trackers
{
    public class SimpleSessionTracker : ISessionTracker
    {
        public ISessionTracker Initialize()
        {
            return this;
        }
    }
}
