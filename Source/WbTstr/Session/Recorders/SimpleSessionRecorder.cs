using System;
using System.Linq.Expressions;
using WbTstr.Commands;
using WbTstr.Proxies.Interfaces;
using WbTstr.Session.Performers.Interfaces;
using WbTstr.Session.Recorders.Interfaces;
using WbTstr.WebDrivers;
using WbTstr.WebDrivers.Constants;
using WbTstr.Utilities.Constants;
using System.IO;
using System.Collections.Generic;

namespace WbTstr.Session.Recorders
{
    public class SimpleSessionRecorder : ISessionRecorder
    {
        private bool _initialized;
        private ISessionPerformer _performer;

        public ISessionRecorder Initialize(ISessionPerformer performer)
        {
            _performer = performer ?? throw new ArgumentNullException(nameof(performer));

            if (_initialized)
            {
                throw new InvalidOperationException($"{nameof(SimpleSessionRecorder)} can be initialized only once.");
            }

            _initialized = true;
            return this;
        }

        /* Methods ----------------------------------------------------------*/

        public SimpleSessionRecorder CheckThat(string url = null, string title = null)
        {
            if (!string.IsNullOrEmpty(url))
            {
                var command = new AssertStateCommand(PropertyKey.Url, url);
                _performer.Perform(command);
            }

            if (!string.IsNullOrEmpty(title))
            {
                var command = new AssertStateCommand(PropertyKey.Title, title);
                _performer.Perform(command);
            }

            return this;
        }

        public SimpleSessionRecorder CheckThat(Expression<Func<WebDriverState, bool>> expression)
        {
            var command = new AssertStateExpCommand(expression);
            _performer.Perform(command);

            return this;
        }

        public SimpleSessionRecorder ClickOn(string selector, MouseClick clickType = MouseClick.Single)
        {
            var command = new ClickCommand(selector, clickType);
            _performer.Perform(command);

            return this;
        }

        public SimpleSessionRecorder ClickOn(IElement element, MouseClick clickType = MouseClick.Single)
        {
            var command = new ClickCommand(element, clickType);
            _performer.Perform(command);

            return this;
        }

        public SimpleSessionRecorder Drag(string selectorA, string selectorB)
        {
            var command = new DragCommand(selectorA, selectorB);
            _performer.Perform(command);

            return this;
        }

        public SimpleSessionRecorder Drag(IElement elementA, IElement elementB)
        {
            var command = new DragCommand(elementA, elementB);
            _performer.Perform(command);

            return this;
        }

        public SimpleSessionRecorder Drag(string selectorA, int xOffsetToB, int yOffsetToB)
        {
            var command = new DragCommand(selectorA, xOffsetToB, yOffsetToB);
            _performer.Perform(command);

            return this;
        }

        public SimpleSessionRecorder Drag(IElement selectorA, int xOffsetToB, int yOffsetToB)
        {
            var command = new DragCommand(selectorA, xOffsetToB, yOffsetToB);
            _performer.Perform(command);

            return this;
        }

        public SimpleSessionRecorder Drag(int xOffsetToA, int yOffsetToA, string selectorB)
        {
            var command = new DragCommand(xOffsetToA, yOffsetToA, selectorB);
            _performer.Perform(command);

            return this;
        }

        public SimpleSessionRecorder Drag(int xOffsetToA, int yOffsetToA, IElement elementB)
        {
            var command = new DragCommand(xOffsetToA, yOffsetToA, elementB);
            _performer.Perform(command);

            return this;
        }

        public SimpleSessionRecorder Drag(int xOffsetToA, int yOffsetToA, int xOffsetToB, int yOffsetToB)
        {
            var command = new DragCommand(xOffsetToA, yOffsetToA, xOffsetToB, yOffsetToB);
            _performer.Perform(command);

            return this;
        }

        public IElement FindOnPage(string selector)
        {
            var command = new FindCommand(selector);
            var element = _performer.PerformAndReturn(command);

            return element;
        }

        public ICollection<IElement> FindMultipleOnPage(string selector)
        {
            var command = new FindMultipleCommand(selector);
            var elements = _performer.PerformAndReturn(command);

            return elements;
        }

        public SimpleSessionRecorder Focus(string selector)
        {
            var command = new FocusCommand(selector);
            _performer.Perform(command);

            return this;
        }

        public SimpleSessionRecorder Focus(IElement element)
        {
            var command = new FocusCommand(element);
            _performer.Perform(command);

            return this;
        }

        public SimpleSessionRecorder Hover(string selector)
        {
            var command = new HoverCommand(selector);
            _performer.Perform(command);

            return this;
        }

        public SimpleSessionRecorder Hover(IElement element)
        {
            var command = new HoverCommand(element);
            _performer.Perform(command);

            return this;
        }

        public SimpleSessionRecorder NavigateTo(string url)
        {
            var command = new NavigateCommand(url);
            _performer.Perform(command);

            return this;
        }

        public SimpleSessionRecorder NavigateTo(Uri uri)
        {
            var command = new NavigateCommand(uri);
            _performer.Perform(command);

            return this;
        }

        public SimpleSessionRecorder ResizeWindow(int width, int height)
        {
            var command = new ResizeCommand(width, height);
            _performer.Perform(command);

            return this;
        }

        public SimpleSessionRecorder MaximizeWindow()
        {
            var command = new MaximizeCommand();
            _performer.Perform(command);

            return this;
        }

        public SimpleSessionRecorder TakeScreenshot(string fileName = "screenshot.png", string fileDirectory = null)
        {
            var command = new ScreenshotCommand(fileName, fileDirectory ?? Path.GetTempPath());
            _performer.Perform(command);

            return this;
        }

        public SimpleSessionRecorder Type(string text)
        {
            var command = new TypeWindowCommand(text);
            _performer.Perform(command);

            return this;
        }

        public SimpleSessionRecorder Type(string text, string selector, bool clearFirst = false)
        {
            var command = new TypeCommand(text, selector, clearFirst);
            _performer.Perform(command);

            return this;
        }

        public SimpleSessionRecorder Type(string text, IElement element, bool clearFirst = false)
        {
            var command = new TypeCommand(text, element, clearFirst);
            _performer.Perform(command);

            return this;
        }

        public SimpleSessionRecorder Wait(int milliseconds = 0, int seconds = 0, int minutes = 0)
        {
            var duration = new TimeSpan(0, 0, minutes, seconds, milliseconds);

            var command = new WaitCommand(duration);
            _performer.Perform(command);

            return this;
        }

        public SimpleSessionRecorder WaitUntil(Func<bool> predicate, TimeSpan? interval, TimeSpan? timeout)
        {
            var defaultInterval = new TimeSpan(0, 0, 1);
            var defaultTimeout = new TimeSpan(0, 0, 10);

            var command = new WaitUntilCommand(predicate, interval ?? defaultInterval, timeout ?? defaultTimeout);
            _performer.Perform(command);

            return this;
        }

        public T ExecuteJs<T>(string jsExpression, bool async = false)
        {
            var command = new ExecuteJsCommand<T>(jsExpression, async);
            var returnValue = _performer.PerformAndReturn(command);

            return returnValue;
        }
    }
}
