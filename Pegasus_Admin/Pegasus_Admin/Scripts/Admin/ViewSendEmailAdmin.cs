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
    public class ViewSendEmailAdmin : DriverTestCase
    {
        //[TestMethod]
        public void viewSendEmailAdmin()
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
            EditEmailAdminHelper editEmailAdminHelper = new EditEmailAdminHelper(GetWebDriver());

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
            editEmailAdminHelper.RedirectToAdmin();


//################################# SEND E-MAIL #############################################

            // Click On send Email
            editEmailAdminHelper.ClickElement("ClickOnSendEmail");

            //Enter Name
            editEmailAdminHelper.TypeText("EnterSubjuct", name);

            //Click on importance
            editEmailAdminHelper.ClickElement("importance");

            //Select Department
            editEmailAdminHelper.TypeText("EnterMsgtxt", "This is testing description notes");

            //cLICK on Save  
            editEmailAdminHelper.ClickElement("ClickOnSend");
            editEmailAdminHelper.WaitForWorkAround(7000);




//################################# Edit Send Email #############################################


            // Select Activity Type
            editEmailAdminHelper.Select("SelectActivityType", "E-Mails");

            //Enter Subject in Search field
            editEmailAdminHelper.TypeText("EnterSubject", name);

            //Click on Edit
            editEmailAdminHelper.ClickElement("ClickOnView");
            editEmailAdminHelper.WaitForWorkAround(5000);







        }
    }
}
