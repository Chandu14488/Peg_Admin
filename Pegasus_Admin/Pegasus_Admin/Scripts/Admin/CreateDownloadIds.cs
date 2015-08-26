using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.Admin
{
    [TestClass]
    public class CreateDownloadIds : DriverTestCase
    {
        [TestMethod]
        public void createDownloadIds()
        {
            string[] username = null;
            string[] password = null;

            var oXMLData = new XMLParse();
            oXMLData.LoadXML("../../Config/ApplicationSettings.xml");

            username = oXMLData.getData("settings/Credentials", "username");
            password = oXMLData.getData("settings/Credentials", "password");

            //Initializing the objects
            var loginHelper = new LoginHelper(GetWebDriver());
            var clientHelper = new ClientsHelper(GetWebDriver());
            var createDownloadIdsHelper = new CreateDownloadIdsHelper(GetWebDriver());

            //Variable 
            var name = "Test" + RandomNumber(1, 99);
            var Id = "12345" + RandomNumber(1, 99);


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Click On  Admin
            createDownloadIdsHelper.RedirectToAdmin();

            //Redirect To URL
            createDownloadIdsHelper.RedirectToPage();

            //Verify title
            VerifyTitle("Download IDs");

            // Click On Create
            createDownloadIdsHelper.ClickElement("ClickOnCreate");

            //Verify title
            VerifyTitle("Manage Master Equipment Type Download Ids");

            //Enter DownloadIdsType
            createDownloadIdsHelper.Select("DownloadIdsType", "Terminal");

            //Enter DownloadsIDName
            createDownloadIdsHelper.TypeText("DownloadsIDName", "name");

            //Enter DownloadsIDName
            createDownloadIdsHelper.TypeText("DownloadID", "Id");

            //Enter Category
            createDownloadIdsHelper.Select("Status", "0");

            //######################## CLICK ON SAVE BUTTON  ########################################
            // Click on Save button   
            createDownloadIdsHelper.ClickElement("SaveBtn");
            
            //Wait for text
            createDownloadIdsHelper.WaitForText("The download id is successfully created!!", 30);
        }
    }
}
