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
    public class EditShippingCarriers : DriverTestCase
    {
        [TestMethod]
        public void editShippingCarriers()
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
            EditShippingCarrierHelper editShippingCarrierHelper = new EditShippingCarrierHelper(GetWebDriver());

            //Variable
            String name = "Test" + RandomNumber(1,99);
            String URL = "https://www.Test" + RandomNumber(1, 99) + ".com";

            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Click On  Admin
            editShippingCarrierHelper.RedirectToAdmin();

//##################  Redirect To Url

            //Redirect To URL
            editShippingCarrierHelper.RedirectToPage();

            //Verify title
            VerifyTitle("Shipping Carriers");

            // Click On Create
            editShippingCarrierHelper.ClickElement("ClickOnCreate");

            //Verify title
            VerifyTitle("Manage Shipping Carrier");

            //Enter Name
            editShippingCarrierHelper.TypeText("ShippingCarrierName", name);

            //Enter Type
            editShippingCarrierHelper.TypeText("Website", "http://www.test.com");

            //Enter EquipmentId
            editShippingCarrierHelper.TypeText("TrackingURL", URL);

//######################## CLICK ON SAVE BUTTON  ########################################
            // Click on Save button   
            editShippingCarrierHelper.ClickElement("SaveBtn");
            
            //wait for text
            editShippingCarrierHelper.WaitForText("The shipping carrier is successfully created", 30);

            //Redirect To URL
           editShippingCarrierHelper.RedirectToPage();

            //Verify title
           VerifyTitle("Shipping Carriers");

            //Enter Shipping Carrier name  in  search field
            editShippingCarrierHelper.TypeText("EnterToSearch", name);
            editShippingCarrierHelper.WaitForWorkAround(4000);

            //Click on Edit 
            editShippingCarrierHelper.ClickElement("ClickOnEditLink");
            
            //Verify title
            VerifyTitle("Manage Shipping Carrier");

            //Enter Name
            editShippingCarrierHelper.TypeText("ShippingCarrierName", name+"1");

            //Enter Type
            editShippingCarrierHelper.TypeText("Website", "http://www.test.com");

            //Enter EquipmentId
            editShippingCarrierHelper.TypeText("TrackingURL", URL);

            // Click on Save button   
            editShippingCarrierHelper.ClickElement("SaveBtn");
            
            //Vwait for text
            editShippingCarrierHelper.WaitForText("The shipping carrier is successfully updated", 30);



        }
    }
}
