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
    public class CreatePricingPlanAdmin : DriverTestCase
    {
        [TestMethod]
        public void createPricingPlanAdmin()
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
            CreatePrcingPlanHelperAdmin createPrcingPlanHelperAdmin = new CreatePrcingPlanHelperAdmin(GetWebDriver());

            //Variable
            String name = "100" + RandomNumber(1, 99);


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Click On  Admin
            createPrcingPlanHelperAdmin.RedirectToAdmin();

            //Redirect To URL
            createPrcingPlanHelperAdmin.RedirectToPage();
            
            //Verify title
            VerifyTitle("Master Pricing Plans");

//################################# Create Product tab #############################################

            // Click On Create
            createPrcingPlanHelperAdmin.ClickElement("ClickOnCreate");
            
            //Verify title
            VerifyTitle("Manage Master Pricing Plans");

            //Enter Pricing Plan
            createPrcingPlanHelperAdmin.TypeText("PricingPlan", name);

            // Click On Create
            createPrcingPlanHelperAdmin.Selectbytext("Processor", "Chy Processor");

          //  Click on Save button
                createPrcingPlanHelperAdmin.ClickElement("SaveBtn");
                
            //Wait for text
                createPrcingPlanHelperAdmin.WaitForText("The pricing plan is successfully created!!", 30);


        }
    }
}
