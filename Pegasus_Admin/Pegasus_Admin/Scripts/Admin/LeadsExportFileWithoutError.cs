using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class LeadsExportFileWithoutError : DriverTestCase
    {
        [TestMethod]
        public void leadsExportFileWithoutError()
        {
            string[] username = null;
            string[] password = null;

            XMLParse oXMLData = new XMLParse();
            oXMLData.LoadXML("../../Config/ApplicationSettings.xml");

            username = oXMLData.getData("settings/Credentials", "username");
            password = oXMLData.getData("settings/Credentials", "password");

            //Initializing the objects
            LoginHelper loginHelper = new LoginHelper(GetWebDriver());
            AddDocumentAdminHelper addDocumentAdminHelper = new AddDocumentAdminHelper(GetWebDriver());

            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

           //Redirect to client page
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/leads");

            //Verify Title
            VerifyTitle("Leads");

            //Export as CSV
            addDocumentAdminHelper.ExportAs("CSV");

            //Verify No error displayed
            addDocumentAdminHelper.VerifyTextNotPresent("Some issues occured in this operation, Contact technical support for help");

            //Export as Excel
            addDocumentAdminHelper.ExportAs("Excel");

            //Verify No error displayed
            addDocumentAdminHelper.VerifyTextNotPresent("Some issues occured in this operation, Contact technical support for help");

        }
    }
}
