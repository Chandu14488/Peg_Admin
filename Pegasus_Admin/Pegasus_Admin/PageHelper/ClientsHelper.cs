using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using PegasusTests.Locators;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.PageHelper
{
    public class ClientsHelper : DriverHelper
    {
        public LocatorReader locatorReader;

        public ClientsHelper(IWebDriver idriver)
            : base(idriver)
        {
            locatorReader = new LocatorReader("Clients.xml");
        }

        //Click on Clients in Top Menu
        public void clickClients()
        {
            var locator = locatorReader.ReadLocator("CreatePDFs");
            Click(locator);
        }

        //Click on Name link
        public void OpenClient()
        {
            var locator = locatorReader.ReadLocator("FirstClientNameLink");
            Click(locator);
        }

        //Click on Add Note button
        public void ClickAddNote()
        {
            var locator = locatorReader.ReadLocator("Info/AddNote");
            Click(locator);
        }

        //Enter Note Subject
        public void EnterNoteSubject(string NoteSubject)
        {
            var locator = locatorReader.ReadLocator("Info/NoteWindow/NoteName");
            SendKeys(locator, NoteSubject);
        }

        //Enter Note description
        public void EnterNoteDesc(string NoteDesc)
        {
            
            var locator = locatorReader.ReadLocator("Info/NoteWindow/NoteDesc");
            SendKeys(locator, NoteDesc);
            
        }


        //1099 sale agent desc
        //Enter Note description
        public void Enter1099SANoteDesc(string NoteDesc)
        {
            GetWebDriver().SwitchTo().Frame(0);
            var locator = locatorReader.ReadLocator("Info/NoteWindow/A1099SaleDesc");
            SendKeys(locator, NoteDesc);
            GetWebDriver().SwitchTo().DefaultContent();
        }


        //Enter Email to address
        public void EnterEmailToAddress(string emailToAdd)
        {
            var locator = locatorReader.ReadLocator("Info/ComposeEmail/ToField");
            SendKeys(locator, emailToAdd);
        }

        //Enter Email subject line
        public void EnterEmailSubject(string emailSubj)
        {
            var locator = locatorReader.ReadLocator("Info/ComposeEmail/EmailSubject");
            SendKeys(locator, emailSubj);
        }

        //Select email importance 
        public void SelectImportance(string imp)
        {
            var locator = locatorReader.ReadLocator("Info/ComposeEmail/" + imp);
            Click(locator);
        }

        //Click on Source Icon
        public void ClickSourceIcon()
        {
            var locator = locatorReader.ReadLocator("Info/ComposeEmail/SourceIcon");
            Click(locator);
        }

        //Enter email body text
        public void EnterBodyText(string text)
        {
            var locator = locatorReader.ReadLocator("Info/ComposeEmail/EmailBody");
            SendKeys(locator, text);
        }

        //Send email 
        public void ClickSend()
        {
            var locator = locatorReader.ReadLocator("Info/ComposeEmail/Send");
            Click(locator);
        }

        //Enter subject for new task
        public void EnterTaskSubject(string text)
        {
            var locator = locatorReader.ReadLocator("Info/CreateTask/Subject");
            SendKeys(locator, text);
        }

        //Open start date cal
        public void OpenStartDatePicker()
        {
            var locator = locatorReader.ReadLocator("Info/CreateTask/StartDate");
            Click(locator);
        }

        //Click on Next icon
        public void ClickDatePickerNext()
        {
            var locator = locatorReader.ReadLocator("Info/CreateTask/DatePickerNext");
            Click(locator);
        }

        //Select date
        public void SelectDate(string date)
        {
            var locator = "link=" + date;
            Click(locator);
        }

        //Open Due Date cal
        public void OpenDueDatePicker()
        {
            var locator = locatorReader.ReadLocator("Info/CreateTask/DueDate");
            Click(locator);
        }

        //Click on Save task button
        public void ClickSaveTask()
        {
            var locator = locatorReader.ReadLocator("Info/CreateTask/Save");
            Click(locator);
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
    }

}
