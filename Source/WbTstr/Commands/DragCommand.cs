﻿using OpenQA.Selenium;
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

        public DragCommand(IElement elementA, IElement elementB)
        {
            _elementA = elementA ?? throw new ArgumentNullException(nameof(elementA));
            _elementB = elementB ?? throw new ArgumentNullException(nameof(elementB));
        }

        public DragCommand(string selectorA, int xOffsetToB, int yOffsetToB)
        {
            if (selectorA == null) throw new ArgumentNullException(nameof(selectorA));

            _selectorA = !string.IsNullOrWhiteSpace(selectorA) ? selectorA : throw new ArgumentException(nameof(selectorA));
            _xOffsetToB = xOffsetToB >= 0 ? xOffsetToB : throw new ArgumentException(nameof(xOffsetToB));
            _yOffsetToB = yOffsetToB >= 0 ? yOffsetToB : throw new ArgumentException(nameof(xOffsetToB));
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

        /* Methods ----------------------------------------------------------*/

        protected override void Execute(IWebDriver webDriver)
        {
            var webElementA = _elementA?.AsWebElement() ?? webDriver.FindElementBySelector(_selectorA);
            var webElementB = _elementB?.AsWebElement() ?? webDriver.FindElementBySelector(_selectorB);

            var interaction = new Actions(webDriver);
            if (webElementA != null)
            {
                if (webElementB != null)
                {
                    interaction = interaction.DragAndDrop(webElementA, webElementB);
                }
                else
                {
                    interaction = interaction.DragAndDropToOffset(webElementA, _xOffsetToA.Value, _yOffsetToB.Value);
                }
            }
            else
            {
                var root = webDriver.FindElementBySelector("html");
                interaction = interaction
                    .MoveToElement(root, _xOffsetToA.Value, _yOffsetToA.Value)
                    .ClickAndHold();
                
                if (webElementB != null)
                {
                    interaction = interaction.MoveToElement(webElementB);
                }
                else
                {
                    interaction = interaction.MoveToElement(root, _xOffsetToB.Value, _yOffsetToB.Value);
                }

                interaction = interaction.Release();
            }

            interaction.Perform();
        }

        public override string ToString()
        {
            return "TODO: DragCommand.ToString()";
        }
    }
}
