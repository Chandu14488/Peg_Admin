using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.Admin
{
    [TestClass]
    public class CreateProductCategory : DriverTestCase
    {
        [TestMethod]
        public void createProductCategory()
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
            var createProductsCategoryHelper = new CreateProductsCategoryHelper(GetWebDriver());


            //Variable 
            var name = "Test" + RandomNumber(99, 999);

            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Click On  Admin
            createProductsCategoryHelper.RedirectToAdmin();

            //Redirect To URL
            createProductsCategoryHelper.RedirectToPage();

            //Verify title
            VerifyTitle("Product Categories");

//################################# Create Equipments #############################################

            // Click On Create
            createProductsCategoryHelper.ClickElement("ClickOnCreate");

            createProductsCategoryHelper.WaitForWorkAround(3000);

            //Enter Name
            createProductsCategoryHelper.TypeText("Name", name);

//######################## CLICK ON SAVE BUTTON  ########################################
            // Click on Save button   
            createProductsCategoryHelper.ClickElement("SaveBtn");

            //wait for text
            createProductsCategoryHelper.WaitForText("Category Created Successfully", 30);

            //Search and click 
            createProductsCategoryHelper.SearchAnclick(name);

        }
    }
}