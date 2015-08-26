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
    public class EditProducts : DriverTestCase
    {
        [TestMethod]
        public void editProducts()
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
            EditProductsHelperAdmin editProductsHelperAdmin = new EditProductsHelperAdmin(GetWebDriver());

            //Variable
            String name = "Test" + RandomNumber(1, 99);


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Click On  Admin
            editProductsHelperAdmin.RedirectToAdmin();

            //Redirect To URL
            editProductsHelperAdmin.RedirectToPage();

            //Verify title
            VerifyTitle("Products");

//################################# Create Product tab #############################################

            // Click On Create
            editProductsHelperAdmin.ClickElement("ClickOnCreate");

            //Verify title
            VerifyTitle("Products");

            //Enter Name
            editProductsHelperAdmin.TypeText("Name", name);

            //  Click on Save button
                editProductsHelperAdmin.ClickElement("SaveBtn");
              
            //Wait for text
                editProductsHelperAdmin.WaitForText("Product Created Successfully", 30);

            //Verify title
                VerifyTitle("Products");

            //Enter name
                editProductsHelperAdmin.TypeText("EnterToSearchName", name);
                editProductsHelperAdmin.WaitForWorkAround(4000);
            
            //Click on Edit
                editProductsHelperAdmin.ClickElement("ClickOnToEdit");

            //Verify title
                VerifyTitle("Products");

                //Enter Name
                editProductsHelperAdmin.TypeText("Name", name+"1");
            
                
                //Save Create
                editProductsHelperAdmin.ClickElement("SaveBtn");
                editProductsHelperAdmin.WaitForWorkAround(3000);



          

        }
    }
}
