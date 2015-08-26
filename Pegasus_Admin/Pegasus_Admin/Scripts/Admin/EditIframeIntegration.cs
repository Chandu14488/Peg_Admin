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
    public class EditIframeIntegration : DriverTestCase
    {
        [TestMethod]
        public void editIframeIntegration()
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
            EditIframeAdminHelper editIframeAdminHelper = new EditIframeAdminHelper(GetWebDriver());

            // Variable
            String name = "Test" + RandomNumber(1, 99);
            String usrname = "Test.Tester" + RandomNumber(1, 99);

            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Click On  Admin
            editIframeAdminHelper.RedirectToAdmin();

            //Redirect To URL
            editIframeAdminHelper.RedirectToPage();

            //Verify title
            VerifyTitle("Iframe Apps");

            //################################# iframe tab setting #############################################
            //Enter Tab name search 
            editIframeAdminHelper.TypeText("TabNameSrch", "Edit Iframe");
            editIframeAdminHelper.WaitForWorkAround(3000);


            //IF PRESENT
            var LOC = "//table[@id='list1']/tbody/tr[2]/td[text()='Edit Iframe']";
            if (editIframeAdminHelper.IsElementPresent(LOC))
            {
                //Click On Edit Btn
                editIframeAdminHelper.ClickElement("ClickOnEditBtn");

                //Verify title
                VerifyTitle("Edit Iframe");

                // ##############   EDIT DETAILS

                //Enter Tab Name
                editIframeAdminHelper.TypeText("TabName", "Edit Iframe");

                //#################################   APP SETTING   ######################3


                //Click on Generate API Code
                editIframeAdminHelper.TypeText("UserNameInputFieldName", usrname);
                
                //Select  Status
                editIframeAdminHelper.TypeText("PasswordInputFieldNmae", "1qaz!QAZ");


                //Select responsibilities
                editIframeAdminHelper.TypeText("LoginURL", "https://www.pegasus-test.com/selenium_corp/selenium_office/login");

                //Click on mainportal
                editIframeAdminHelper.ClickElement("mainportal");

                //cLICK on Save  
                editIframeAdminHelper.ClickElement("SaveBtn");
                
                //Wait for text
                editIframeAdminHelper.WaitForText("Iframe Created Successfully.", 30);
            }
            else
            {
                // Click On Create
                editIframeAdminHelper.ClickElement("ClickOnCreate");
                
                //Verify title
                VerifyTitle("Create Iframe");

                //Enter Tab Name
                editIframeAdminHelper.TypeText("TabName", "Edit Iframe");

                //#################################   APP SETTING   ######################3


                //Click on Generate API Code
                editIframeAdminHelper.TypeText("UserNameInputFieldName", usrname);

                //Select  Status
                editIframeAdminHelper.TypeText("PasswordInputFieldNmae", "1qaz!QAZ");


                //Select responsibilities
                editIframeAdminHelper.TypeText("LoginURL", "https://www.pegasus-test.com/selenium_corp/selenium_office/login");

                //Click on mainportal
                editIframeAdminHelper.ClickElement("mainportal");

                //cLICK on Save  
                editIframeAdminHelper.ClickElement("SaveBtn");

                editIframeAdminHelper.WaitForText("Iframe Created Successfully.", 30);



                //#################   EDIT     ####################

                //Verify title
                VerifyTitle("Iframe Apps");

                //Enter Tab name search 
                editIframeAdminHelper.TypeText("TabNameSrch", name);

                //Click On Edit Btn
                editIframeAdminHelper.ClickElement("ClickOnEditBtn");

                // ##############   EDIT DETAILS

                //Enter Tab Name
                editIframeAdminHelper.TypeText("TabName", "Edit Iframe");

                //#################################   APP SETTING   ######################3


                //Click on Generate API Code
                editIframeAdminHelper.TypeText("UserNameInputFieldName", usrname);

                //Select  Status
                editIframeAdminHelper.TypeText("PasswordInputFieldNmae", "1qaz!QAZ");


                //Select responsibilities
                editIframeAdminHelper.TypeText("LoginURL", "https://www.pegasus-test.com/selenium_corp/selenium_office/login");

                //Click on mainportal
                editIframeAdminHelper.ClickElement("mainportal");

                //cLICK on Save  
                editIframeAdminHelper.ClickElement("SaveBtn");

                //Wait for text
                editIframeAdminHelper.WaitForText("Iframe Created Successfully.", 30);


            }

        }
    }
}
