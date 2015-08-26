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
    public class EditPDFImportWizard : DriverTestCase
    {
        [TestMethod]
        public void editPDFImportWizard()
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
            String pdf = "sample" + RandomNumber(1,99) +".pdf";


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
            String filename = GetPathToFile()+"2.PDF";
            pDFImportWizardHelper.upload("SelectFile", filename);

            //Click On Import
            pDFImportWizardHelper.ClickElement("ClickOnImport");
            pDFImportWizardHelper.WaitForWorkAround(10000);

            //Click On Next
            pDFImportWizardHelper.ClickElement("ClickOnNext");

            //verify title
            VerifyTitle("PDF Import Wizard");

            //Select Category
            pDFImportWizardHelper.Select("SelectCategory", "338");

            //Click on Save button
            pDFImportWizardHelper.ClickElement("ClickOnSaveBtn");
            
            //wait for text
            pDFImportWizardHelper.WaitForText("PDF Template options saved successfully.", 30);

            //Click On Edit
            pDFImportWizardHelper.ClickElement("ClickOnEdit");

            //Verify title
            VerifyTitle("Edit PDF Template");

            //Enter Name
            pDFImportWizardHelper.TypeText("EnterName","Test.pdf");

            //Click Edit Save
            pDFImportWizardHelper.ClickElement("ClickEditSave");

            pDFImportWizardHelper.WaitForText("PDF Template Updated Successfully.", 30);

            //Click on Flag To make Inactive
            pDFImportWizardHelper.ClickElement("ClickOnMakeInactiveBtn");
            pDFImportWizardHelper.WaitForWorkAround(6000);



        }
    }
}
