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
    public class CheckProcessor : DriverTestCase
    {
        [TestMethod]
        public void checkProcessor()
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
            AddDocumentAdminHelper addDocumentAdminHelper = new AddDocumentAdminHelper(GetWebDriver());

            // Variable
            var Proname = "Product" + RandomNumber(100, 999);


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Click On  Admin
            addDocumentAdminHelper.RedirectToAdmin();

            //Redirect to the master Processors page
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/processor_types");

            //verify title
            VerifyTitle("Master Processors");

            //Get all processor count
            int processcount = addDocumentAdminHelper.GetProcessorCount("ProcessTable");

            //Get all processor
            string[] processor = addDocumentAdminHelper.GetAllProcessor("ProcessTable");

            //Redirect to the Create client page
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/clients/create");

            //Verify title
            VerifyTitle("Create a Client");

            //Click on Bussiness details
            addDocumentAdminHelper.ClickElement("Bussiness");

            //Verify Count
            addDocumentAdminHelper.VerifyProcessCount("ProcessDropdown", processcount);

            //Verify all processor
            addDocumentAdminHelper.VerifyAllProcessor("ProcessDropdown", processor);


        }
    }
}
