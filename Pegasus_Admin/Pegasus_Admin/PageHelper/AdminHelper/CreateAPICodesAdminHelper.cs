using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PegasusTests.Locators;
using PegasusTests.PageHelper.Comm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PegasusTests.PageHelper
{
    public class CreateAPICodesAdminHelper : DriverHelper
    {
        public LocatorReader locatorReader;

        public CreateAPICodesAdminHelper(IWebDriver idriver)
            : base(idriver)
        {
            locatorReader = new LocatorReader("CreateAPICodesAdmin.xml");
        }

        

// ###########################  XML  ##############


        //Type into given xml node
        public void TypeText(string Field, string text)
        {
            String locator = locatorReader.ReadLocator(Field);
            WaitForElementPresent(locator, 20);
            SendKeys(locator, text);
        }

        //Verify text of given xml node
        public void VerifyText(string XmlNode, string text)
        {
            String locator = locatorReader.ReadLocator(XmlNode);
            String value = GetText(locator);
            Assert.IsTrue(value.Contains(text));
        }

        //Select by value
        public void Select(string xmlNode, string value)
        {
            String locator = locatorReader.ReadLocator(xmlNode);
            WaitForElementVisible(locator, 30);
            SelectDropDown(locator, value);
        }

        //Click 

        public void ClickElement(string xmlNode)
        {
            String locator = locatorReader.ReadLocator(xmlNode);
            WaitForElementPresent(locator, 20);
            Click(locator);
        }


        //Redirect To URL
        public void RedirectToPage()
        {
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selenium_corp/selenium_office/api_codes");
        }

        //Redirect To Url
        public void RedirectToAdmin()
        {
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selenium_corp/selenium_office/admin");
        }


        public void SelectByText(string xmlNode, string text)
        {
            String locator = locatorReader.ReadLocator(xmlNode);
            WaitForElementVisible(locator, 30);
            SelectDropDownByText(locator, text);
        }
    }
}
