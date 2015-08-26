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
    public class PDFImportWizard : DriverTestCase
    {
        [TestMethod]
        public void pDFImportWizard()
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
            PDFImportWizardHelper pDFImportWizardHelper = new PDFImportWizardHelper(GetWebDriver());

            // Variable
            String name = "Test" + RandomNumber(1,99);


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Click On  Admin
            pDFImportWizardHelper.RedirectToAdmin();

            //Redirect
            pDFImportWizardHelper.RedirectToPage();

            //Verify title
            VerifyTitle("PDF Import Wizard");

            //Click on Import  button
            pDFImportWizardHelper.ClickElement("ClickOnImport");

            //Choose Module
            pDFImportWizardHelper.Select("ChooseModule", "20");

            //Upload PDF File\
            String filename = GetPathToFile()+"2.pdf";
            pDFImportWizardHelper.upload("SelectFile", filename);

            //Click On Import
            pDFImportWizardHelper.ClickElement("ClickOnImport");
           
            pDFImportWizardHelper.WaitForWorkAround(10000);
            VerifyTitle("PDF Import Wizard");

            //Click On Next
            pDFImportWizardHelper.ClickElement("ClickOnNext");
            pDFImportWizardHelper.WaitForWorkAround(1000);

        }
    }
}
