using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PegasusTests.Locators;
using PegasusTests.PageHelper.Comm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PegasusTests.PageHelper
{
    public class AddDocumentAdminHelper : DriverHelper
    {
        public LocatorReader locatorReader;

        public AddDocumentAdminHelper(IWebDriver idriver)
            : base(idriver)
        {
            locatorReader = new LocatorReader("AddDocumentsAdmin.xml");
        }

        

// ###########################  XML  ##############


        //Type into given xml node
        public void TypeText(string Field, string text)
        {
            String locator = locatorReader.ReadLocator(Field);
            WaitForElementPresent(locator, 20);
            WaitForElementVisible(locator, 20);
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

        //Select by text
        public void SelectByText(string xmlNode, string text)
        {
            String locator = locatorReader.ReadLocator(xmlNode);
            SelectDropDownByText(locator, text);
        }


        //Click 

        public void ClickElement(string xmlNode)
        {
            String locator = locatorReader.ReadLocator(xmlNode);
            WaitForElementPresent(locator, 20);
            WaitForElementVisible(locator, 20);
            Click(locator);
        }


        //Redirect To URL
        public void RedirectToPage()
        {
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selenium_corp/selenium_office/groups");
        }

        //Redirect To Url
        public void RedirectToAdmin()
        {
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selenium_corp/selenium_office/admin");
        }



        public void Upload(string Field, string Filename)
    {
        String locator = locatorReader.ReadLocator(Field);
        GetWebDriver().FindElement(ByLocator(locator)).SendKeys(Filename);
        WaitForWorkAround(3000);
    
    }

        public void verifyUpdate(string text)
        {
            string table = "//table[@id='list1']/tbody/tr";
            WaitForElementVisible(table,30);
            var totalrow = XpathCount(table);
            string textcount = "//td[contains(text(),'" + text + "')]";
            var totaltext = XpathCount(textcount);
            Console.WriteLine("Updated = "+totalrow + "\t" + totaltext);
            Assert.IsTrue(totaltext == (totalrow - 1));
        }

        public void ClickOnProduct(string Proname)
        {
            string prolink = "//a[contains(text(),'" + Proname + "')]";
            WaitForElementPresent(prolink, 20);
            Click(prolink);
        }

        public void verifyCloned(string Proname)
        {
            string textcount = "//a[contains(text(),'" + Proname + "')]";
            WaitForElementVisible(textcount, 30);
            var totaltext = XpathCount(textcount);
            Assert.IsTrue(totaltext == 2);
        }

        public int GetProcessorCount(string xmlNode)
        {
            String locator = locatorReader.ReadLocator(xmlNode);
            string newlocator = locator + "[2]/td[@aria-describedby='list1_processor_name']"; ;
            WaitForElementVisible(newlocator, 30);
            return XpathCount(locator);

        }

        public string[] GetAllProcessor(string xmlNode)
        {
            String locator = locatorReader.ReadLocator(xmlNode);
            WaitForElementVisible(locator, 30);
            int count = XpathCount(locator);

            string[] AllProcess = new string[count];
            for (int i = 0; i < count - 1; i++)
            {
                int k = i + 2;
                var newlocator = locator + "[" + k+"]/td[@aria-describedby='list1_processor_name']";
                AllProcess[i] = GetText(newlocator);
            }
            return AllProcess;
        }

        public void VerifyProcessCount(string xmlNode, int processcount)
        {
            String locator = locatorReader.ReadLocator(xmlNode);
            WaitForElementVisible(locator, 30);
            string newlocator = locator+"/option";
            int count = XpathCount(newlocator);
            Assert.IsTrue((count - 1) == (processcount - 1));
        }

        public void VerifyAllProcessor(string xmlNode, string[] processor)
        {
            String locator = locatorReader.ReadLocator(xmlNode);
            WaitForElementVisible(locator, 30);
            string newlocator = locator + "/option";
            WaitForElementVisible(newlocator+"[2]", 30);
            int count = XpathCount(newlocator);
            Console.WriteLine("Total Count" + count);
            string[] Processdp = new string[count];
            for (int i = 0; i < count - 1; i++)
            {
                int k = i + 2;
                string newlocator1 = locator + "/option["+k+"]";
                Console.WriteLine(GetText(newlocator1) + "\t" + (processor[i]));
                Assert.IsTrue(GetText(newlocator1).Contains(processor[i]));
            }
        }

        public void ExportAs(string type)
        {
            GetWebDriver().Navigate().Refresh();
            String locator = "//div[@title='Export']/button";
            WaitForElementVisible(locator, 30);
            Click(locator);
            string newlocator="";
            if (type == "CSV")
            {
                newlocator = "//*[@id='export_csv']";
                WaitForElementVisible(newlocator, 30);
            }
            else
            {
                newlocator = "//*[@id='export_excel']"; 
                WaitForElementVisible(newlocator, 30);
            }
            Click(newlocator);
        }

        public void verifyDownloadedExtention(string exe, string filepath)
        {
            WaitForWorkAround(5000);
            Console.WriteLine(filepath.Substring(filepath.LastIndexOf('.') + 1)+"\t"+exe);
            var filexe = filepath.Substring(filepath.LastIndexOf('.') + 1);
            Assert.IsTrue(filexe == exe);
        }

        public bool VerifyPartnerAssociation(string xmlNode)
        {
            String locator = locatorReader.ReadLocator(xmlNode);
            WaitForWorkAround(3000);
            bool result = IsElementPresent(locator);
            if(result)
            {
                WaitForElementVisible(locator,30);
            }
            return result;
        }

        public void verifyColumnAdded(string xmlNode)
        {
            String locator = locatorReader.ReadLocator(xmlNode);
            WaitForWorkAround(2000);
            Assert.IsTrue(IsElementPresent(locator));
        }

        public void verifyExpanded(int divNumber)
        {
            String locator = "//*[@id='tab-2']/div["+divNumber+"]/div[2]";
            WaitForElementVisible(locator,20);
            Assert.IsTrue(IsElementPresent(locator));
        }

        public bool verifyAvatarAvailable(string text)
        {
            WaitForWorkAround(5000);
            bool result = GetWebDriver().PageSource.Contains(text);

            return result;

        }

        public void deleteProcessor(string ProcessName)
        {
            string locator = "//table[@id='list1']/tbody/tr";
            WaitForElementVisible("//table[@id='list1']/tbody/tr[2]", 50);
            TypeText("ProceNameFilter", ProcessName);
            WaitForWorkAround(5000);
            string newlocator = "//table[@id='list1']/tbody/tr/td/a[@title='Delete Processor']";
            Click(newlocator);
            AcceptAlert();
            WaitForText("The processor is successfully deleted!!",10);
        }
    }
}
