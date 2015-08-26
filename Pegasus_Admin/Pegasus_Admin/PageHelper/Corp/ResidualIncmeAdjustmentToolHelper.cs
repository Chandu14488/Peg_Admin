using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PegasusTests.Locators;
using PegasusTests.PageHelper.Comm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PegasusTests.PageHelper
{
    public class ResidualIncmeAdjustmentToolHelper : DriverHelper
    {
        public LocatorReader locatorReader;

        public ResidualIncmeAdjustmentToolHelper(IWebDriver idriver)
            : base(idriver)
        {
            locatorReader = new LocatorReader("ResidualIncomeAdjustmentToolCorp.xml");
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
            String locator = locatorReader.ReadLocator(xmlNode);
            WaitForElementPresent(locator, 20);
            Click(locator);
        }


        internal void MouseHover(string field)
        {
            String locator = locatorReader.ReadLocator(field);
            WaitForElementPresent(locator, 20);
            MouseOver(locator);
        }





        internal void redirectToPage()
        {
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selenium_corp/rir/masterrules");
        }

        //### Redirect to Paypout

        public void redirectToPayout()
        {
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selenium_corp/selenium_office/rir/payout_summary");
        }

        internal void Upload(string Field, string FileName)
        {
            String locator = locatorReader.ReadLocator(Field);
            WaitForElementVisible(locator, 20);
            GetWebDriver().FindElement(ByLocator(locator)).SendKeys(FileName);
        }

        public void elementpre()
        {
            String locator = "//*[@id='imgdiv']/div[2]/img";
            for (; ; )
            {
                if (!IsElementPresent(locator))
                {
                    break;
                }
                else
                {
                    Thread.Sleep(1000);
                }
            }
        }


    /*    public void calculateLod()
        {

            String locator = "//*[@id='imgdiv']/div[2]/img";
            for (; ; )
            {
                if (!IsElementPresent(locator))
                {
                    break;
                }
                else
                {
                    Thread.Sleep(1000);
                }
            }
        }
        */

        public void elementLod(String field)
        {
            String locator = locatorReader.ReadLocator(field);
            WaitForElementEnabled(locator,50);
        }
    
   
    }




            

}
