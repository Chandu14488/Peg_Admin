using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using PegasusTests.Locators;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.PageHelper
{
    public class UpdateContactHelper : DriverHelper
    {
        public LocatorReader locatorReader;

        public UpdateContactHelper(IWebDriver idriver)
            : base(idriver)
        {
            locatorReader = new LocatorReader("UpdateContact.xml");

        }

        // ###########################  XML  ##############


        //Type into given xml node
        public void TypeText(string Field, string text)
        {
            var locator = locatorReader.ReadLocator(Field);
            WaitForElementPresent(locator, 20);
            SendKeys(locator, text);
        }

        //Verify text of given xml node
        public void VerifyText(string XmlNode, string text)
        {
            var locator = locatorReader.ReadLocator(XmlNode);
            var value = GetText(locator);
            Assert.IsTrue(value.Contains(text));
        }

        //Select by value
        public void Select(string xmlNode, string value)
        {
            var locator = locatorReader.ReadLocator(xmlNode);
            SelectDropDown(locator, value);
        }

        //Click 

        public void ClickElement(string xmlNode)
        {
            var locator = locatorReader.ReadLocator(xmlNode);
            WaitForElementPresent(locator, 20);
            Click(locator);
            WaitForWorkAround(3000);
        }

        //Click On Save Or Dublicate
        public void ClickOnSaveOrDublicate()
        {
            var locator = "//*[@id='ContactCreateForm']/div[6]/div/a[1]/span[1]";
            var locator2 = "//*[@id='message']/div[4]/div/a[1]/span[1]";
            Click(locator);
            WaitForWorkAround(3000);

            if (IsElementPresent(locator2))
            {
                Click(locator2);
                WaitForWorkAround(3000);
            }

        }


    }
}