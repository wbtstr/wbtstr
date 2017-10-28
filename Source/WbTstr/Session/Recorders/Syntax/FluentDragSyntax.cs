using System;
using WbTstr.Commands;
using WbTstr.Commands.Interfaces;
using WbTstr.Proxies.Interfaces;
using WbTstr.Session.Performers.Interfaces;

namespace WbTstr.Session.Recorders.Syntax
{
    public class FluentDragSyntax
    {
        private enum RefToPointA { Selector, Element, Offset, SelectorOffset, ElementOffset }

        private readonly FluentSessionRecorder _recorder;
        private readonly ISessionPerformer _performer;
        private readonly RefToPointA _refToPointA;
        private readonly string _selectorA;
        private readonly IElement _elementA;
        private readonly int _xOffsetToA;
        private readonly int _yOffsetToA;

        public FluentDragSyntax(FluentSessionRecorder recorder, ISessionPerformer performer, string selectorA)
        {
            _recorder = recorder ?? throw new ArgumentNullException(nameof(recorder));
            _performer = performer ?? throw new ArgumentNullException(nameof(performer));
            _selectorA = selectorA ?? throw new ArgumentNullException(nameof(selectorA));
            _refToPointA = RefToPointA.Selector;
        }

        public FluentDragSyntax(FluentSessionRecorder recorder, ISessionPerformer performer, IElement elementA)
        {
            _recorder = recorder ?? throw new ArgumentNullException(nameof(recorder));
            _performer = performer ?? throw new ArgumentNullException(nameof(performer));
            _elementA = elementA ?? throw new ArgumentNullException(nameof(elementA));
            _refToPointA = RefToPointA.Element;
        }

        public FluentDragSyntax(FluentSessionRecorder recorder, ISessionPerformer performer, int xOffsetToA, int yOffsetToA)
        {
            _recorder = recorder ?? throw new ArgumentNullException(nameof(recorder));
            _performer = performer ?? throw new ArgumentNullException(nameof(performer));
            _xOffsetToA = xOffsetToA;
            _yOffsetToA = yOffsetToA;
            _refToPointA = RefToPointA.Offset;

            if (xOffsetToA < 0) throw new ArgumentException(nameof(xOffsetToA));
            if (yOffsetToA < 0) throw new ArgumentException(nameof(yOffsetToA));
        }

        /*-------------------------------------------------------------------*/

        public FluentSessionRecorder To(string selectorB)
        {
            IActionCommand command = null;
            switch (_refToPointA)
            {
                case RefToPointA.Selector:
                    command = new DragCommand(_selectorA, selectorB);
                    break;
                case RefToPointA.Element:
                    command = new DragCommand(_elementA, selectorB);
                    break;
                case RefToPointA.Offset:
                    command = new DragCommand(_xOffsetToA, _yOffsetToA, selectorB);
                    break;
            }

            _performer.Perform(command);
            return _recorder;
        }

        public FluentSessionRecorder To(IElement elementB)
        {
            IActionCommand command = null;
            switch (_refToPointA)
            {
                case RefToPointA.Selector:
                    command = new DragCommand(_selectorA, elementB);
                    break;
                case RefToPointA.Element:
                    throw new NotImplementedException();
                case RefToPointA.Offset:
                    command = new DragCommand(_xOffsetToA, _yOffsetToA, elementB);
                    break;
            }

            _performer.Perform(command);
            return _recorder;
        }

        public FluentSessionRecorder To(int xOffsetToB, int yOffsetToB)
        {
            IActionCommand command = null;
            switch (_refToPointA)
            {
                case RefToPointA.Selector:
                    command = new DragCommand(_selectorA, xOffsetToB, yOffsetToB);
                    break;
                case RefToPointA.Element:
                    command = new DragCommand(_elementA, xOffsetToB, yOffsetToB);
                    break;
                case RefToPointA.Offset:
                    command = new DragCommand(_xOffsetToA, _yOffsetToA, xOffsetToB, yOffsetToB);
                    break;
            }

            _performer.Perform(command);
            return _recorder;
        }
    }
}
