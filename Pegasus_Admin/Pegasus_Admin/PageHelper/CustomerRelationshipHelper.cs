using OpenQA.Selenium;
using PegasusTests.Locators;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.PageHelper
{
    public class CustomerRelationshipHelper : DriverHelper
    {
        public LocatorReader locatorReader;

        public CustomerRelationshipHelper(IWebDriver idriver)
            : base(idriver)
        {
            locatorReader = new LocatorReader("CustomerRelationship.xml");
        }

        public void ClickOnButton(string Node)
        {
            var locator = locatorReader.ReadLocator(Node);
            Click(locator);
        }

        public void SendText(string Node, string Text)
        {
            var locator = locatorReader.ReadLocator(Node);
            SendKeys(locator, Text);
        }

        public void Select(string Node, string Value)
        {
            var locator = locatorReader.ReadLocator(Node);
            SelectDropDown(locator, Value);
        }
    }
}