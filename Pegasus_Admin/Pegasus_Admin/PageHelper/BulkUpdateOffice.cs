using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using PegasusTests.Locators;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.PageHelper
{
    public class BulkUpdateOffice : DriverHelper
    {
        public LocatorReader locatorReader;

        public BulkUpdateOffice(IWebDriver idriver)
            : base(idriver)
        {
            locatorReader = new LocatorReader("BulkIUpdateOffice.xml");
        }

        //Click to given xml node
        public void ClickElement(string XmlNode)
        {
            var locator = locatorReader.ReadLocator(XmlNode);
            Click(locator);
        }

        //Type into given xml node
        public void TypeText(string XmlNode, string text)
        {
            var locator = locatorReader.ReadLocator(XmlNode);
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

        internal void Upload(string Field, string FileName)
        {
            var locator = locatorReader.ReadLocator(Field);
            Console.WriteLine(FileName);
            GetWebDriver().FindElement(ByLocator(locator)).SendKeys(FileName);
            WaitForWorkAround(3000);
        }


        public void drawSign()
        {
            GetWebDriver().FindElement(By.XPath("//*[@id='signatureDiv']/div[1]/div[4]/canvas")).Click();
            //  GetWebDriver().FindElement(ByLocator("//*[@id='signatureDiv']/div[1]/div[4]/canvas")).Click();
        }

        //Click Dublicate
        public void ClickOnDublicate()
        {
            var locator = "//*[@id='LeadCreateForm']/div[2]/div[3]/a[1]/span[1]";
            var dublicate = "//*[@id='message']/div[4]/div/a[1]/span[1]";
            Click(locator);
            WaitForWorkAround(3000);

            if (IsElementPresent(dublicate))
            {

                Click(dublicate);
                WaitForWorkAround(3000);

            }
        }

       //Click on Pagination

        public void ClickOnPag()
        {
            var Loc1= "//a[@id='assignParent']";
            var Loc2 = "//div[@id='clientpaginationdiv']/span[2]/a";
            var Loc3 = "//div[@id='clientpaginationdiv']/span[3]/a";
            Click(Loc1);
            WaitForWorkAround(2000);
            if (IsElementPresent(Loc2))
            {
                Click(Loc2);
                WaitForWorkAround(4000);
            }

            if (IsElementPresent(Loc3)) 
            {
            Click(Loc3);
            WaitForWorkAround(4000);
            }
        }

        //Click on pagination //div[@id='clientpaginationdiv']/span[2]/a

        public void Pagination()
        {
            int x = XpathCount("//*[@id='clientpaginationdiv']/span");
            Console.WriteLine("count printed " + x);
            for (int i = 1; i <= x; i++)
            {
                Console.WriteLine("entered in loop");
                var newLoc = "//div[@id='clientpaginationdiv']/span[" + i + "]/a";
             //   if (IsElementPresent(newLoc))
                    Click(newLoc);
                //{
                  //  Click(newLoc);
                   // Console.WriteLine("entered in loop and clciked on icon");
                   // break;
               // }
            }
        
        }

        //Upload File Client
        public void uploadCSVClient(string Field , string filename)
        {
            string loc = locatorReader.ReadLocator(Field);
            WaitForWorkAround(3000);
            GetWebDriver().FindElement(ByLocator(loc)).SendKeys(filename);
        
        }




        //Switch frame 
        public void frame(string text)
        {
          //  var  locator = "";
            GetWebDriver().SwitchTo().Frame(0);
            GetWebDriver().FindElement(ByLocator("//body")).SendKeys(text);
        
        }



        }
    }
