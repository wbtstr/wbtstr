using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using OpenQA.Selenium;
using WbTstr.Commands;
using WbTstr.Proxies.Interfaces;
using WbTstr.Session.Performers.Interfaces;
using WbTstr.Session.Recorders.Interfaces;
using WbTstr.WebDrivers;
using WbTstr.WebDrivers.Constants;
using WbTstr.Utilities.Constants;

namespace WbTstr.Session.Recorders
{
    public class SimpleSessionRecorder : ISessionRecorder
    {
        private bool _initialized;
        private ISessionPerformer _performer;

        public ISessionRecorder Initialize(ISessionPerformer performer)
        {
            if (_initialized)
            {
                throw new InvalidOperationException($"{nameof(SimpleSessionRecorder)} can be initialized only once.");
            }

            _performer = performer;

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

        public IElement FindOnPage(string selector)
        {
            var command = new FindCommand(selector);
            var element = _performer.PerformAndReturn(command);

            return element;
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

        public SimpleSessionRecorder Resize(int width, int height)
        {
            var command = new ResizeCommand(width, height);
            _performer.Perform(command);

            return this;
        }

        public SimpleSessionRecorder TakeScreenshot(string fileName = "screenshot.png", string fileDirectory = null)
        {
            var command = new ScreenshotCommand(fileName, fileDirectory);
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

        public SimpleSessionRecorder Wait(int miliseconds = 0, int seconds = 0, int minutes = 0)
        {
            var command = new WaitCommand(miliseconds, seconds, minutes);
            _performer.Perform(command);

            return this;
        }
    }
}
