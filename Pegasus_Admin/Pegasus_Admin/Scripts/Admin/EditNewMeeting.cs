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
    public class EditNewMeeting : DriverTestCase
    {
        [TestMethod]
        public void editNewMeeting()
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
            EditNewMeetingAdminHelper editNewMeetingAdminHelper = new EditNewMeetingAdminHelper(GetWebDriver());

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
            editNewMeetingAdminHelper.RedirectToAdmin();

            // Go to meeting
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/meetings/create");

            //Verify title
            VerifyTitle("Create a Meeting");

            //Enter Subject
            editNewMeetingAdminHelper.TypeText("EnterSubject", name);

            //Enter Meeting location
            editNewMeetingAdminHelper.TypeText("MeetingLocation", "Test Meeting");

            //Select Priority
            editNewMeetingAdminHelper.Select("SelectPriority", "Low");

            //Select Department
//            editNewMeetingAdminHelper.TypeText("EnterDescription", "This is testing description notes");

            //select
            editNewMeetingAdminHelper.Select("RelatedTo", "20");
            

            //Click on Assing
            editNewMeetingAdminHelper.ClickElement("Assign");

            editNewMeetingAdminHelper.WaitForWorkAround(5000);

            editNewMeetingAdminHelper.ClickElement("AssignPart");

            editNewMeetingAdminHelper.WaitForWorkAround(5000);

            //Enter date
            editNewMeetingAdminHelper.TypeText("EnterStartDate", "2015-05-05");

            //Due date
            editNewMeetingAdminHelper.TypeText("EnterEndDate", "2015-11-10");

            //cLICK on Save  
            editNewMeetingAdminHelper.ClickElement("ClickOnSave");
            
            //Wait for text
            editNewMeetingAdminHelper.WaitForText("Meeting saved successfully.", 30);

            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/meetings");
            //Verify title
            VerifyTitle("Meetings");


//############################    EDIT 

            
            //Enter Subject in Search field
            editNewMeetingAdminHelper.TypeText("EnterSubjectserch", name);
            editNewMeetingAdminHelper.WaitForWorkAround(5000);

            //Click on Edit
            editNewMeetingAdminHelper.ClickElement("ClickOnEdit");

            VerifyTitle("Edit Meeting");
            

            //Enter Subject
            editNewMeetingAdminHelper.TypeText("EnterSubject", "New Subject");

            //Edit Start Date
            editNewMeetingAdminHelper.TypeText("EnterEndDate", "2015-07-17");

            //Click On Save Btn
            editNewMeetingAdminHelper.ClickElement("ClickOnSave");




        }
    }
}
