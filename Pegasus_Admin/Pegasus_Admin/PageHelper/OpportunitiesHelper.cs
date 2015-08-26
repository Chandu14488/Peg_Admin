using OpenQA.Selenium;
using PegasusTests.Locators;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.PageHelper
{
    public class OpportunitiesHelper : DriverHelper
    {
        public LocatorReader locatorReader;

        public OpportunitiesHelper(IWebDriver idriver)
            : base(idriver)
        {
            locatorReader = new LocatorReader("Opportunities.xml");
        }

        public void ClickOnButton(string Node)
        {
            var locator = locatorReader.ReadLocator(Node);
            Click(locator);
        }

        public void SendText(string node, string text)
        {
            var locator = locatorReader.ReadLocator(node);
            SendKeys(locator, text);
        }

        public void Select(string Node, string Value)
        {
            var locator = locatorReader.ReadLocator(Node);
            SelectDropDown(locator, Value);
        }



        //Click on Dublicate button
        public void ClickOnDublicate()
        {
            var locator = "//*[@id='OpportunityCreateForm']/div[2]/div[3]/a[1]/span[1]";
            var dublicate = "//*[@id='message']/div[4]/div/a[1]/span[1]";
            Click(locator);
            WaitForWorkAround(3000);

            if(IsElementPresent(dublicate))
            {

                Click(dublicate);
                WaitForWorkAround(3000);

            }
        
        
        }

        //Uplaod Note File
        public void uploadNoteFile(string field , string filepath)
        {
            var locator = locatorReader.ReadLocator(field);
            GetWebDriver().FindElement(ByLocator(locator)).SendKeys(filepath);
        
        }


    }
}



