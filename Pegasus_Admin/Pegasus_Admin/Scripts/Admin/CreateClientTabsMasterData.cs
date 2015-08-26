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
    public class CreateClientTabsMasterData : DriverTestCase
    {
        [TestMethod]
        public void createClientTabsMasterData()
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
            String name = "Test" + RandomNumber(1, 99);
            String num = "Test" + RandomNumber(1, 99);


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Click on Clients in Topmenu
//            clientHelper.clickClients();

            //Click to open client info
   //         clientHelper.OpenClient();


            //Click On  Admin
            GetWebDriver().Navigate().GoToUrl("http://pegasus-test.info/selenium_corp/selenium_office/admin");
            

            //Redirect To URL
            GetWebDriver().Navigate().GoToUrl("http://pegasus-test.info/selenium_corp/selenium_office/tabs");
           
            //Verify title
            VerifyTitle("Tabs Management");

//################################# Create Product tab #############################################

            //Select lead
            editPrcingPlanHelperAdmin.Select("SelectLeadDropDown", "20");

            //Click Create Btn
            editPrcingPlanHelperAdmin.ClickElement("ClickCreateBtn1");
            editPrcingPlanHelperAdmin.WaitForWorkAround(1000);

            //Enter Name
            editPrcingPlanHelperAdmin.TypeText("EnterName", name);

            //Click on save button
            editPrcingPlanHelperAdmin.ClickElement("ClickSaveBtn");

            //Wait for text
            editPrcingPlanHelperAdmin.WaitForText("Tab Created Successfully", 30);

            //Click On  Admin
            GetWebDriver().Navigate().GoToUrl("http://pegasus-test.info/selenium_corp/selenium_office/clients");
            
            //Verify title
            VerifyTitle("Clients");

            //Click On Any Client
            editPrcingPlanHelperAdmin.ClickElement("ClickOnAnyClient");

            //Verify title
            VerifyTitle("- Details");

            //Verify text present
            editPrcingPlanHelperAdmin.WaitForText(name,30);
            
        }
    }
}
