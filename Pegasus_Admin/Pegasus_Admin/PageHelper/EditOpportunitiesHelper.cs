﻿using OpenQA.Selenium;
using PegasusTests.Locators;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.PageHelper
{
    public class EditOpportunitiesHelper : DriverHelper
    {
        public LocatorReader locatorReader;

        public EditOpportunitiesHelper(IWebDriver idriver)
            : base(idriver)
        {
            locatorReader = new LocatorReader("EditOpportunities.xml");
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

        //Dublicate Save
        public void ClickOnDublicate()
        {
            var locator = "//*[@id='OpportunityCreateForm']/div[2]/div[3]/a[1]/span[1]";
            var dublicate = "//*[@id='message']/div[4]/div/a[1]/span[1]";
            Click(locator);
            WaitForWorkAround(3000);

            if (IsElementPresent(dublicate))
            {

                Click(dublicate);
                WaitForWorkAround(3000);

            }


        }


    }
}
