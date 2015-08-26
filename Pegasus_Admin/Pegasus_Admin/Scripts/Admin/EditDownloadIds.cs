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
    public class EditDownloadIds : DriverTestCase
    {
        [TestMethod]
        public void editDownloadIds()
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
            EditDownloadIdsHelper editDownloadIdsHelper = new EditDownloadIdsHelper(GetWebDriver());

            //Variable 
            String  name = "Test" + RandomNumber(1,99);
            String id = "4" + RandomNumber(1,99);


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Click On  Admin
            editDownloadIdsHelper.RedirectToAdmin();

//##################  Redirect To Url

            //Redirect To URL
            editDownloadIdsHelper.RedirectToPage();

            //Verify title
            VerifyTitle("Download IDs");

//################################# Create Equipments #############################################

            // Click On Create
            editDownloadIdsHelper.ClickElement("ClickOnCreate");

            //Verify title
            VerifyTitle("Manage Master Equipment Type Download Ids");

            //Enter DownloadIdsType
            editDownloadIdsHelper.Select("DownloadIdsType", "Terminal");

            //Enter DownloadsIDName
            editDownloadIdsHelper.TypeText("DownloadsIDName", name);

            //Enter DownloadsIDName
            editDownloadIdsHelper.TypeText("DownloadID", id);


            //Enter Category
            editDownloadIdsHelper.Select("Status", "0");

            //######################## CLICK ON SAVE BUTTON  ########################################
            // Click on Save button   
            editDownloadIdsHelper.ClickElement("SaveBtn");

            editDownloadIdsHelper.WaitForText("The download id is successfully created!!", 30);

            //Verify title
            VerifyTitle("Download IDs");

            //############  EDIT

            //Enter Id to search
            editDownloadIdsHelper.TypeText("EnterDownloadIds", id);

            //Click on Edit button
            editDownloadIdsHelper.ClickElement("ClickOnEditIcn");

            //Verify title
            VerifyTitle("Manage Master Equipment Type Download Ids");

            //Enter DownloadIdsType
            editDownloadIdsHelper.Select("DownloadIdsType", "Terminal");

            //Enter DownloadsIDName
            editDownloadIdsHelper.TypeText("DownloadsIDName", name+"1");

            //Enter DownloadsIDName
            editDownloadIdsHelper.TypeText("DownloadID", id);

            //Enter Category
            editDownloadIdsHelper.Select("Status", "0");

            // Click on Save button   
            editDownloadIdsHelper.ClickElement("SaveBtn");
            
            //Wait for text
            editDownloadIdsHelper.WaitForText("The download id is successfully updated!!", 30);

        }
    }
}
