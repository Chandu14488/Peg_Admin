using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class CreateDuplicateAvatarError : DriverTestCase
    {
        [TestMethod]
        public void createDuplicateAvatarError()
        {
            string[] username = null;
            string[] password = null;

            XMLParse oXMLData = new XMLParse();
            oXMLData.LoadXML("../../Config/ApplicationSettings.xml");

            username = oXMLData.getData("settings/Credentials", "username2");
            password = oXMLData.getData("settings/Credentials", "password2");

            var AvatarName = "Avatar" + RandomNumber(100, 999);

            //Initializing the objects
            LoginHelper loginHelper = new LoginHelper(GetWebDriver());
            AddDocumentAdminHelper addDocumentAdminHelper = new AddDocumentAdminHelper(GetWebDriver());

            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Go to Avatar page
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/avatars");

            //Verify title
            VerifyTitle("Avatars");

            //Verify created avatar is available
            bool available = addDocumentAdminHelper.verifyAvatarAvailable(AvatarName);
            bool flag = true;
            //Create AVATAR IS NOT AVAILABLE

            //Go to create Avatar page
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/avatars/create");

            //Verify Title
            VerifyTitle("Create an Avatar");

            //Enter avatar name
            addDocumentAdminHelper.TypeText("AvatarName", AvatarName);

            //Select User type
            addDocumentAdminHelper.SelectByText("AvatarType", "Employee");

            //Select Status
            addDocumentAdminHelper.SelectByText("AvatarStatus", "Active");

            //Click on Save button
            addDocumentAdminHelper.ClickElement("ProSave");

            if (available)
            {
                //Verify ERROR
                addDocumentAdminHelper.VerifyPageText("Avatar exists with this name.");

                flag = false;
            }
            else
            {
                //Verify title
                VerifyTitle("Avatars");

                //Avatar is available
                Assert.IsTrue(addDocumentAdminHelper.verifyAvatarAvailable(AvatarName));
            }

            if (flag)
            {
                //Go to create Avatar page
                GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/avatars/create");

                //Verify Title
                VerifyTitle("Create an Avatar");

                //Enter avatar name
                addDocumentAdminHelper.TypeText("AvatarName", AvatarName);

                //Select User type
                addDocumentAdminHelper.SelectByText("AvatarType", "Employee");

                //Select Status
                addDocumentAdminHelper.SelectByText("AvatarStatus", "Active");

                //Click on Save button
                addDocumentAdminHelper.ClickElement("ProSave");

                //Verify ERROR
                addDocumentAdminHelper.WaitForText("Avatar exists with this name.",30);

            }


        }
    }
}
