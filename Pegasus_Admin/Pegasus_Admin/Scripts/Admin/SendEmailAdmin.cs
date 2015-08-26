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
    public class SendEmailAdmin : DriverTestCase
    {
        //[TestMethod]
        public void sendEmailAdmin()
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
            SendEmailAdminHelper sendEmailAdminHelper = new SendEmailAdminHelper(GetWebDriver());

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
            sendEmailAdminHelper.RedirectToAdmin();


//################################# SEND E-MAIL #############################################

            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/mails");

            VerifyTitle("Mails");

            // Click On send Email
            sendEmailAdminHelper.ClickElement("ClickOnSendEmail");

            //Verify title
            VerifyTitle("Compose");

            //Enter to
            sendEmailAdminHelper.TypeText("To", "test@yopmail.com");
            //Enter Name
            sendEmailAdminHelper.TypeText("EnterSubjuct", name);

            //Click on importance
            sendEmailAdminHelper.ClickElement("importance");

            //Select Department
            sendEmailAdminHelper.TypeText("EnterMsgtxt", "This is testing description notes");

            //cLICK on Save  
            sendEmailAdminHelper.ClickElement("ClickOnSend");
            
            //Wait for text
            sendEmailAdminHelper.WaitForText("E-Mail Sent Successfully.", 30);

        }
    }
}
