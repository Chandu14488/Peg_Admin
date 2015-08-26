using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class CreateLanguage : DriverTestCase
    {
        [TestMethod]
        public void createLanguage()
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
            var createLanguageHelper = new CreateLanguageHelper(GetWebDriver());

            //Variable
            var mail = "Test" + RandomNumber(1, 99) + "@yopmail.com";
            var numb = "12345678" + RandomNumber(10, 99);
           

            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Redirect To Language
            createLanguageHelper.redirectToPage();

            //Verify title
            VerifyTitle("Languages");

            //Click On Create Btn
            createLanguageHelper.ClickElement("ClickOnCreateBtn");

            //Enter Language Name
            var lang = "AA_Lang" + RandomNumber(99,999);
            createLanguageHelper.WaitForWorkAround(5000);
            createLanguageHelper.TypeText("EnterName", lang);

            //Clcik on Master Data
            createLanguageHelper.ClickElement("ClickSave");

            //Clcik on Edit language
            createLanguageHelper.ClickElement("ClickOnEditLanguage");

            //Enter Language Name
            var Elang = "AAA" + RandomNumber(1,99);
            createLanguageHelper.TypeText("EnterLanguage", Elang);

            //ClickOn Edit Save Button
            createLanguageHelper.ClickElement("ClickOnSaveBtn");

            //Click On Del Lang
            createLanguageHelper.ClickElement("ClickOnDelLang");
        }
    }
}
