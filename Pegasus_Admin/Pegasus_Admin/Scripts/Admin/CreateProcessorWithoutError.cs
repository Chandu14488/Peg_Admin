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
    public class CreateProcessorWithoutError : DriverTestCase
    {
        [TestMethod]
        public void createProcessorWithoutError()
        {
            string[] username = null;
            string[] password = null;

            XMLParse oXMLData = new XMLParse();
            oXMLData.LoadXML("../../Config/ApplicationSettings.xml");

            username = oXMLData.getData("settings/Credentials", "username2");
            password = oXMLData.getData("settings/Credentials", "password2");

            var ProcessName = "Process" + RandomNumber(100, 999);

            //Initializing the objects
            LoginHelper loginHelper = new LoginHelper(GetWebDriver());
            AddDocumentAdminHelper addDocumentAdminHelper = new AddDocumentAdminHelper(GetWebDriver());

            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Go to Processor page
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/masterdata/processor_types");

            //Verify title
            VerifyTitle("Master Processors");

            //Verify created avatar is available
            bool available = addDocumentAdminHelper.verifyAvatarAvailable(ProcessName);

            if (available)
            {
                //Delete the processor
                addDocumentAdminHelper.deleteProcessor(ProcessName);
            }

             //Go to create Processor page
                GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/masterdata/manage_processors");

             //Verify Title
                VerifyTitle("Manage Processor");

             //Enter Process name
                addDocumentAdminHelper.TypeText("ProcessName", ProcessName);

             //Enter Process Code
                addDocumentAdminHelper.TypeText("ProcessCode", RandomNumber(100, 999).ToString());

             //Click on Save button
                addDocumentAdminHelper.ClickElement("ProcessSave");

             //Verify title
                VerifyTitle("Master Processors");

             //Verify process added sussfully
                Assert.IsTrue(addDocumentAdminHelper.verifyAvatarAvailable(ProcessName));

            //Delete created processor
                addDocumentAdminHelper.deleteProcessor(ProcessName);

        }
    }
}
