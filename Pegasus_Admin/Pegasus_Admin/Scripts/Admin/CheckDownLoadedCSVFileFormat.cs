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
    public class CheckDownLoadedFileFormat : DriverTestCase
    {
       // [TestMethod]
        public void checkDownLoadedFileFormat()
        {
            string[] username = null;
            string[] password = null;

            XMLParse oXMLData = new XMLParse();
            oXMLData.LoadXML("../../Config/ApplicationSettings.xml");

            username = oXMLData.getData("settings/Credentials", "username");
            password = oXMLData.getData("settings/Credentials", "password");

            //Initializing the objects
            LoginHelper loginHelper = new LoginHelper(GetWebDriver());
            AddDocumentAdminHelper addDocumentAdminHelper = new AddDocumentAdminHelper(GetWebDriver());

            // Variable
            var Proname = "Product" + RandomNumber(100, 999);


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Click On  Admin
            addDocumentAdminHelper.RedirectToAdmin();

           //Redirect to client page
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/clients");

            //Verify Title
            VerifyTitle("Clients");

            //Export as CSV
            addDocumentAdminHelper.ExportAs("CSV");

            var user = addDocumentAdminHelper.CurrentUser();

            //Get newly created file name from downloads folder
            var newfilename = addDocumentAdminHelper.Getnewfilename(new DirectoryInfo(@"C:\" + user + @"s\" + user + @"\Downloads\"));

            var filepath = @"C:\" + user + @"s\" + user + @"\Downloads\" + newfilename.ToString();

            //Verify downloaded file extention
            addDocumentAdminHelper.verifyDownloadedExtention("csv", filepath);

            //Export as Excel
            addDocumentAdminHelper.ExportAs("Excel");

            //Get newly created file name from downloads folder
            newfilename = addDocumentAdminHelper.Getnewfilename(new DirectoryInfo(@"C:\" + user + @"s\" + user + @"\Downloads\"));

            filepath = @"C:\" + user + @"s\" + user + @"\Downloads\" + newfilename.ToString();

            //Verify downloaded file extention
            addDocumentAdminHelper.verifyDownloadedExtention("xls", filepath);


        }
    }
}
