using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.Admin
{
    [TestClass]
    public class CreateGroups : DriverTestCase
    {
        [TestMethod]
        public void createGroups()
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
            var createOfficeGrpAdminHelper = new CreateOfficeGrpAdminHelper(GetWebDriver());

            // Variable
            var name = "Test" + RandomNumber(1, 99);
            var email = "Test" + RandomNumber(1, 999) + "@gmail.com.com";


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Click On  Admin
            createOfficeGrpAdminHelper.RedirectToAdmin();

//##################  Redirect To Url

            //Redirect To URL
            createOfficeGrpAdminHelper.RedirectToPage();

            //Verify title
            VerifyTitle("Groups");

//################################# Create Master Category #############################################

            // Click On Create
            createOfficeGrpAdminHelper.ClickElement("ClickOnCreate");

            //Verify title
            VerifyTitle("Create a Group");

            //Enter Group Name
            createOfficeGrpAdminHelper.TypeText("GrpName", name);

            //Enter Description
            createOfficeGrpAdminHelper.TypeText("Description", "THIS IS TEST DESCRIPTION");

            //cLICK on Save  
            createOfficeGrpAdminHelper.ClickElement("ClickOnSave");
            
            //Wait for text
            createOfficeGrpAdminHelper.WaitForText("Group has been saved.", 30);
        }
    }
}