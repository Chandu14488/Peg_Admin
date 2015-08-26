using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.Admin
{
    [TestClass]
    public class CreateCategoryTickets : DriverTestCase
    {
        [TestMethod]
        public void createCategoryTickets()
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
            var createCategoryTicketsHelper = new CreateCategoryTicketsHelper(GetWebDriver());

            // Variable
            var name = "Test" + RandomNumber(1, 99);


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Click On  Admin
            createCategoryTicketsHelper.RedirectToAdmin();

//##################  Redirect To Url

            //Redirect To URL
            createCategoryTicketsHelper.RedirectToPage();

            //Verify title
            VerifyTitle("Master Data");
//################################# Create Master Category #############################################

            // Click On Create
            createCategoryTicketsHelper.ClickElement("ClickOnCreate");

            //Verify title
            VerifyTitle("Create");

            //Enter Name
            createCategoryTicketsHelper.TypeText("Name", name);


            //cLICK on Save  
            createCategoryTicketsHelper.ClickElement("SaveBtn");
            
            //Wait for text
            createCategoryTicketsHelper.WaitForText("Masterdata created successfully", 30);
        }
    }
}