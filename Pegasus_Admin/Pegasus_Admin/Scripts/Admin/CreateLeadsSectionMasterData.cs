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
    public class CreateLeadsSectionMasterData : DriverTestCase
    {
        [TestMethod]
        public void createLeadsSectionMasterData()
        {
            string[] username = null;
            string[] password = null;

            XMLParse oXMLData = new XMLParse();
            oXMLData.LoadXML("../../Config/ApplicationSettings.xml");
            string[] URL2 = oXMLData.getData("settings/URL", "application2");

            username = oXMLData.getData("settings/Credentials", "username");
            password = oXMLData.getData("settings/Credentials", "password");

            //Open application2 url
            Console.WriteLine("Second URL: " + URL2[0]);
            GetWebDriver().Navigate().GoToUrl(URL2[0]);



            //Initializing the objects
            LoginHelper loginHelper = new LoginHelper(GetWebDriver());
            ClientsHelper clientHelper = new ClientsHelper(GetWebDriver());
            EditPrcingPlanHelperAdmin editPrcingPlanHelperAdmin = new EditPrcingPlanHelperAdmin(GetWebDriver());

            //Variable
            String name = "Test" + RandomNumber(99, 999);
            String num = "Test" + RandomNumber(1, 99);


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");


            //Click On  Admin
            GetWebDriver().Navigate().GoToUrl("http://pegasus-test.info/selenium_corp/selenium_office/admin");
            

//##################  Redirect To Url

            //Redirect To URL
            GetWebDriver().Navigate().GoToUrl("http://pegasus-test.info/selenium_corp/selenium_office/sections");
           
            //Verify title
            VerifyTitle("Section Management");
//################################# Create Product tab #############################################

            //Select lead
            editPrcingPlanHelperAdmin.Selectbytext("SelectLeadDropDown", "Leads");

            //Click Create Btn
            editPrcingPlanHelperAdmin.ClickElement("ClickCreateBtn");
            editPrcingPlanHelperAdmin.WaitForWorkAround(4000);


            //Select TAB
            editPrcingPlanHelperAdmin.Selectbytext("SelectTabName", "Business Details");

            //Enter Name
            editPrcingPlanHelperAdmin.TypeText("EnterSectionName", name);

            //Click on save button
            editPrcingPlanHelperAdmin.ClickElement("SaveSecBtn");
            

            //Accept Alert
            editPrcingPlanHelperAdmin.AcceptAlert();
            
            //Verify text Present
            editPrcingPlanHelperAdmin.WaitForText(name,30);

            //Click On Lead Tab 
            GetWebDriver().Navigate().GoToUrl("http://pegasus-test.info/selenium_corp/selenium_office/leads");

            //Click On Any Client
            editPrcingPlanHelperAdmin.ClickElement("ClickOnAnyLead");

            //Verify title
            VerifyTitle("- Details");

            //Click on Company Details Tab
            editPrcingPlanHelperAdmin.ClickElement("ClickOnCompanyDetails");

            //Verify text present
            editPrcingPlanHelperAdmin.WaitForText(name,30);
        }
    }
}
