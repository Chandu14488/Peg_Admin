using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.Admin
{
    [TestClass]
    public class CreateUserAdmin : DriverTestCase
    {
        [TestMethod]
        public void createUserAdmin()
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
            var createOfficeUserAdminHelper = new CreateOfficeUserAdminHelper(GetWebDriver());

            // Variable
            var name = "TestTester" + RandomNumber(1, 99);
            var email = "Test" + RandomNumber(1, 999) + "@gmail.com";


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Click On  Admin
            createOfficeUserAdminHelper.RedirectToAdmin();

            //Redirect To URL
            createOfficeUserAdminHelper.RedirectToPage();

            //Verify title
            VerifyTitle("selOffice's Users");

//################################# Create Master Category #############################################

            // Click On Create
            createOfficeUserAdminHelper.ClickElement("ClickOnCreate");

            //Verify title
            VerifyTitle("Create User");

            //Select Type
            createOfficeUserAdminHelper.Selectbytext("UsreType", "Employee");

            //Click on Create New
            createOfficeUserAdminHelper.ClickElement("CreateNew");

            //Wait
            createOfficeUserAdminHelper.WaitForWorkAround(3000);

            //Enter USER NAME
            createOfficeUserAdminHelper.TypeText("UserName", name);


//#######################Employee detail
            //Select Salutation
            createOfficeUserAdminHelper.Select("Salutation", "Mr");

            //Enter FIRST NAME
            createOfficeUserAdminHelper.TypeText("FirstName", "Test");

            //Enter LastName
            createOfficeUserAdminHelper.TypeText("LastName", "  Tester");


            //Enter Primary Email
            createOfficeUserAdminHelper.TypeText("PrimaryEmail", email);

            //Click on Admin Avatar
            createOfficeUserAdminHelper.ClickElement("ClickOnAdminUser");

            //cLICK on Save  
            createOfficeUserAdminHelper.ClickElement("ClickOnSave");
            
            //Wait for text
            createOfficeUserAdminHelper.WaitForText("The user is successfully added", 30);
        }
    }
}