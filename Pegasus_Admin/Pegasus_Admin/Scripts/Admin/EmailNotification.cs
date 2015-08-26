using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.Admin
{
    [TestClass]
    public class EmailNotification : DriverTestCase
    {
        [TestMethod]
        public void emailNotification()
        {
            string[] username = null;
            string[] password = null;

            var oXMLData = new XMLParse();
            oXMLData.LoadXML("../../Config/ApplicationSettings.xml");

            username = oXMLData.getData("settings/Credentials", "username");
            password = oXMLData.getData("settings/Credentials", "password");

            //Initializing the objects
            var loginHelper = new LoginHelper(GetWebDriver());
            var clientHelper = new ClientsHelper(GetWebDriver());
            var emailNotificationHelper = new EmailNotificationHelper(GetWebDriver());

            // Variable
            var name = "Test" + RandomNumber(1, 99);


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Click On  Admin
            emailNotificationHelper.RedirectToAdmin();


            //Redirect To URL
            emailNotificationHelper.RedirectToPage();
            
            //verify title
            VerifyTitle("E-Mail Notifications");


//########  CREATED 

            //Click on When A Ticket Created
            emailNotificationHelper.ClickElement("WhenATicketCreated");

            //Click on Created Assigned To
            emailNotificationHelper.ClickElement("CreatedAssignedTo");

            //Click on Created Assigned Depatment
            emailNotificationHelper.ClickElement("CreatedAssignedDepatment");

            //Enter Email 
            emailNotificationHelper.TypeText("EmailCreated", "test@yopmail.com");

//#####  UPDATE

            //Click on When Ticket Update
            emailNotificationHelper.ClickElement("WhneTicketUpdate");


            //Click on Assigned To Update
            emailNotificationHelper.ClickElement("AssignedToUpdate");

            //Click on Assigned Manager Update
            emailNotificationHelper.ClickElement("AssignedManagerUpdate");

            //Enter Email 
            emailNotificationHelper.TypeText("EmailUpdate", "test@yopmail.com");

//#########  POSTED

            //Click on When Comment Posted
            emailNotificationHelper.ClickElement("WhenCommentPosted");

            //Click on Assigned To Posted
            emailNotificationHelper.ClickElement("AssignedToPosted");

            //Click on Assigned Department Posted
            emailNotificationHelper.ClickElement("AssignedDepartmentPosted");

            //Enter Email 
            emailNotificationHelper.TypeText("EmailPosetd", "test@yopmail.com");

            //Click on Save
            emailNotificationHelper.ClickElement("SaveBtn");
            
            //wait for text
            emailNotificationHelper.WaitForText("Alerts Saved Successfully.", 30);
        }
    }
}