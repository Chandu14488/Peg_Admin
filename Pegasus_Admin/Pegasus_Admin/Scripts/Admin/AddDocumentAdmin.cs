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
    public class AddDocumentAdmin : DriverTestCase
    {
        [TestMethod]
        public void addDocumentAdmin()
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
            AddDocumentAdminHelper addDocumentAdminHelper = new AddDocumentAdminHelper(GetWebDriver());

            // Variable
            var name = "Testing Subject" + RandomNumber(1, 99);
            var email = "Test" + RandomNumber(1, 999) + "@gmail.com.com";


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");



            //Click On  Admin
            addDocumentAdminHelper.RedirectToAdmin();

//################################# Corprate TAB #############################################

            //Click on Terminal And Equipment Tab
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/documents/create");
            
            //verify title
            VerifyTitle("Create a New Document");

//################################# ADD Document #############################################


            //Select displayed new window
            addDocumentAdminHelper.TypeText("Name", "TEST DOCUMENT");



            //Upload doc 
            String Filename = GetPathToFile() + "index.jpg";
            addDocumentAdminHelper.Upload("ClickToUpload", Filename);


            //Enter dESCRIPTION
           // addDocumentAdminHelper.TypeText("Description", "THIS IS DOCUMENT DESCRIPTION");


            //Click on Save button
            addDocumentAdminHelper.ClickElement("ClickOnSave");
            addDocumentAdminHelper.WaitForText("Document saved successfully.", 30);
        }
    }
}
