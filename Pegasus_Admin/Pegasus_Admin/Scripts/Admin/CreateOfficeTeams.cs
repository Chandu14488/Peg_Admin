using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.Admin
{
    [TestClass]
    public class CreateOfficeTeams : DriverTestCase
    {
        [TestMethod]
        public void createOfficeTeams()
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
            var createOfficeTeamAdmin = new CreateOfficeTeamAdmin(GetWebDriver());

            // Variable
            var name = "Testing" + RandomNumber(1, 99);
            var email = "Test" + RandomNumber(1, 999) + "@gmail.com.com";


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Click On  Admin
            createOfficeTeamAdmin.RedirectToAdmin();

            //Redirect To URL
            createOfficeTeamAdmin.RedirectToPage();

            //Verify Title 
            VerifyTitle("Teams");

//################################# Create Master Category #############################################

            // Click On Create
            createOfficeTeamAdmin.ClickElement("ClickOnCreate");

            //Wait
            createOfficeTeamAdmin.WaitForWorkAround(3000);

            //Enter Name
            createOfficeTeamAdmin.TypeText("TeamName", name);

            //Select Department
            createOfficeTeamAdmin.Selectbytext("SelectDepartment", "IT");

            //cLICK on Save  
            createOfficeTeamAdmin.ClickElement("ClickOnSave");
            
            //Wait for text
            createOfficeTeamAdmin.WaitForText("Team has been saved.", 30);
        }
    }
}