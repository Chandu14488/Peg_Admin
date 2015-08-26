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
    public class EditDepartmentOffice : DriverTestCase
    {
        [TestMethod]
        public void editDepartmentOffice()
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
            EditDepartmentHelper editDepartmentHelper = new EditDepartmentHelper(GetWebDriver());

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
            editDepartmentHelper.RedirectToAdmin();

            //Redirect To URL
            editDepartmentHelper.RedirectToPage();

            //Verify title
            VerifyTitle("Departments");
//################################# Create Department office #############################################


            //Search 
             editDepartmentHelper.TypeText("SearchName","Edit Department");
             editDepartmentHelper.WaitForWorkAround(5000);
             var loc = "//table[@id='list1']/tbody/tr[2]/td[@aria-describedby='list1_name']/a[text()='Edit Department']";

             if (editDepartmentHelper.IsElementPresent(loc))
             {

                 //Click on  EDT
                 editDepartmentHelper.ClickElement("Edit1");
                 editDepartmentHelper.WaitForWorkAround(5000);

                 //Enter DepartmentName
                 editDepartmentHelper.TypeText("DepartmentName", "Edit Department");

                 //Enter Description
                 editDepartmentHelper.TypeText("Descripton", "THIS IS TESTING DESCRIPTION");


                 //cLICK on Save  
                 editDepartmentHelper.ClickElement("ClickOnSave");
             }
             else
             {
                 // Click On Create
                 editDepartmentHelper.ClickElement("ClickOnCreate");

                 //Wait for text
                 VerifyTitle("Create a Department");

                 //Enter DepartmentName
                 editDepartmentHelper.TypeText("DepartmentName", "Edit Department");

                 //Enter Description
                 editDepartmentHelper.TypeText("Descripton", "THIS IS TESTING DESCRIPTION");


                 //cLICK on Save  
                 editDepartmentHelper.ClickElement("ClickOnSave");

                 editDepartmentHelper.WaitForText("Department has been saved.",30);

                 //Redirect To URL
                 editDepartmentHelper.RedirectToPage();

                 //Verify title
                 VerifyTitle("Departments");

                 //#############################   EDIT  

                 
                 // Search
                 editDepartmentHelper.TypeText("SearchName", "Edit Department");
                 editDepartmentHelper.WaitForWorkAround(3000);

                 //Click on  EDT
                 editDepartmentHelper.ClickElement("Edit1");
                 
                 //Verify title
                 VerifyTitle("Edit a Department");

                 //Enter DepartmentName
                 editDepartmentHelper.TypeText("DepartmentName", "Edit Department");

                 //Enter Description
                 editDepartmentHelper.TypeText("Descripton", "THIS IS TESTING DESCRIPTION");


                 //cLICK on Save  
                 editDepartmentHelper.ClickElement("ClickOnSave");

             }
        }
    }
}
