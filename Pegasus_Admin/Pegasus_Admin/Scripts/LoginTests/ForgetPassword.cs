using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.LoginTests
{
    [TestClass]
    public class ForgetPassword : DriverTestCase
    {
        [TestMethod]
        public void forgetPassword()
        {
            //Initializing the objects
            LoginHelper loginHelper = new LoginHelper(GetWebDriver());
            ContactUsHelper contactUsHelper = new ContactUsHelper(GetWebDriver());

            //Login with blank username and password
         //   Login("", "");
          //  Console.WriteLine("Logged in as: " + "" + " / " + "");

            //Verify Page title
            VerifyTitle("Login");
              
            //Click on Contact Us
            contactUsHelper.ClickElement("ForgetPassword");

            //Enter Email
            contactUsHelper.TypeText("EnterEmailOfUserName", "Test@yopmail.com");

            //Click on Send Email btn
            contactUsHelper.ClickElement("ClickOnSendEmailBtn");
            contactUsHelper.WaitForWorkAround(3000);

            contactUsHelper.AcceptAlert();
     

            //Capture screenshot fot the screen
            TakeScreenshot("ForgetPassword");
        }
    }
}
