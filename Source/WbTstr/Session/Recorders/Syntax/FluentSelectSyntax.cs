using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WbTstr.Commands;
using WbTstr.Proxies.Interfaces;
using WbTstr.Session.Performers.Interfaces;

namespace WbTstr.Session.Recorders.Syntax
{
    public class FluentSelectSyntax
    {
        private readonly FluentSessionRecorder _recorder;
        private readonly ISessionPerformer _performer;
        private readonly string _text;
        private readonly int _index;

        public FluentSelectSyntax(FluentSessionRecorder recorder, ISessionPerformer performer, string text)
        {
            _recorder = recorder ?? throw new ArgumentNullException(nameof(recorder));
            _performer = performer ?? throw new ArgumentNullException(nameof(performer));
            _text = text ?? throw new ArgumentNullException(nameof(text));
        }

        public FluentSelectSyntax(FluentSessionRecorder recorder, ISessionPerformer performer, int index)
        {
            _recorder = recorder ?? throw new ArgumentNullException(nameof(recorder));
            _performer = performer ?? throw new ArgumentNullException(nameof(performer));
            _index = index;
        }

        /*-------------------------------------------------------------------*/

        public FluentSessionRecorder From(string selector)
        {
            if (selector == null) throw new ArgumentNullException(nameof(selector));
            if (string.IsNullOrWhiteSpace(selector)) throw new ArgumentException(nameof(selector));

            throw new NotImplementedException();
        }

        public FluentSessionRecorder From(IElement element)
        {
            if (element == null) throw new ArgumentNullException(nameof(element));

            throw new NotImplementedException();
        }
    }
}
