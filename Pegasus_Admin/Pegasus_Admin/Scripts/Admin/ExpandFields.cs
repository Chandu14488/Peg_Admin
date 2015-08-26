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
    public class ExpandFields : DriverTestCase
    {
        [TestMethod]
        public void expandFields()
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

            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Go to create Client page
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/clients/create");

            //Verify Title
            VerifyTitle("Create a Client");

           //Click on Company details
            addDocumentAdminHelper.ClickElement("CompanyDetailsTab");

            //Verify Company Details is already expanded
            addDocumentAdminHelper.verifyExpanded(1);

            //Click on Description text
            addDocumentAdminHelper.ClickElement("CompanyDetails");

            //Click on Description text
            addDocumentAdminHelper.ClickElement("DescriptionText");

            //Verify Field expanded
            addDocumentAdminHelper.verifyExpanded(3);

            //Click on Description text
            addDocumentAdminHelper.ClickElement("DescriptionText");

            //Click on More Company Details
            addDocumentAdminHelper.ClickElement("MoreDetails");

            //Verify Field expanded
            addDocumentAdminHelper.verifyExpanded(5);

            //Click on More Company Details
            addDocumentAdminHelper.ClickElement("MoreDetails");

            //Click on Site Survey
            addDocumentAdminHelper.ClickElement("SiteSurvay");

            //Verify Field expanded
            addDocumentAdminHelper.verifyExpanded(6);

            //Click on Site Survey
            addDocumentAdminHelper.ClickElement("SiteSurvay");
        }
    }
}
