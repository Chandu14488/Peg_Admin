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
    public class CreateSystemSchedular : DriverTestCase
    {
        [TestMethod]
        public void createSystemSchedular()
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
            CreateSystemSchedularHelper createSystemSchedularHelper = new CreateSystemSchedularHelper(GetWebDriver());

            // Variable
            String name = "Test" + RandomNumber(1,99);
            String email = "Test" + RandomNumber(1,999)+ "@gmail.com.com";


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Click On  Admin
            createSystemSchedularHelper.RedirectToAdmin();

            //Redirect To URL
            createSystemSchedularHelper.RedirectToPage();

            //Verify title
            VerifyTitle("Schedulers");

//################################# Create Master Category #############################################

            // Click On Create
            createSystemSchedularHelper.ClickElement("ClickOnCreate");

            //Verify title
            VerifyTitle("Create a Scheduler");

            //Enter Job Name
            createSystemSchedularHelper.TypeText("JobName", name);

            //Select JOB
            createSystemSchedularHelper.Select("Job", "sendEmailReminders");

            //Enter Description
            createSystemSchedularHelper.ClickElement("SelectAll");

            //cLICK on Save  
            createSystemSchedularHelper.ClickElement("ClickOnSave");
           
        }
    }
}
