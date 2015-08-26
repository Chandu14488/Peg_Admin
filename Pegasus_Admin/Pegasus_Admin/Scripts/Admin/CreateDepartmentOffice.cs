using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.Admin
{
    [TestClass]
    public class CreateDepartmentOffice : DriverTestCase
    {
        [TestMethod]
        public void createDepartmentOffice()
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
            var createDepartmentHelper = new CreateDepartmentHelper(GetWebDriver());

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
            createDepartmentHelper.RedirectToAdmin();

//##################  Redirect To Url

            //Redirect To URL
            createDepartmentHelper.RedirectToPage();

            //Verify title
            VerifyTitle("Departments");

//################################# Create Master Category #############################################

            // Click On Create
            createDepartmentHelper.ClickElement("ClickOnCreate");

            //Verify title
            VerifyTitle("Create a Department");

            //Enter DepartmentName
            createDepartmentHelper.TypeText("DepartmentName", name);

            //Enter Description
            createDepartmentHelper.TypeText("Descripton", "THIS IS TESTING DESCRIPTION");

            //cLICK on Save  
            createDepartmentHelper.ClickElement("ClickOnSave");

            //Wait for text
            createDepartmentHelper.WaitForText("Department has been saved.", 30);
        }
    }
}