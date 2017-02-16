using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WbTstr.Commands.Interfaces;
using WbTstr.Proxies.Extensions;
using WbTstr.Proxies.Interfaces;
using WbTstr.WebDrivers.Extensions;

namespace WbTstr.Commands
{
    public class DragCommand : IActionCommand
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

            _selectorA = selectorA;
            _selectorB = selectorB;
        }

        public DragCommand(IElement elementA, IElement elementB)
        {
            if (elementA == null) throw new ArgumentNullException(nameof(elementA));
            if (elementB == null) throw new ArgumentNullException(nameof(elementB));

            _elementA = elementA;
            _elementB = elementB;
        }

        public DragCommand(string selectorA, int xOffsetToB, int yOffsetToB)
        {
            if (selectorA == null) throw new ArgumentNullException(nameof(selectorA));

            _selectorA = selectorA;
            _xOffsetToB = xOffsetToB;
            _yOffsetToB = yOffsetToB;
        }

        public DragCommand(IElement elementA, int xOffsetToB, int yOffsetToB)
        {
            if (elementA == null) throw new ArgumentNullException(nameof(elementA));

            _elementA = elementA;
            _xOffsetToB = xOffsetToB;
            _yOffsetToB = yOffsetToB;
        }

        public DragCommand(int xOffsetToA, int yOffsetToA, string selectorB)
        {
            if (selectorB == null) throw new ArgumentNullException(nameof(selectorB));

            _xOffsetToA = xOffsetToA;
            _yOffsetToA = yOffsetToA;
            _selectorB = selectorB;
        }

        public DragCommand(int xOffsetToA, int yOffsetToA, IElement elementB)
        {
            if (elementB == null) throw new ArgumentNullException(nameof(elementB));

            _xOffsetToA = xOffsetToA;
            _yOffsetToA = yOffsetToA;
            _elementB = elementB;
        }

        public DragCommand(int xOffsetToA, int yOffsetToA, int xOffsetToB, int yOffsetToB)
        {
            _xOffsetToA = xOffsetToA;
            _yOffsetToA = yOffsetToA;
            _xOffsetToB = xOffsetToB;
            _yOffsetToB = yOffsetToB;
        }

        /* Methods ----------------------------------------------------------*/

        public void Execute(object webDriverObj)
        {
            if (webDriverObj == null) throw new ArgumentNullException(nameof(webDriverObj));
            var webDriver = webDriverObj as IWebDriver;

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
            return base.ToString();
        }
    }
}
