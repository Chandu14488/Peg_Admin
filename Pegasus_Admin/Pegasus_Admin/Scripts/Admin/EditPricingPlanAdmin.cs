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
    public class EditPricingPlanAdmin : DriverTestCase
    {
        [TestMethod]
        public void editPricingPlanAdmin()
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
            EditPrcingPlanHelperAdmin editPrcingPlanHelperAdmin = new EditPrcingPlanHelperAdmin(GetWebDriver());

            //Variable
            String name = "Test" + RandomNumber(1, 99);
            String num = "Test" + RandomNumber(1, 99);


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

          
            //Click On  Admin
            editPrcingPlanHelperAdmin.RedirectToAdmin();

            //##################  Redirect To Url

            //Redirect To URL
            editPrcingPlanHelperAdmin.RedirectToPage();

            //Verify title
            VerifyTitle("Master Pricing Plans");

//################################# Create Product tab #############################################

            // Click On Create
            editPrcingPlanHelperAdmin.ClickElement("ClickOnCreate");

            //Verify title
            VerifyTitle("Manage Master Pricing Plans");

            //Enter Pricing Plan
            editPrcingPlanHelperAdmin.TypeText("PricingPlan", name);

          //  Click on Save button
             editPrcingPlanHelperAdmin.ClickElement("SaveBtn");
             editPrcingPlanHelperAdmin.WaitForWorkAround(3000);

//########################  EDIT
            //Verify title
             VerifyTitle("Master Pricing Plans");

            //Click on Edit icon
             editPrcingPlanHelperAdmin.TypeText("Search", name);
             editPrcingPlanHelperAdmin.WaitForWorkAround(4000);

             //  Click on Edit button
             editPrcingPlanHelperAdmin.ClickElement("EditIcn");
             
            //Verify title
             VerifyTitle("Manage Master Pricing Plans");

             //Enter Pricing Plan
             editPrcingPlanHelperAdmin.TypeText("PricingPlan", num);

             //  Click on Save button
             editPrcingPlanHelperAdmin.ClickElement("SaveBtn");
             editPrcingPlanHelperAdmin.WaitForWorkAround(3000);

        }
    }
}
