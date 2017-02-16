using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WbTstr.Commands.Interfaces;

namespace WbTstr.Commands
{
    public class HoverActionCommand : IActionCommand
    {
        private readonly string _selector;

        public HoverActionCommand(string selector)
        {
            _selector = selector;
        }

        /* Methods ----------------------------------------------------------*/

        public void Execute(object webDriverObj)
        {
            var webDriver = webDriverObj as IWebDriver;

            var element = webDriver.FindElement(By.CssSelector(_selector));
            if (element != null)
            {
                var interaction = new Actions(webDriver);
                interaction.MoveToElement(element).Perform();
            }
        }
    }
}
