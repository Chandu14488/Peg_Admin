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
    public class CreateIframeIntegration : DriverTestCase
    {
        [TestMethod]
        public void createIframeIntegration()
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
            CreateIframeAdminHelper createIframeAdminHelper = new CreateIframeAdminHelper(GetWebDriver());

            // Variable
            String name = "Test" + RandomNumber(1,99);
            String usrname = "Test.Tester" + RandomNumber(1, 99);

            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Click On  Admin
            createIframeAdminHelper.RedirectToAdmin();

            //Redirect To URL
            createIframeAdminHelper.RedirectToPage();

            //Verify title
            VerifyTitle("Iframe Apps");

//################################# iframe tab setting #############################################

            // Click On Create
            createIframeAdminHelper.ClickElement("ClickOnCreate");
            
            //Verify title
            VerifyTitle("Create Iframe");

            //Enter Tab Name
            createIframeAdminHelper.TypeText("TabName", name);

//#################################   APP SETTING   ######################3


            //Click on Generate API Code
            createIframeAdminHelper.TypeText("UserNameInputFieldName", usrname);
            createIframeAdminHelper.WaitForWorkAround(4000);

            //Select  Status
            createIframeAdminHelper.TypeText("PasswordInputFieldNmae", "1qaz!QAZ");


            //Select responsibilities
            createIframeAdminHelper.TypeText("LoginURL", "https://www.pegasus-test.com/selenium_corp/selenium_office/login");

            //Click on mainportal
            createIframeAdminHelper.ClickElement("mainportal");



            //cLICK on Save  
            createIframeAdminHelper.ClickElement("SaveBtn");
            
            //Wait for ext
            createIframeAdminHelper.WaitForText("Iframe Created Successfully.", 30);

        }
    }
}
