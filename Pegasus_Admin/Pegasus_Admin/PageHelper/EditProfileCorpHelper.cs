using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using PegasusTests.Locators;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.PageHelper
{
    public class EditProfileCorpHelper : DriverHelper
    {
        public LocatorReader locatorReader;

        public EditProfileCorpHelper(IWebDriver idriver)
            : base(idriver)
        {
            locatorReader = new LocatorReader("EditProfileCorp.xml");
        }

//###############  XML  ##############


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
        }

        internal void MouseHover(string field)
        {
            var locator = locatorReader.ReadLocator(field);
            WaitForElementPresent(locator, 20);
            MouseOver(locator);
        }

        internal void redirectToPage()
        {
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selenium_corp/avatars");
        }

        //### Redirect to Paypout

        public void redirectToAdminAmex()
        {
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selenium_corp/selenium_office/amex_rates");
        }

        internal void Upload(string Field, string FileName)
        {
            var locator = locatorReader.ReadLocator(Field);
            WaitForElementVisible(locator, 20);
            GetWebDriver().FindElement(ByLocator(locator)).SendKeys(FileName);
        }

        public void elementpre()
        {
            var locator = "//*[@id='imgdiv']/div[2]/img";
            for (;;)
            {
                if (!IsElementPresent(locator))
                {
                    break;
                }
                Thread.Sleep(1000);
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

        public void elementLod(string field)
        {
            var locator = locatorReader.ReadLocator(field);
            WaitForElementEnabled(locator, 50);
        }
    }
}