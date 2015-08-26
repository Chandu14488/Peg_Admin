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
    public class CreatePDFCategoriesHelper : DriverHelper
    {
        public LocatorReader locatorReader;

        public CreatePDFCategoriesHelper(IWebDriver idriver)
            : base(idriver)
        {
            locatorReader = new LocatorReader("CreatePDFCategoriesCorp.xml");
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
            SelectDropDown(locator, value);
        }

        //Click 

        public void ClickElement(string xmlNode)
        {
            WaitForWorkAround(3000);
            String locator = locatorReader.ReadLocator(xmlNode);
            WaitForElementPresent(locator, 50);
            Click(locator);
            WaitForWorkAround(3000);
        }
        internal void MouseHover(string field)
        {
            String locator = locatorReader.ReadLocator(field);
            WaitForElementPresent(locator, 20);
            MouseOver(locator);
        }

        internal void redirectToPage()
        {
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selenium_corp/pdf_templates/categories");
        }



        //   Find And Click on Delete button     
        public void SearchAndClick(String name)
    {
        int x = XpathCount("//div[@id='list']/div/div/ul/li");
        for (int i = 1; i <= x; i++)
        {
            var TextLoc = "//div[@id='list']/div/div/ul/li[" + i + "]/span[1]";
            var LocToClick = "//div[@id='list']/div/div/ul/li[" + i + "]/spana/a[2]";
            if (GetText(TextLoc).Contains(name))
                Click(LocToClick);
            WaitForWorkAround(3000);
            
        
        }
    
    }


    }



}



