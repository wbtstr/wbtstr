﻿using System;
using WbTstr.Commands;
using WbTstr.Proxies.Interfaces;
using WbTstr.Session.Performers.Interfaces;
using WbTstr.Session.Recorders.Interfaces;
using WbTstr.Utilities.Constants;
using System.IO;
using System.Collections.Generic;
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

        /* Methods ----------------------------------------------------------*/

        public FluentSessionRecorder ClickOn(string selector, MouseClick clickType = MouseClick.Single)
        {
            var command = new ClickCommand(selector, clickType);
            _performer.Perform(command);

            return this;
        }

        public FluentSessionRecorder ClickOn(IElement element, MouseClick clickType = MouseClick.Single)
        {
            var command = new ClickCommand(element, clickType);
            _performer.Perform(command);

            return this;
        }

        public FluentSessionRecorder Drag(string selectorA, string selectorB)
        {
            var command = new DragCommand(selectorA, selectorB);
            _performer.Perform(command);

            return this;
        }

        public FluentSessionRecorder Drag(IElement elementA, IElement elementB)
        {
            var command = new DragCommand(elementA, elementB);
            _performer.Perform(command);

            return this;
        }

        public FluentSessionRecorder Drag(string selectorA, int xOffsetToB, int yOffsetToB)
        {
            var command = new DragCommand(selectorA, xOffsetToB, yOffsetToB);
            _performer.Perform(command);

            return this;
        }

        public FluentSessionRecorder Drag(IElement selectorA, int xOffsetToB, int yOffsetToB)
        {
            var command = new DragCommand(selectorA, xOffsetToB, yOffsetToB);
            _performer.Perform(command);

            return this;
        }

        public FluentSessionRecorder Drag(int xOffsetToA, int yOffsetToA, string selectorB)
        {
            var command = new DragCommand(xOffsetToA, yOffsetToA, selectorB);
            _performer.Perform(command);

            return this;
        }

        public FluentSessionRecorder Drag(int xOffsetToA, int yOffsetToA, IElement elementB)
        {
            var command = new DragCommand(xOffsetToA, yOffsetToA, elementB);
            _performer.Perform(command);

            return this;
        }

        public FluentSessionRecorder Drag(int xOffsetToA, int yOffsetToA, int xOffsetToB, int yOffsetToB)
        {
            var command = new DragCommand(xOffsetToA, yOffsetToA, xOffsetToB, yOffsetToB);
            _performer.Perform(command);

            return this;
        }

        public FluentSessionRecorder FindOnPage(string selector, out IElement element)
        {
            var command = new FindCommand(selector);
            element = _performer.PerformAndReturn(command);

            return this;
        }

        public IElement FindOnPage(string selector)
        {
            var command = new FindCommand(selector);
            var element = _performer.PerformAndReturn(command);

            return element;
        }

        public FluentSessionRecorder FindMultipleOnPage(string selector, out ICollection<IElement> elements)
        {
            var command = new FindMultipleCommand(selector);
            elements = _performer.PerformAndReturn(command);

            return this;
        }

        public ICollection<IElement> FindMultipleOnPage(string selector)
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

        public FluentSessionRecorder NavigateTo(string url)
        {
            var command = new NavigateCommand(url);
            _performer.Perform(command);

            return this;
        }

        public FluentSessionRecorder NavigateTo(Uri uri)
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

        public FluentSessionRecorder Type(string text, string selector, bool clearFirst = false)
        {
            var command = new TypeCommand(text, selector, clearFirst);
            _performer.Perform(command);

            return this;
        }

        public FluentSessionRecorder Type(string text, IElement element, bool clearFirst = false)
        {
            var command = new TypeCommand(text, element, clearFirst);
            _performer.Perform(command);

            return this;
        }

        public FluentSessionRecorder Select(string selector, params string[] values)
        {
            var command = new SelectCommand(selector, values);
            _performer.Perform(command);

            return this;
        }

        public FluentSessionRecorder Select(string selector, params int[] indexes)
        {
            var command = new SelectCommand(selector, indexes);
            _performer.Perform(command);

            return this;
        }

        public FluentSessionRecorder Select(IElement element, params string[] values)
        {
            var command = new SelectCommand(element, values);
            _performer.Perform(command);

            return this;
        }

        public FluentSessionRecorder Select(IElement element, params int[] indexes)
        {
            var command = new SelectCommand(element, indexes);
            _performer.Perform(command);

            return this;
        }

        public FluentSessionRecorder Wait(int milliseconds = 0, int seconds = 0, int minutes = 0)
        {
            var duration = new TimeSpan(0, 0, minutes, seconds, milliseconds);

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