using OpenQA.Selenium;
using PegasusTests.Locators;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.PageHelper
{
    public class DeleteOpportunitiesHelper : DriverHelper
    {
        public LocatorReader locatorReader;

        public DeleteOpportunitiesHelper(IWebDriver idriver)
            : base(idriver)
        {
            locatorReader = new LocatorReader("DeleteOpportunities.xml");
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

        //Dublicate
        public void ClickOnDublicate()
        {
            var locator = "//*[@id='OpportunityCreateForm']/div[2]/div[3]/a[1]/span[1]";
            var DubLocator = "//*[@id='message']/div[4]/div/a[1]/span[1]";
            Click(locator);
            WaitForWorkAround(3000);

            if (IsElementPresent(DubLocator))
            {
                Click(DubLocator);
                WaitForWorkAround(3000);
            }
        } 
    }
}
