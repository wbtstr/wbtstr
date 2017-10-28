using System;
using WbTstr.Commands;
using WbTstr.Proxies.Interfaces;
using WbTstr.Session.Performers.Interfaces;

namespace WbTstr.Session.Recorders.Syntax
{
    public class FluentAppendSyntax
    {
        private readonly FluentSessionRecorder _recorder;
        private readonly ISessionPerformer _performer;
        private readonly string _text;

        public FluentAppendSyntax(FluentSessionRecorder recorder, ISessionPerformer performer, string text)
        {
            _recorder = recorder ?? throw new ArgumentNullException(nameof(recorder));
            _performer = performer ?? throw new ArgumentNullException(nameof(performer));
            _text = text ?? throw new ArgumentNullException(nameof(text));
        }

        /*-------------------------------------------------------------------*/

        public FluentSessionRecorder In(string selector)
        {
            if (selector == null) throw new ArgumentNullException(nameof(selector));
            if (string.IsNullOrWhiteSpace(selector)) throw new ArgumentException(nameof(selector));

            var command = new TypeCommand(_text, selector, false);
            _performer.Perform(command);

            return _recorder;
        }

        public FluentSessionRecorder In(IElement element)
        {
            if (element == null) throw new ArgumentNullException(nameof(element));

            var command = new TypeCommand(_text, element, false);
            _performer.Perform(command);

            return _recorder;
        }
    }
}