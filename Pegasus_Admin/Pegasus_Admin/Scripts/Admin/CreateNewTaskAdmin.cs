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
    public class CreateNewTaskAdmin : DriverTestCase
    {
        [TestMethod]
        public void createNewTaskAdmin()
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
            NewTaskAdminHelper newTaskAdminHelper = new NewTaskAdminHelper(GetWebDriver());

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
            newTaskAdminHelper.RedirectToAdmin();

//################################# Corprate TAB #############################################

            //Click on Terminal And Equipment Tab
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/mycorp");
            
            //Verify title
            VerifyTitle("SelCorp Details");


//################################# ADD New Task #############################################

            // Click On Create
            newTaskAdminHelper.ClickElement("ClickOnNewTask");
            newTaskAdminHelper.WaitForWorkAround(4000);

            //Enter Subject
            newTaskAdminHelper.TypeText("EnterSubjuct", name);

            //Select Priority
            newTaskAdminHelper.Select("SelectPriority", "Low");

            //Select Department
            newTaskAdminHelper.TypeText("EnterDescription", "This is testing description notes");

            //Enter date
            newTaskAdminHelper.TypeText("EnterStartDate", "2015-05-05");
            
            //Due date
            newTaskAdminHelper.TypeText("EnterDueDate", "2015-11-10");

            //cLICK on Save  
            newTaskAdminHelper.ClickElement("ClickOnSave");

            //verify text present
            newTaskAdminHelper.WaitForText("Task Created Successfully.",30);

        }
    }
}                
