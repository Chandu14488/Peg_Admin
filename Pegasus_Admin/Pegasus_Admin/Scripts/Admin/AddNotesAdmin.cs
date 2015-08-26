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
    public class AddNotesAdmin : DriverTestCase
    {
        [TestMethod]
        public void addNotesAdmin()
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
            AddNotesAdminHelper addNotesAdminHelper = new AddNotesAdminHelper(GetWebDriver());

            // Variable
            String name = "Testing Subject" + RandomNumber(1, 99);
            String email = "Test" + RandomNumber(1,999)+ "@gmail.com";


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Click on Clients in Topmenu
//            clientHelper.clickClients();

            //Click to open client info
   //         clientHelper.OpenClient();


            //Click On  Admin
            addNotesAdminHelper.RedirectToAdmin();

//################################# Corprate TAB #############################################

            //Click on Terminal And Equipment Tab
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/notes/create");

            //verify title
            VerifyTitle("Create a New Note");


//################################# ADD NOTE #############################################

            
            //Enter Name
            addNotesAdminHelper.TypeText("EnterSubjuct", name);

            //Select Department
            //addNotesAdminHelper.TypeText("EnterDescription", "This is testing description notes");

            //cLICK on Save  
            addNotesAdminHelper.ClickElement("ClickOnSave");
            addNotesAdminHelper.WaitForText("Note saved successfully.",30);

        }
    }
}
