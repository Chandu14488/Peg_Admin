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
    public class CreateAPICodesIntegration : DriverTestCase
    {
        [TestMethod]
        public void createAPICodesIntegration()
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
            CreateAPICodesAdminHelper createAPICodesAdminHelper = new CreateAPICodesAdminHelper(GetWebDriver());

            // Variable
            String name = "1" + RandomNumber(1,99);


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Click On  Admin
            createAPICodesAdminHelper.RedirectToAdmin();

//##################  Redirect To Url

            //Redirect To URL
            createAPICodesAdminHelper.RedirectToPage();

            //verify title
            VerifyTitle("API Codes");

//################################# Create API CODES #############################################

            // Click On Create
            createAPICodesAdminHelper.ClickElement("ClickOnCreate");
            createAPICodesAdminHelper.WaitForWorkAround(4000);

            //Click on Generate API Code
            createAPICodesAdminHelper.ClickElement("ClickOnGenerateApi");
            createAPICodesAdminHelper.WaitForWorkAround(4000);

            //Enter Version
            createAPICodesAdminHelper.TypeText("Version", name);


            //Select  Status
            createAPICodesAdminHelper.SelectByText("Status", "New");


            //Select responsibilities
            createAPICodesAdminHelper.SelectByText("SelectResponsibilities", "Aslam Khan");

          

            //cLICK on Save  
            createAPICodesAdminHelper.ClickElement("SaveBtn");
            
            //Wait for text
            createAPICodesAdminHelper.WaitForText("API Code saved successfully.", 30);

        }
    }
}
