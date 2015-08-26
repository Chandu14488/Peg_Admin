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
    public class CreateAdminProcessor : DriverTestCase
    {
        [TestMethod]
        public void createAdminProcessor()
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
            CreateAdminProcessorHelper createAdminProcessorHelper = new CreateAdminProcessorHelper(GetWebDriver());

            //Variable
            String name = "Test" + RandomNumber(1, 99);
            String code = "12" + RandomNumber(1, 99);


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");


//#######################  MOVE HOVER TO THE WELCOME

            //Click On  Admin
            createAdminProcessorHelper.RedirectToAdmin();

//##################  Redirect To Url

            //Redirect To URL
            createAdminProcessorHelper.RedirectToPage();

            //Verify title
            VerifyTitle("Master Processors");

//################################# Create Product tab #############################################

            // Click On Create
            createAdminProcessorHelper.ClickElement("ClickOnCreate");

            //Verify title
            VerifyTitle("Manage Processor");

            //Enter Processor Name
            createAdminProcessorHelper.TypeText("ProcessorName", name);

            // Click On ProcessorCode
            createAdminProcessorHelper.TypeText("ProcessorCode", code);
            createAdminProcessorHelper.WaitForWorkAround(2000);

          //  Click on Save button
            createAdminProcessorHelper.ClickElement("SaveBtn");
            
            //Wait for text
            createAdminProcessorHelper.WaitForText("The processor is successfully created!!", 30);



        }
    }
}
