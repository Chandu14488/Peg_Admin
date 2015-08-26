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
    public class CreateEquipments : DriverTestCase
    {
        [TestMethod]
        public void createEquipments()
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
            CreateEquipmentAdminHelper createEquipmentAdminHelper = new CreateEquipmentAdminHelper(GetWebDriver());

            //Variable 
            String  name = "Test" + RandomNumber(1,99);
            String Id = "12345" + RandomNumber(1, 99);


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Click On  Admin
            createEquipmentAdminHelper.RedirectToAdmin();

//##################  Redirect To Url

            //Redirect To URL
            createEquipmentAdminHelper.RedirectToPage();

            //Verify title
            VerifyTitle("Equipment");

//################################# Create Equipments #############################################

            // Click On Create
            createEquipmentAdminHelper.ClickElement("ClickOnCreate");
            
            //Verify title
            VerifyTitle("Equipment Create");

            //Enter Equipment Name
            createEquipmentAdminHelper.TypeText("EqpName", name);

            //Enter DownloadsIDName
            createEquipmentAdminHelper.Select("Type", "Check Reader");

            //Enter Equipment Id
            createEquipmentAdminHelper.TypeText("EquipmentId", Id);

            //Enter Version
            createEquipmentAdminHelper.TypeText("Version", "Testing");

            //Enter Description
            createEquipmentAdminHelper.TypeText("Description", "This is Testing Description");

            //Click On First CheckBox
            createEquipmentAdminHelper.ClickElement("ClickOnFirstCheckBox");

            //Click On First CheckBox
            createEquipmentAdminHelper.ClickElement("ClickOn2CheckBox");

            //######################## CLICK ON SAVE BUTTON  ########################################
            // Click on Save button   
            createEquipmentAdminHelper.ClickElement("SaveBtn");

            createEquipmentAdminHelper.WaitForText("Equipment saved successfully", 30);

        }
    }
}
