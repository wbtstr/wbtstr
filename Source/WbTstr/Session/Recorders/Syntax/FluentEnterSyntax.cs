using System;
using WbTstr.Commands;
using WbTstr.Proxies.Interfaces;
using WbTstr.Session.Performers.Interfaces;

namespace WbTstr.Session.Recorders.Syntax
{
    public class FluentEnterSyntax
    {
        private readonly FluentSessionRecorder _recorder;
        private readonly ISessionPerformer _performer;
        private readonly string _text;

        public FluentEnterSyntax(FluentSessionRecorder recorder, ISessionPerformer performer, string text)
        {
            _recorder = recorder ?? throw new ArgumentNullException(nameof(recorder));
            _performer = performer ?? throw new ArgumentNullException(nameof(performer));
            _text = text ?? throw new ArgumentNullException(nameof(text));
        }

        /*-------------------------------------------------------------------*/

        public FluentSessionRecorder In(string selector)
        {
            var command = new TypeCommand(_text, selector, true);
            _performer.Perform(command);

            return _recorder;
        }

        public FluentSessionRecorder In(IElement element)
        {
            var command = new TypeCommand(_text, element, true);
            _performer.Perform(command);

            return _recorder;
        }
    }
}
