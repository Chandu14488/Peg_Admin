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
    public class ResetPasswordOfficeUser : DriverTestCase
    {
        [TestMethod]
        public void resetPasswordOfficeUser()
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
            ResetPasswordOfficeUserAdminHelper resetPasswordOfficeUserAdminHelper = new ResetPasswordOfficeUserAdminHelper(GetWebDriver());

            // Variable
            String name = "TestTester" + RandomNumber(1,99);
            String email = "Test" + RandomNumber(1,999)+ "@yopmail.com";


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

 
            //Redirect To URL
            resetPasswordOfficeUserAdminHelper.RedirectToPage();

            //Verify title
            VerifyTitle("selOffice's Users");

//################################# Create Master Category #############################################

            // Click On Create
            resetPasswordOfficeUserAdminHelper.ClickElement("ClickOnCreate");

            //Verify title
            VerifyTitle("Create User");

            //Select Type
            resetPasswordOfficeUserAdminHelper.Select("UsreType", "Employee");

            //Click on Create New
            resetPasswordOfficeUserAdminHelper.ClickElement("CreateNew");

            //Enter USER NAME
            resetPasswordOfficeUserAdminHelper.TypeText("UserName", name);


//#######################Employee detail
            //Select Salutation
            resetPasswordOfficeUserAdminHelper.Select("Salutation", "Mr");

            //Enter FIRST NAME
            resetPasswordOfficeUserAdminHelper.TypeText("FirstName", "Test");

            //Enter LastName
            resetPasswordOfficeUserAdminHelper.TypeText("LastName", "  Tester");

            //Enter Primary Email
            resetPasswordOfficeUserAdminHelper.TypeText("PrimaryEmail", email);

            //CLick on Admin
            resetPasswordOfficeUserAdminHelper.ClickElement("ClickOnAdminUser");
            //cLICK on Save  
            resetPasswordOfficeUserAdminHelper.ClickElement("ClickOnSave");
            
            //Wait for text
            resetPasswordOfficeUserAdminHelper.WaitForText("The user is successfully added",30);




//###########################Reset Password

            //Select Status
            resetPasswordOfficeUserAdminHelper.Select("SelectStatus","");


            //Enter Email Search 
            resetPasswordOfficeUserAdminHelper.TypeText("EmailResetFiled", email);
            resetPasswordOfficeUserAdminHelper.WaitForWorkAround(9000);

            //Verify text present
            resetPasswordOfficeUserAdminHelper.WaitForText(email,20);

            //Click on User
            resetPasswordOfficeUserAdminHelper.ClickElement("ClickOnUser");
            
            //Verify title
            VerifyTitle("Employee Detalis");

            // Click on Reset Password
            resetPasswordOfficeUserAdminHelper.ClickElement("ClickonResetPassword");

            //Accept Alert
            resetPasswordOfficeUserAdminHelper.AcceptAlert();

            //No link in the email is present to reset password
            resetPasswordOfficeUserAdminHelper.WaitForText("Reset password link sent to ", 20);

        }
    }
}
