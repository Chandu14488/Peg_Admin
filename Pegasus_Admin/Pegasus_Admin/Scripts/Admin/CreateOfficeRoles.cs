using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.Admin
{
    [TestClass]
    public class CreateOfficeRoles : DriverTestCase
    {
        [TestMethod]
        public void createOfficeRoles()
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
            var createOfficeRoleAdminHelper = new CreateOfficeRoleAdminHelper(GetWebDriver());

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
            createOfficeRoleAdminHelper.RedirectToAdmin();

//##################  Redirect To Url

            //Redirect To URL
            createOfficeRoleAdminHelper.RedirectToPage();
            
            //Verify title
            VerifyTitle("Roles");

//################################# Create Master Category #############################################

            // Click On Create
            createOfficeRoleAdminHelper.ClickElement("ClickOnCreate");

            //wait
            createOfficeRoleAdminHelper.WaitForWorkAround(3000);

            //Enter DepartmentName
            createOfficeRoleAdminHelper.TypeText("RoleName", name);

            //Enter Description
            createOfficeRoleAdminHelper.Selectbytext("SelectDepartment", "IT");

            //Click on checkbox Manager
            createOfficeRoleAdminHelper.ClickElement("Manager");


            //cLICK on Save  
            createOfficeRoleAdminHelper.ClickElement("ClickOnSave");
            
            //Wait for text
            createOfficeRoleAdminHelper.WaitForText("Role has been saved.", 30);
        }
    }
}