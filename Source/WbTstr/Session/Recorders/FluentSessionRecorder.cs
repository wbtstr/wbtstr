using System;
using System.Collections.Generic;
using System.IO;
using WbTstr.Commands;
using WbTstr.Proxies.Interfaces;
using WbTstr.Session.Performers.Interfaces;
using WbTstr.Session.Recorders.Interfaces;
using WbTstr.Session.Recorders.Syntax;
using WbTstr.Utilities.Constants;
using WbTstr.WebDrivers.Interfaces;

namespace WbTstr.Session.Recorders
{
    public class FluentSessionRecorder : ISessionRecorder
    {
        private bool _initialized;
        private ISessionPerformer _performer;

        public ISessionRecorder Initialize(ISessionPerformer performer)
        {
            _performer = performer ?? throw new ArgumentNullException(nameof(performer));

            if (_initialized)
            {
                throw new InvalidOperationException($"{nameof(FluentSessionRecorder)} can be initialized only once.");
            }

            _initialized = true;
            return this;
        }

        /*-------------------------------------------------------------------*/

        public FluentAppendSyntax Append(string text)
        {
            return new FluentAppendSyntax(this, _performer, text);
        }

        public FluentAppendSyntax Append(int number)
        {
            return new FluentAppendSyntax(this, _performer, $"{number}");
        }

        public FluentSessionRecorder Click(string selector)
        {
            var command = new ClickCommand(selector, MouseClick.Single);
            _performer.Perform(command);

            return this;
        }

        public FluentSessionRecorder Click(IElement element)
        {
            var command = new ClickCommand(element, MouseClick.Single);
            _performer.Perform(command);

            return this;
        }

        public FluentDragSyntax Drag(string selectorA)
        {
            return new FluentDragSyntax(this, _performer, selectorA);
        }

        public FluentDragSyntax Drag(IElement elementA)
        {
            return new FluentDragSyntax(this, _performer, elementA);
        }

        public FluentDragSyntax Drag(int xOffsetToA, int yOffsetToA)
        {
            return new FluentDragSyntax(this, _performer, xOffsetToA, yOffsetToA);
        }

        public FluentSessionRecorder DoubleClick(string selector)
        {
            var command = new ClickCommand(selector, MouseClick.Double);
            _performer.Perform(command);

            return this;
        }

        public FluentSessionRecorder DoubleClick(IElement element)
        {
            var command = new ClickCommand(element, MouseClick.Double);
            _performer.Perform(command);

            return this;
        }

        public FluentEnterSyntax Enter(string text)
        {
            return new FluentEnterSyntax(this, _performer, text);
        }

        public FluentEnterSyntax Enter(int number)
        {
            return new FluentEnterSyntax(this, _performer, $"{number}");
        }

        public FluentSessionRecorder Find(string selector, out IElement element)
        {
            var command = new FindCommand(selector);
            element = _performer.PerformAndReturn(command);

            return this;
        }

        public IElement Find(string selector)
        {
            var command = new FindCommand(selector);
            var element = _performer.PerformAndReturn(command);

            return element;
        }

        public FluentSessionRecorder FindMultiple(string selector, out ICollection<IElement> elements)
        {
            var command = new FindMultipleCommand(selector);
            elements = _performer.PerformAndReturn(command);

            return this;
        }

        public ICollection<IElement> FindMultiple(string selector)
        {
            var command = new FindMultipleCommand(selector);
            var elements = _performer.PerformAndReturn(command);

            return elements;
        }

        public FluentSessionRecorder Focus(string selector)
        {
            var command = new FocusCommand(selector);
            _performer.Perform(command);

            return this;
        }

        public FluentSessionRecorder Focus(IElement element)
        {
            var command = new FocusCommand(element);
            _performer.Perform(command);

            return this;
        }

        public FluentSessionRecorder Hover(string selector)
        {
            var command = new HoverCommand(selector);
            _performer.Perform(command);

            return this;
        }

        public FluentSessionRecorder Hover(IElement element)
        {
            var command = new HoverCommand(element);
            _performer.Perform(command);

            return this;
        }

        public FluentSessionRecorder Open(string url)
        {
            var command = new NavigateCommand(url);
            _performer.Perform(command);

            return this;
        }

        public FluentSessionRecorder Open(Uri uri)
        {
            var command = new NavigateCommand(uri);
            _performer.Perform(command);

            return this;
        }

        public FluentSessionRecorder ResizeWindow(int width, int height)
        {
            var command = new ResizeCommand(width, height);
            _performer.Perform(command);

            return this;
        }

        public FluentSessionRecorder RichtClick(string selector)
        {
            var command = new ClickCommand(selector, MouseClick.Context);
            _performer.Perform(command);

            return this;
        }

        public FluentSessionRecorder RichtClick(IElement element)
        {
            var command = new ClickCommand(element, MouseClick.Context);
            _performer.Perform(command);

            return this;
        }

        public FluentSessionRecorder MaximizeWindow()
        {
            var command = new MaximizeCommand();
            _performer.Perform(command);

            return this;
        }

        public FluentSessionRecorder TakeScreenshot(string fileName = "screenshot.png", string fileDirectory = null)
        {
            var command = new ScreenshotCommand(fileName, fileDirectory ?? Path.GetTempPath());
            _performer.Perform(command);

            return this;
        }

        public FluentSessionRecorder Type(string text)
        {
            var command = new TypeWindowCommand(text);
            _performer.Perform(command);

            return this;
        }

        public FluentSelectSyntax Select(string text)
        {
            return new FluentSelectSyntax(this, _performer, text);
        }

        public FluentSelectSyntax Select(int index)
        {
            return new FluentSelectSyntax(this, _performer, index);
        }

        public FluentSessionRecorder Wait(int milliseconds = 0, int seconds = 0, int minutes = 0)
        {
            var duration = new TimeSpan(0, 0, minutes, seconds, milliseconds);

            return Wait(duration);
        }

        public FluentSessionRecorder Wait(TimeSpan duration)
        {
            var command = new WaitCommand(duration);
            _performer.Perform(command);

            return this;
        }

        public FluentSessionRecorder WaitUntil(Func<bool> predicate, TimeSpan? interval = null, TimeSpan? timeout = null)
        {
            var defaultInterval = TimeSpan.FromSeconds(1);
            var defaultTimeout = TimeSpan.FromSeconds(5);

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

        public FluentSessionRecorder Authenticate(string username, string password, TimeSpan? timeout = null)
        {
            var defaultTimeout = TimeSpan.FromSeconds(5);

            var command = new AuthenticateCommand(username, password, timeout ?? defaultTimeout);
            _performer.Perform(command);

            return this;
        }

        public FluentSessionRecorder SetCookie(ICookie cookie)
        {
            var command = new SetCookieCommand(cookie);
            _performer.Perform(command);

            return this;
        }

        public FluentSessionRecorder SetCookie(string name, string value, string domain = null, string path = null, DateTime? expiry = null)
        {
            var command = new SetCookieCommand(name, value, domain, path, expiry);
            _performer.Perform(command);

            return this;
        }

        public FluentSessionRecorder DeleteCookie(string name)
        {
            var command = new DeleteCookieCommand(name);
            _performer.Perform(command);

            return this;
        }

        public FluentSessionRecorder CapturePage(out IPage page)
        {
            var command = new CapturePageCommand();
            page = _performer.PerformAndReturn(command);

            return this;
        }

        public IPage CapturePage()
        {
            var command = new CapturePageCommand();
            return _performer.PerformAndReturn(command);
        }
    }
}
