using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using PegasusTests.PageHelper.Comm;
using OpenQA.Selenium.Support.UI;
using PegasusTests.Locators;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace PegasusTests.PageHelper
{
    public class ContactUsHelper : DriverHelper
    {
        public LocatorReader locatorReader;

        public ContactUsHelper(IWebDriver idriver)
            : base(idriver)
        {
            locatorReader = new LocatorReader("ContactUs.xml");
        }

        //Click to given xml node
        public void ClickElement(string XmlNode)
        {
            String locator = locatorReader.ReadLocator(XmlNode);
            Click(locator);
        }

        //Type into given xml node
        public void TypeText(string XmlNode, string text)
        {
            String locator = locatorReader.ReadLocator(XmlNode);
            SendKeys(locator, text);
        }

        //Verify text of given xml node
        public void VerifyText(string XmlNode, string text)
        {
            String locator = locatorReader.ReadLocator(XmlNode);
            String value = GetText(locator);
            Assert.IsTrue(value.Contains(text));
        }

    }
}