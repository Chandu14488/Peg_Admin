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
    public class EditNewTask : DriverTestCase
    {
        [TestMethod]
        public void editNewTask()
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
            EditNewTaskAdminHelper editNewTaskAdminHelper = new EditNewTaskAdminHelper(GetWebDriver());

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
            editNewTaskAdminHelper.RedirectToAdmin();

            //Go tot add task
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/tasks");

            //Verify title
            VerifyTitle("Tasks");

//################################# ADD NOTE #############################################

            //Enter Subject in Search field
            editNewTaskAdminHelper.TypeText("EnterSubject", "Edit Subject");
            editNewTaskAdminHelper.WaitForWorkAround(3000);

            var loc = "//table[@id='list1']/tbody/tr[2]/td[text()='Tasks']";
            if (editNewTaskAdminHelper.IsElementPresent(loc))
            {


                //Click on Edit
                editNewTaskAdminHelper.ClickElement("ClickOnEdit");
                
                //Verify title
                VerifyTitle("Edit Task");

                //Enter Subject
                editNewTaskAdminHelper.TypeText("EnterSubjuct1", "Edit Subject");

                //Click On Save Btn
                editNewTaskAdminHelper.ClickElement("ClickOnSave");

                //wait for text
                editNewTaskAdminHelper.WaitForText("Task Updated Success.", 30);

            }

            else
            {

                // Click On Create
                editNewTaskAdminHelper.ClickElement("ClickOnNewTask");
                
                //Verify title
                VerifyTitle("Create a Task");

                //Enter Subject
                editNewTaskAdminHelper.TypeText("EnterSubjuct1", "Edit Subject");

                //Enter date
                editNewTaskAdminHelper.TypeText("EnterStartDate", "2015-05-05");


                //Due date
                editNewTaskAdminHelper.TypeText("EnterDueDate", "2015-11-10");
                
                //cLICK on Save  
                editNewTaskAdminHelper.ClickElement("ClickOnSave");

                editNewTaskAdminHelper.WaitForText("Task saved successfully.", 30);

                //####################    EDIT 

               //Go to task
                GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/tasks");

                //Verify title
                VerifyTitle("Tasks");

                //Enter Subject in Search field
                editNewTaskAdminHelper.TypeText("EnterSubject", "Edit Subject");
                editNewTaskAdminHelper.WaitForWorkAround(3000);

                //Click on Edit
                editNewTaskAdminHelper.ClickElement("ClickOnEdit");

                //Verify title
                VerifyTitle("Edit Task");

                //Enter Subject
                editNewTaskAdminHelper.TypeText("EnterSubjuct1", "Updated Subject");

                
                //Click On Save Btn
                editNewTaskAdminHelper.ClickElement("ClickOnSave");

            }
        }
    }
}
