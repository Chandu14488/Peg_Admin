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
    public class NewMeetingAdmin : DriverTestCase
    {
        [TestMethod]
        public void newMeetingAdmin()
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
            NewMeetingAdminHelper newMeetingAdminHelper = new NewMeetingAdminHelper(GetWebDriver());

            // Variable
            String name = "Testing Subject" + RandomNumber(1,99);
            String email = "Test" + RandomNumber(1,999)+ "@gmail.com.com";


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Click On  Admin
            newMeetingAdminHelper.RedirectToAdmin();

//################################# NEW MEETING #############################################

            // Click On Create
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/meetings/create");

            VerifyTitle("Create a Meeting");

            //Enter Subject
            newMeetingAdminHelper.TypeText("EnterSubject", name);

            //Enter Meeting location
            newMeetingAdminHelper.TypeText("MeetingLocation", "Test Meeting");

            //Enter date
            newMeetingAdminHelper.TypeText("EnterStartDate", "2015-05-05");


            //Due date
            newMeetingAdminHelper.TypeText("EnterEndDate", "2015-11-10");

            //Select releted to
            newMeetingAdminHelper.Select("RelatedTo","20");

            //Click on assign
            newMeetingAdminHelper.ClickElement("Assign");
            newMeetingAdminHelper.WaitForWorkAround(5000);

            //Select usre
            newMeetingAdminHelper.ClickElement("User");
            newMeetingAdminHelper.WaitForWorkAround(5000);

            //cLICK on Save  
            newMeetingAdminHelper.ClickElement("ClickOnSave");

            //Verify text
            newMeetingAdminHelper.WaitForText("Meeting saved successfully.",30);
        }
    }
}
