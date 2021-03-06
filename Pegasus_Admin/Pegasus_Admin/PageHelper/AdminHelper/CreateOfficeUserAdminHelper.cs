﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using PegasusTests.Locators;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.PageHelper
{
    public class CreateOfficeUserAdminHelper : DriverHelper
    {
        public LocatorReader locatorReader;

        public CreateOfficeUserAdminHelper(IWebDriver idriver)
            : base(idriver)
        {
            locatorReader = new LocatorReader("CreateOfficeUserAdmin.xml");
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
            WaitForElementVisible(locator, 30);
            SelectDropDown(locator, value);
        }

        //Click 

        public void ClickElement(string xmlNode)
        {
            var locator = locatorReader.ReadLocator(xmlNode);
            WaitForElementPresent(locator, 20);
            Click(locator);
        }

        //Redirect To URL
        public void RedirectToPage()
        {
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selenium_corp/selenium_office/users");
        }

        //Redirect To Url
        public void RedirectToAdmin()
        {
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selenium_corp/selenium_office/admin");
        }

        public void Selectbytext(string xmlNode, string text)
        {
            var locator = locatorReader.ReadLocator(xmlNode);
            WaitForElementVisible(locator, 30);
            SelectDropDownByText(locator, text);
        }
    }
}