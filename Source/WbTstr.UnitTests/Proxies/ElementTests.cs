using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework.Internal;
using NUnit.Framework;
using OpenQA.Selenium;
using WbTstr.Proxies;
using WbTstr.Proxies.Interfaces;

namespace WbTstr.UnitTests.Proxies
{
    [TestFixture]
    public class ElementTests
    {
        [TestCase]
        public void Constructor_NullWebElement_ThrowsArgumentNullException()
        {
            // Arrange
            IWebElement webElement = null;

            // Act
            TestDelegate action = () => new ElementProxy(webElement);

            // Assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [TestCase]
        public void Constructor_NullSelector_ThrowsArgumentNullException()
        {
            // Arrange
            IWebElement webElement = Substitute.For<IWebElement>();
            string selector = null;

            // Act
            TestDelegate action = () => new ElementProxy(webElement, selector);

            // Assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [TestCase]
        public void Properties_AccessedOnElement_RetreivedFromWebElement()
        {
            // Arrange
            IWebElement webElement = Substitute.For<IWebElement>();
            IElement element = new ElementProxy(webElement);

            // Act
            bool displayed = element.Displayed;
            bool enabled = element.Enabled;
            bool selected = element.Selected;
            string tagName = element.TagName;
            string text = element.Text;

            // Assert
            displayed = webElement.Received().Displayed;
            enabled = webElement.Received().Enabled;
            selected = webElement.Received().Selected;
            tagName = webElement.Received().TagName;
            text = webElement.Received().Text;
        }
    }
}
