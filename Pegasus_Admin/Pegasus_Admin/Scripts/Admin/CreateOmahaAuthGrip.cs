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
    public class CreateOmahaAuthGrip : DriverTestCase
    {
        [TestMethod]
        public void createOmahaAuthGrip()
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
            CreateOmahaAuthGripHelper createOmahaAuthGripHelper = new CreateOmahaAuthGripHelper(GetWebDriver());

            //Variable
            String name = "3" + RandomNumber(1, 99);
            String code = "1" + RandomNumber(1, 99);


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Click On  Admin
            createOmahaAuthGripHelper.RedirectToAdmin();

//##################  Redirect To Url

            //Redirect To URL
            createOmahaAuthGripHelper.RedirectToPage();

            //Verify title
            VerifyTitle("Omaha Auth Grids");

//################################# Create Product tab #############################################

            // Click On Create
            createOmahaAuthGripHelper.ClickElement("ClickOnCreate");

            //Wait
            createOmahaAuthGripHelper.WaitForWorkAround(3000);

            //Enter Grid Id
            createOmahaAuthGripHelper.TypeText("GridId", name);

            //Enter Visa Pos Authfees
            createOmahaAuthGripHelper.TypeText("VisaPosAuthfees", code);

            //Enter MC Pos Auth Fees
            createOmahaAuthGripHelper.TypeText("MCPosAuthFees", name);

            //Enter Amex Pos AuthFees
            createOmahaAuthGripHelper.TypeText("AmexPosAuthFees", name);

            //Enter Disc Pos Auth Fees
            createOmahaAuthGripHelper.TypeText("DiscPosAuthFees", code);

            //Enter JCD Pos Auth Fees
            createOmahaAuthGripHelper.TypeText("JCDPosAuthFees", name);

            //Enter Voice Auth Fees
            createOmahaAuthGripHelper.TypeText("VoiceAuthFees", code);

            //Enter AVS Electronic Fees
            createOmahaAuthGripHelper.TypeText("AVSElectronicFees", name);

            //Enter AVS Voice Fees
            createOmahaAuthGripHelper.TypeText("AVSVoiveFees", code);

            //Enter AVS Voive Fees
            createOmahaAuthGripHelper.TypeText("ARUFees", name);

          //  Click on Save button
            createOmahaAuthGripHelper.ClickElement("SaveBtn");
            
            //Wait for text
            createOmahaAuthGripHelper.WaitForText("Master Omaha Auth Grid Created Successfully.", 30);



        }
    }
}
