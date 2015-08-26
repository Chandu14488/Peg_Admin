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
    public class TicketHelper:DriverHelper
    {
        public LocatorReader locatorReader;

        public TicketHelper(IWebDriver idriver)
            : base(idriver)
        {
            locatorReader = new LocatorReader("CreateOfficeTicket.xml");
        }

        //Click on Clients in Top Menu
        public void clickClients()
        {
            string locator = locatorReader.ReadLocator("CreatePDFs");
            Click(locator);
        }

        //Click on Name link
        public void OpenClient()
        {
            string locator = locatorReader.ReadLocator("FirstClientNameLink");
            Click(locator);
        }

        //Click on Add Note button
        public void ClickAddNote()
        {
            string locator = locatorReader.ReadLocator("Info/AddNote");
            Click(locator);
        }

        //Enter Note Subject
        public void EnterNoteSubject(String NoteSubject)
        {
            string locator = locatorReader.ReadLocator("Info/NoteWindow/NoteName");
            SendKeys(locator, NoteSubject);
        }

        //Enter Note description
        public void EnterNoteDesc(String NoteDesc)
        {
            string locator = locatorReader.ReadLocator("Info/NoteWindow/NoteDesc");
            SendKeys(locator, NoteDesc);
        }

        //Enter Email to address
        public void EnterEmailToAddress(String emailToAdd)
        {
            string locator = locatorReader.ReadLocator("Info/ComposeEmail/ToField");
            SendKeys(locator, emailToAdd);
        }

        //Enter Email subject line
        public void EnterEmailSubject(String emailSubj)
        {
            string locator = locatorReader.ReadLocator("Info/ComposeEmail/EmailSubject");
            SendKeys(locator, emailSubj);
        }

        //Select email importance 
        public void SelectImportance(string imp)
        {
            string locator = locatorReader.ReadLocator("Info/ComposeEmail/" + imp);
            Click(locator);
        }

        //Click on Source Icon
        public void ClickSourceIcon()
        {
            string locator = locatorReader.ReadLocator("Info/ComposeEmail/SourceIcon");
            Click(locator);
        }

        //Enter email body text
        public void EnterBodyText(string text)
        {
            string locator = locatorReader.ReadLocator("Info/ComposeEmail/EmailBody");
            SendKeys(locator, text);
        }

        //Send email 
        public void ClickSend()
        {
            string locator = locatorReader.ReadLocator("Info/ComposeEmail/Send");
            Click(locator);
        }

        //Enter subject for new task
        public void EnterTaskSubject(string text)
        {
            string locator = locatorReader.ReadLocator("Info/CreateTask/Subject");
            SendKeys(locator, text);
        }

        //Open start date cal
        public void OpenStartDatePicker()
        {
            string locator = locatorReader.ReadLocator("Info/CreateTask/StartDate");
            Click(locator);
        }

        //Click on Next icon
        public void ClickDatePickerNext()
        {
            string locator = locatorReader.ReadLocator("Info/CreateTask/DatePickerNext");
            Click(locator);
        }

        //Select date
        public void SelectDate(String date)
        {
            string locator = "link=" + date;
            Click(locator);
        }

        //Open Due Date cal
        public void OpenDueDatePicker()
        {
            string locator = locatorReader.ReadLocator("Info/CreateTask/DueDate");
            Click(locator);
        }

        //Click on Save task button
        public void ClickSaveTask()
        {
            string locator = locatorReader.ReadLocator("Info/CreateTask/Save");
            Click(locator);
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


        internal void Upload(string Field, string FileName)
        {
            String locator = locatorReader.ReadLocator(Field);
            Console.WriteLine(FileName);
            GetWebDriver().FindElement(ByLocator(locator)).SendKeys(FileName);
            WaitForWorkAround(3000);
        }
    }
}
