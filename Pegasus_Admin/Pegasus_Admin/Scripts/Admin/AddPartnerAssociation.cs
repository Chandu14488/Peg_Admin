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
    public class AddPartnerAssociation : DriverTestCase
    {
        [TestMethod]
        public void addPartnerAssociation()
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

            //Go to Client page
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/clients");

            //Verify Title
            VerifyTitle("Clients");

            //Check partner Associan is available
            bool verify = addDocumentAdminHelper.VerifyPartnerAssociation("PartnerAsso");
            
            //Add if not available
            if (verify)
            {
                Console.WriteLine("Partner Association is available");
                Assert.IsTrue(addDocumentAdminHelper.VerifyPartnerAssociation("AssoDrop"));
            }
            else
            {
                //Click on Advanced filter button
                addDocumentAdminHelper.ClickElement("AdvanceFilter");

                //Select Partner association from Available Columns
                addDocumentAdminHelper.ClickElement("PartnerAgent");

                //Click on Move arrow
                addDocumentAdminHelper.ClickElement("Add");

                //Verify Partner association added in the Display Columns
                addDocumentAdminHelper.verifyColumnAdded("AddPartner");

                //Click on apply button
                addDocumentAdminHelper.ClickElement("Apply");
                addDocumentAdminHelper.ClickElement("Apply");
            }
            Assert.IsTrue(addDocumentAdminHelper.VerifyPartnerAssociation("AssoDrop"));
        }
    }
}
