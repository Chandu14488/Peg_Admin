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
    public class CreateMerchantTypeAdmin : DriverTestCase
    {
        [TestMethod]
        public void createMerchantTypeAdmin()
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
            CreateMerchantTypeAdminHelper createMerchantTypeAdminHelper = new CreateMerchantTypeAdminHelper(GetWebDriver());

            //Variable
            String name = "Test" + RandomNumber(1, 99);


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Click On  Admin
            createMerchantTypeAdminHelper.RedirectToAdmin();

//##################  Redirect To Url

            //Redirect To URL
            createMerchantTypeAdminHelper.RedirectToPage();

            //Verify title
            VerifyTitle("Master Merchant Types");

//################################# Create Product tab #############################################

            // Click On Create
            createMerchantTypeAdminHelper.ClickElement("ClickOnCreate");

            //Verify title
            VerifyTitle("Manage Master Merchant Types");

            //Enter Pricing Plan
            createMerchantTypeAdminHelper.TypeText("EnterMasterPlan", name);

          //  Click on Save button
             createMerchantTypeAdminHelper.ClickElement("SaveBtn");
             
            //Wait for text
             createMerchantTypeAdminHelper.WaitForText("The merchant type is successfully created!!", 30);



        }
    }
}
