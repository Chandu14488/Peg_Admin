using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.Admin
{
    [TestClass]
    public class CreateProducts : DriverTestCase
    {
        [TestMethod]
        public void createProducts()
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
            var createProductsHelperAdmin = new CreateProductsHelperAdmin(GetWebDriver());

            //Variable
            var name = "Test" + RandomNumber(1, 99);


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Click On  Admin
            createProductsHelperAdmin.RedirectToAdmin();

            //Redirect To URL
            createProductsHelperAdmin.RedirectToPage();

            //Verify title
            VerifyTitle("Products");

//################################# Create Product tab #############################################

            // Click On Create
            createProductsHelperAdmin.ClickElement("ClickOnCreate");

            //verify title
            VerifyTitle("Products");

            //Enter Name
            createProductsHelperAdmin.TypeText("Name", name);

            // Click On Create
            createProductsHelperAdmin.ClickElement("ClickOnAddCustomFiled");
            createProductsHelperAdmin.WaitForWorkAround(3000);

            //Enter Filed name
            createProductsHelperAdmin.TypeText("FieldName", "Test");

            //Select Type
            createProductsHelperAdmin.Select("TypeCustom", "textbox");

            //Select Type
            createProductsHelperAdmin.Select("ContentTypeCustom", "text");

            //Select Data Validation
            createProductsHelperAdmin.Select("SelectValidation", "email");

            //Click on Required CheckBox
            createProductsHelperAdmin.ClickElement("Required");
            createProductsHelperAdmin.WaitForWorkAround(2000);

            //Enter Data Length
//            createProductsHelperAdmin.TypeText("DataLength", "5455");

            //Enter Description
            createProductsHelperAdmin.TypeText("Description", "THIS IS TESTING DESCRIPTION");

            //  Click on Save button
            createProductsHelperAdmin.ClickElement("SaveBtn");
            createProductsHelperAdmin.WaitForWorkAround(3000);

            //Save Create
            createProductsHelperAdmin.ClickElement("Save");
            createProductsHelperAdmin.WaitForWorkAround(3000);
        }
    }
}