using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using PegasusTests.Locators;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.PageHelper
{
    public class AddContactHelper : DriverHelper
    {
        public LocatorReader locatorReader;

        public AddContactHelper(IWebDriver idriver)
            : base(idriver)
        {
            locatorReader = new LocatorReader("AddContact.xml");
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
            WaitForWorkAround(4000);
        }


        //Upload
        public void uplaod(string Field, string FileName)
        {
            var locator = locatorReader.ReadLocator(Field);
            GetWebDriver().FindElement(ByLocator(locator)).SendKeys(FileName);
        }



        //Click Either On Save or On Dublicate
        public void ClickOnSaveOrDublicate()
        {
            var locator = "//*[@id='ContactCreateForm']/div[6]/div/a[1]/span[1]";
            var locatorDub = "//*[@id='message']/div[4]/div/a[1]/span[1]";
            Click(locator);
            WaitForWorkAround(3000);

            if (IsElementPresent(locatorDub))
            {
                Click(locatorDub);
                WaitForWorkAround(3000);
            }



        }


    }
}
