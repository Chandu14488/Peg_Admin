using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.Admin
{
    [TestClass]
    public class CreateResolutionTicket : DriverTestCase
    {
        [TestMethod]
        public void createResolutionTicket()
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
            var createResolutionTicketHelper = new CreateResolutionTicketHelper(GetWebDriver());

            // Variable
            var name = "Test" + RandomNumber(1, 99);


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Click On  Admin
            createResolutionTicketHelper.RedirectToAdmin();

            //Redirect To URL
            createResolutionTicketHelper.RedirectToPage();

            //Verfiy title
            VerifyTitle("Master Data");

//################################# Create Master Category #############################################

            // Click On Create
            createResolutionTicketHelper.ClickElement("ClickOnCreate");

            //Verify title
            VerifyTitle("Create");

            //Enter Name
            createResolutionTicketHelper.TypeText("Name", name);


            //cLICK on Save  
            createResolutionTicketHelper.ClickElement("SaveBtn");
            
            //Wait for text
            createResolutionTicketHelper.WaitForText("Masterdata created successfully", 30);
        }
    }
}