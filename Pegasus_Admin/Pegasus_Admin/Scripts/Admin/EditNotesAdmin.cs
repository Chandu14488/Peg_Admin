using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class EditNotesAdmin : DriverTestCase
    {
        [TestMethod]
        public void editNotesAdmin()
        {
            string[] username = null;
            string[] password = null;

            XMLParse oXMLData = new XMLParse();
            oXMLData.LoadXML("../../Config/ApplicationSettings.xml");

            username = oXMLData.getData("settings/Credentials", "username");
            password = oXMLData.getData("settings/Credentials", "password");

            //Initializing the objects
            LoginHelper loginHelper = new LoginHelper(GetWebDriver());
            ClientsHelper clientHelper = new ClientsHelper(GetWebDriver());
            EditAddNotesAdminHelper editAddNotesAdminHelper = new EditAddNotesAdminHelper(GetWebDriver());

            // Variable
            String name = "Testing Subject" + RandomNumber(1,99);
            String email = "Test" + RandomNumber(1,999)+ "@gmail.com.com";


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Click On  Admin
            editAddNotesAdminHelper.RedirectToAdmin();

//################################# Corprate TAB #############################################

            //Go to note page
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/notes");

            //Verify title
            VerifyTitle("Notes");

//################################# ADD NOTE #############################################

            // Click On Create
            editAddNotesAdminHelper.ClickElement("ClickOnAddNotes");

            //Verify title
            VerifyTitle("Create a New Note");

            //Enter Name
            editAddNotesAdminHelper.TypeText("EnterSubjuct", name);

            //Select Department
            //editAddNotesAdminHelper.TypeText("EnterDescription", "This is testing description notes");

            //cLICK on Save  
            editAddNotesAdminHelper.ClickElement("ClickOnSave");
            
            //Wait for text
            editAddNotesAdminHelper.WaitForText("Note saved successfully. ", 30);

//####################    EDIT 
            
            //Enter Subject in Search field
            editAddNotesAdminHelper.TypeText("EnterSubject", name);
            editAddNotesAdminHelper.WaitForWorkAround(5000);

            //Click on Edit
            editAddNotesAdminHelper.ClickElement("ClickOnEdit");

            VerifyTitle("Edit Note");

            //Edit Subject
            editAddNotesAdminHelper.TypeText("EnterSubjuct", "Test");

            //Click On Save Btn
            editAddNotesAdminHelper.ClickElement("ClickOnSave");

            //Wait for text
            editAddNotesAdminHelper.WaitForText("Note Updated Success.", 30);
        }
    }
}
