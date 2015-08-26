using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.Admin
{
    [TestClass]
    public class DeleteVendor : DriverTestCase
    {
        [TestMethod]
        public void deleteVendor()
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
            var createVendorHelper = new CreateVendorHelper(GetWebDriver());


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");


            //Click On  Admin
            createVendorHelper.RedirectToAdmin();

            //##################  Redirect To Url

            //Redirect To URL
            createVendorHelper.RedirectToPage();

            //Verify title
            VerifyTitle("Vendors");

//################################# Create Vendor #############################################

            // Click On Create
            createVendorHelper.ClickElement("ClickOnCreate");

            //Verify title
            VerifyTitle("Create a New Vendor");

            //Enter Name
            createVendorHelper.Select("Type", "Test");

            //Enter Type
            createVendorHelper.TypeText("Name", "Delete Vendor");

            //Enter EquipmentId
            createVendorHelper.TypeText("DBAName", "Test123");

            //LinkedURL
            createVendorHelper.Select("Salutation", "Mr");

            //LinkedURL
            createVendorHelper.TypeText("FirstName", "Delete");

            //LinkedURL
            createVendorHelper.TypeText("LastName", "Vendor");

            //LinkedURL
            createVendorHelper.Select("eAddessType", "E-Mail");

            //EAddress Label
            createVendorHelper.Select("EAddressLabel", "Work");

            //E Address
            createVendorHelper.TypeText("eAddress", "Test@yopmail.com");


            //Phone Type
            createVendorHelper.Select("PhoneType", "Work");

            //Enter Zip Code
            createVendorHelper.TypeText("ZipCodeVendor", "60601");

            // Click on Save button   
            createVendorHelper.ClickElement("SaveBtn");

            //Verify title
            VerifyTitle("Vendors");

            //EnterVendorName
            createVendorHelper.TypeText("EnterVendorName", "Delete Vendor");

            //Search Last Name
            createVendorHelper.TypeText("SearchLastName", "Vendor");
            createVendorHelper.WaitForWorkAround(3000);

            //Click on 
            createVendorHelper.ClickElement("ClickOnDelete");
            createVendorHelper.AcceptAlert();
            createVendorHelper.WaitForWorkAround(2000);
            createVendorHelper.WaitForText("Vendor Deleted Successfully",30);



        }
    }
}