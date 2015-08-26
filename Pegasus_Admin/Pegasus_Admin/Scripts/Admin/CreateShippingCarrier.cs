using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.Admin
{
    [TestClass]
    public class CreateShippingCarrier : DriverTestCase
    {
        [TestMethod]
        public void createShippingCarrier()
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
            var createShippingCarrierHelper = new CreateShippingCarrierHelper(GetWebDriver());

            //Variable
            var name = "Test" + RandomNumber(1, 99);
            var URL = "http://www.Test" + RandomNumber(1, 99) + ".com";

            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Click On  Admin
            createShippingCarrierHelper.RedirectToAdmin();

            //Redirect To URL
            createShippingCarrierHelper.RedirectToPage();

            //Verify title
            VerifyTitle("Shipping Carriers");

//################################# Create Equipments #############################################

            // Click On Create
            createShippingCarrierHelper.ClickElement("ClickOnCreate");

            //Verify titlr
            VerifyTitle("Manage Shipping Carrier");
            
            //Enter Name
            createShippingCarrierHelper.TypeText("ShippingCarrierName", name);

            //Enter Type
            createShippingCarrierHelper.TypeText("Website", "http://www.Test.com");

            //Enter EquipmentId
            createShippingCarrierHelper.TypeText("TrackingURL", URL);

//######################## CLICK ON SAVE BUTTON  ########################################
            // Click on Save button   
            createShippingCarrierHelper.ClickElement("SaveBtn");
            
            //Wait for text
            createShippingCarrierHelper.WaitForText("The shipping carrier is successfully created",30);

        }
    }
}
