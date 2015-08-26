using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.Admin
{
    [TestClass]
    public class CreateTopicTickets : DriverTestCase
    {
        [TestMethod]
        public void createTopicTickets()
        {
            string[] username = null;
            string[] password = null;

            var oXMLData = new XMLParse();
            oXMLData.LoadXML("../../Config/ApplicationSettings.xml");

            username = oXMLData.getData("settings/Credentials", "username");
            password = oXMLData.getData("settings/Credentials", "password");

            //Initializing the objects
            var loginHelper = new LoginHelper(GetWebDriver());
            var clientHelper = new ClientsHelper(GetWebDriver());
            var createTopicTicketsHelper = new CreateTopicTicketsHelper(GetWebDriver());

            // Variable
            var name = "Test" + RandomNumber(1, 99);


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            
            //Click On  Admin
            createTopicTicketsHelper.RedirectToAdmin();

//##################  Redirect To Url

            //Redirect To URL
            createTopicTicketsHelper.RedirectToPage();

            //Verify title
            VerifyTitle("Master Data");

//################################# Create Master Category #############################################

            // Click On Create
            createTopicTicketsHelper.ClickElement("ClickOnCreate");

            //Verify title
            VerifyTitle("Create");

            //Enter Name
            createTopicTicketsHelper.TypeText("Name", name);


            //cLICK on Save  
            createTopicTicketsHelper.ClickElement("SaveBtn");
            
            //waitfor text
            createTopicTicketsHelper.WaitForText("Masterdata created successfully", 30);
        }
    }
}