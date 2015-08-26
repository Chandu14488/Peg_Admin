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
    public class EditEquipment : DriverTestCase
    {
        [TestMethod]
        public void editEquipment()
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
            EditEquipmentAdminHelper editEquipmentAdminHelper = new EditEquipmentAdminHelper(GetWebDriver());

            //Variable 
            String  name = "Test" + RandomNumber(1,99);
            String Id = "12345" + RandomNumber(1,99);


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Click On  Admin
            editEquipmentAdminHelper.RedirectToAdmin();

            //Redirect To URL
            editEquipmentAdminHelper.RedirectToPage();

            //Verify title
            VerifyTitle("Equipment");

//#### Create Equipments

            // Click On Create
            editEquipmentAdminHelper.ClickElement("ClickOnCreate");
            
            //Verify title
            VerifyTitle("Equipment Create");

            //Enter Equipment Name
            editEquipmentAdminHelper.TypeText("EqpName", name);

            //Enter DownloadsIDName
            editEquipmentAdminHelper.Select("Type", "Check Reader");

            //Enter Equipment Id
            editEquipmentAdminHelper.TypeText("EquipmentId", Id);

            //Enter Version
            editEquipmentAdminHelper.TypeText("Version", "Testing");

            //Enter Description
            editEquipmentAdminHelper.TypeText("Description", "This is Testing Description");

            //Click On First CheckBox
            editEquipmentAdminHelper.ClickElement("ClickOnFirstCheckBox");

            //Click On Second CheckBox
            editEquipmentAdminHelper.ClickElement("ClickOn2CheckBox");

//######################## CLICK ON SAVE BUTTON  ########################################
            // Click on Save button   
            editEquipmentAdminHelper.ClickElement("SaveBtn");

            //Wait for text
            editEquipmentAdminHelper.WaitForText("Equipment saved successfully", 30);
            
            //Verify title
            VerifyTitle("Equipment");

//###########################    EDIT   ######################################


            //Enter Name in seacrh field
            editEquipmentAdminHelper.TypeText("EnterNameInSearch", name);

            //Clik To EditEquipment
            editEquipmentAdminHelper.ClickElement("ClikToEditEquipment");

            //Verify title
            VerifyTitle("Equipment Edit: ");

            //Enter Equipment Name
            editEquipmentAdminHelper.TypeText("EqpName", name);

            //Enter DownloadsIDName
            editEquipmentAdminHelper.Select("Type", "Check Reader");

            //Enter Equipment Id
            editEquipmentAdminHelper.TypeText("EquipmentId", Id);

            //Enter Version
            editEquipmentAdminHelper.TypeText("Version", "Testing");

            //Enter Description
            editEquipmentAdminHelper.TypeText("Description", "This is Testing Description");

            // Click on Save button   
            editEquipmentAdminHelper.ClickElement("SaveBtn");

            editEquipmentAdminHelper.WaitForText("Equipment saved successfully", 30);




        }
    }
}
