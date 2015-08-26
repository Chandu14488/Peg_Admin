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
    public class ContactUs:DriverTestCase
    {
        [TestMethod]
        public void contactUs()
        {
            //Initializing the objects
            LoginHelper loginHelper = new LoginHelper(GetWebDriver());
            ContactUsHelper contactUsHelper = new ContactUsHelper(GetWebDriver());

          
            //Verify Page title
            VerifyTitle("Login");
              
            //Click on Contact Us
            contactUsHelper.ClickElement("ContactUsLink");

            //Enter Name
            contactUsHelper.TypeText("EnterName","Test");

            //Enter Email
            contactUsHelper.TypeText("EnterEmail", "test@yopmail.com");

            //Enter Subject
            contactUsHelper.TypeText("EnterSubject", "Test Subject");

            //Enter Message
            contactUsHelper.TypeText("EnterMessage", "This is Test Message");

            //Click on Send
            contactUsHelper.ClickElement("Send");
            contactUsHelper.WaitForWorkAround(3000);
     

            //Capture screenshot fot the screen
//            TakeScreenshot("ContactUs");
        }
    }
}
