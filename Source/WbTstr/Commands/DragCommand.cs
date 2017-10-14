using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using WbTstr.Commands.Abstracts;
using WbTstr.Proxies.Extensions;
using WbTstr.Proxies.Interfaces;
using WbTstr.WebDrivers.Extensions;

namespace WbTstr.Commands
{
    internal class DragCommand : WbTstrActionCommand
    {
        private readonly string _selectorA;
        private readonly IElement _elementA;
        private readonly int? _xOffsetToA;
        private readonly int? _yOffsetToA;
        private readonly string _selectorB;
        private readonly IElement _elementB;
        private readonly int? _xOffsetToB;
        private readonly int? _yOffsetToB;

        public DragCommand(string selectorA, string selectorB)
        {
            if (selectorA == null) throw new ArgumentNullException(nameof(selectorA));
            if (selectorB == null) throw new ArgumentNullException(nameof(selectorB));

            _selectorA = !string.IsNullOrWhiteSpace(selectorA) ? selectorA : throw new ArgumentException(nameof(selectorA));
            _selectorB = !string.IsNullOrWhiteSpace(selectorB) ? selectorB : throw new ArgumentException(nameof(selectorB));
        }

        public DragCommand(string selectorA, IElement elementB)
        {
            if (selectorA == null) throw new ArgumentNullException(nameof(selectorA));

            _selectorA = !string.IsNullOrWhiteSpace(selectorA) ? selectorA : throw new ArgumentException(nameof(selectorA));
            _elementB = elementB ?? throw new ArgumentNullException(nameof(elementB));
        }

        public DragCommand(string selectorA, int xOffsetToB, int yOffsetToB)
        {
            if (selectorA == null) throw new ArgumentNullException(nameof(selectorA));

            _selectorA = !string.IsNullOrWhiteSpace(selectorA) ? selectorA : throw new ArgumentException(nameof(selectorA));
            _xOffsetToB = xOffsetToB >= 0 ? xOffsetToB : throw new ArgumentException(nameof(xOffsetToB));
            _yOffsetToB = yOffsetToB >= 0 ? yOffsetToB : throw new ArgumentException(nameof(xOffsetToB));
        }

        public DragCommand(IElement elementA, IElement elementB)
        {
            _elementA = elementA ?? throw new ArgumentNullException(nameof(elementA));
            _elementB = elementB ?? throw new ArgumentNullException(nameof(elementB));
        }

        public DragCommand(IElement elementA, string selectorB)
        {
            if (selectorB == null) throw new ArgumentNullException(nameof(selectorB));

            _selectorB = !string.IsNullOrWhiteSpace(_selectorB) ? selectorB : throw new ArgumentException(nameof(selectorB));
            _elementA = elementA ?? throw new ArgumentNullException(nameof(elementA));
        }

        public DragCommand(IElement elementA, int xOffsetToB, int yOffsetToB)
        {
            _elementA = elementA ?? throw new ArgumentNullException(nameof(elementA));
            _xOffsetToB = xOffsetToB >= 0 ? xOffsetToB : throw new ArgumentException(nameof(xOffsetToB));
            _yOffsetToB = yOffsetToB >= 0 ? yOffsetToB : throw new ArgumentException(nameof(xOffsetToB));
        }

        public DragCommand(int xOffsetToA, int yOffsetToA, string selectorB)
        {
            if (selectorB == null) throw new ArgumentNullException(nameof(selectorB));

            _xOffsetToA = xOffsetToA >= 0 ? xOffsetToA : throw new ArgumentException(nameof(xOffsetToA));
            _yOffsetToA = yOffsetToA >= 0 ? yOffsetToA : throw new ArgumentException(nameof(yOffsetToA));
            _selectorB = !string.IsNullOrWhiteSpace(selectorB) ? selectorB : throw new ArgumentException(nameof(selectorB));
        }

        public DragCommand(int xOffsetToA, int yOffsetToA, IElement elementB)
        {
            _xOffsetToA = xOffsetToA >= 0 ? xOffsetToA : throw new ArgumentException(nameof(xOffsetToA));
            _yOffsetToA = yOffsetToA >= 0 ? yOffsetToA : throw new ArgumentException(nameof(yOffsetToA));
            _elementB = elementB ?? throw new ArgumentNullException(nameof(elementB));
        }

        public DragCommand(int xOffsetToA, int yOffsetToA, int xOffsetToB, int yOffsetToB)
        {
            _xOffsetToA = xOffsetToA >= 0 ? xOffsetToA : throw new ArgumentException(nameof(xOffsetToA));
            _yOffsetToA = yOffsetToA >= 0 ? yOffsetToA : throw new ArgumentException(nameof(yOffsetToA));
            _xOffsetToB = xOffsetToB >= 0 ? xOffsetToB : throw new ArgumentException(nameof(xOffsetToB));
            _yOffsetToB = yOffsetToB >= 0 ? yOffsetToB : throw new ArgumentException(nameof(xOffsetToB));
        }

        /*-------------------------------------------------------------------*/

        protected override void Execute(IWebDriver webDriver)
        {
            var webElementA = new Lazy<IWebElement>(() => _elementA?.AsWebElement() ?? webDriver.FindElementBySelector(_selectorA));
            var webElementB = new Lazy<IWebElement>(() => _elementB?.AsWebElement() ?? webDriver.FindElementBySelector(_selectorB));

            if (_xOffsetToA.HasValue)
            {
                if (_xOffsetToB.HasValue)
                {
                    PerformDragCoordinateToCoordinate(webDriver, _xOffsetToA.Value, _yOffsetToA.Value, _xOffsetToB.Value, _yOffsetToB.Value);
                }
                else
                {
                    PerformDragCoordinateToElement(webDriver, _xOffsetToA.Value, _yOffsetToA.Value, webElementB.Value);
                }
            }
            else if (_xOffsetToB.HasValue)
            {
                PerformDragElementToCoordinate(webDriver, webElementA.Value, _xOffsetToB.Value, _yOffsetToB.Value);
            }
            else
            {
                PerformDragElementToElement(webDriver, webElementA.Value, webElementB.Value);
            }
        }

        public virtual void PerformDragElementToElement(IWebDriver webDriver, IWebElement webElementA, IWebElement webElementB)
        {
            var interaction = new Actions(webDriver);
            interaction
                .DragAndDrop(webElementA, webElementB)
                .Build()
                .Perform();
        }

        public virtual void PerformDragElementToCoordinate(IWebDriver webDriver, IWebElement webElement, int x, int y)
        {
            var interaction = new Actions(webDriver);
            interaction
                .DragAndDropToOffset(webElement, x, y)
                .Build()
                .Perform();
        }

        public virtual void PerformDragCoordinateToElement(IWebDriver webDriver, int x, int y, IWebElement webElement)
        {
            var root = webDriver.FindElementBySelector("body");

            var interaction = new Actions(webDriver);
            interaction
                .MoveToElement(root, x, y)
                .ClickAndHold()
                .MoveToElement(webElement)
                .Release()
                .Build()
                .Perform();
        }

        public virtual void PerformDragCoordinateToCoordinate(IWebDriver webDriver, int x1, int y1, int x2, int y2)
        {
            var root = webDriver.FindElementBySelector("body");

            var interaction = new Actions(webDriver);
            interaction
                .MoveToElement(root, x1, y1)
                .ClickAndHold()
                .MoveToElement(root, x2, y2)
                .Release()
                .Build()
                .Perform();
        }

        public override string ToString()
        {
            return "TODO: DragCommand.ToString()";
        }
    }
}
