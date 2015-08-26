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
    public class DevelopProductsListing : DriverTestCase
    {
        [TestMethod]
        public void developProductsListing()
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

//################################# Create Product #############################################

            //Go to create page
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/products/create");

            //Wait for text
            addDocumentAdminHelper.WaitForText("Custom Fields", 50);

            //Enter Product Name
            addDocumentAdminHelper.TypeText("ProName", Proname);

            //Select Product Category
            addDocumentAdminHelper.SelectByText("ProCate", "Test Delete");

            //Select Product View
            addDocumentAdminHelper.SelectByText("ProView", "Expanded");

            //Select Product Status
            addDocumentAdminHelper.SelectByText("ProStatus", "Active");

            //Click on Save button
            addDocumentAdminHelper.ClickElement("ProSave");

            //Wait for text
            addDocumentAdminHelper.WaitForText("Bulk Update", 50);

//################################# Quick filter #############################################

            //Filter By name
            addDocumentAdminHelper.TypeText("SearchName", Proname);

            //Verify result
            addDocumentAdminHelper.WaitForText(Proname, 50);

            //Filter By Category
            addDocumentAdminHelper.TypeText("SearchCate", "Category 1");
            
            //Verify result
            addDocumentAdminHelper.WaitForText(Proname, 50);

            //Filter By View
            addDocumentAdminHelper.SelectByText("SearchView", "Expand");

            //Verify result
            addDocumentAdminHelper.WaitForText(Proname, 50);

            //Filter By status
            addDocumentAdminHelper.SelectByText("SearchStatus", "Active");

            //Verify result
            addDocumentAdminHelper.WaitForText(Proname, 50);

//################################# Bulk Update Status #############################################
            //Select all
            addDocumentAdminHelper.ClickElement("CheckAll");

            //Click on 'Bulk update'
            addDocumentAdminHelper.ClickElement("BulkUpdate");

            //Click on Status
            addDocumentAdminHelper.ClickElement("BulkStatus");

            //Wait For text
            addDocumentAdminHelper.WaitForText("Update", 50);

            //Select Status
            addDocumentAdminHelper.SelectByText("SelectStatus", "Active");

            //Click on update
            addDocumentAdminHelper.ClickElement("UpdateStatus");

            //Accept
            addDocumentAdminHelper.AcceptAlert();

            //Verify updated successfully
            addDocumentAdminHelper.verifyUpdate("Active");
            /*
//################################# Bulk Update Category #############################################
            //Select all
            addDocumentAdminHelper.ClickElement("CheckAll");

            //Click on 'Bulk update'
            addDocumentAdminHelper.ClickElement("BulkUpdate");

            //Click on Category
            addDocumentAdminHelper.ClickElement("BulkCate");

            //Wait For text
            addDocumentAdminHelper.WaitForText("Update", 50);

            //Select Status
            addDocumentAdminHelper.SelectByText("SelectCategory", "Test166");

            //Click on update
            addDocumentAdminHelper.ClickElement("UpdateCate");

            //Accept
            addDocumentAdminHelper.AcceptAlert();

            //Verify updated successfully
            addDocumentAdminHelper.WaitForText("Test166",30);
*/
//################################# Copy #############################################

            //Click on created product
            addDocumentAdminHelper.ClickOnProduct(Proname);

            //Wait for text
            addDocumentAdminHelper.WaitForText("/ Edit - "+Proname, 50);

            //Click on Clone
            addDocumentAdminHelper.ClickElement("Clone");

            //Accept allert
            addDocumentAdminHelper.AcceptAlert();

            //wait for text
            addDocumentAdminHelper.WaitForText("The Product is cloned successfully", 50);

            //Click on Save
            addDocumentAdminHelper.ClickElement("ProSave");

            //Wait for text
            addDocumentAdminHelper.WaitForText("Bulk Update", 50);

            //Verify Cloned
            addDocumentAdminHelper.verifyCloned(Proname);

//################################# Delete #############################################

            //Filter By name
            addDocumentAdminHelper.TypeText("SearchName", Proname);

            //Verify result
            addDocumentAdminHelper.WaitForText(Proname, 50);

            Thread.Sleep(2000);

            //Click on delete
            addDocumentAdminHelper.ClickElement("Delete");

            //Accept alert
            addDocumentAdminHelper.AcceptAlert();

            //Filter By name
            addDocumentAdminHelper.TypeText("SearchName", Proname);

            //Verify result
            addDocumentAdminHelper.WaitForText(Proname, 50);

            Thread.Sleep(2000);

            //Click on delete
            addDocumentAdminHelper.ClickElement("Delete");

            //Accept alert
            addDocumentAdminHelper.AcceptAlert();

            //Verify deleted succefully
            addDocumentAdminHelper.VerifyTextNotPresent(Proname);

        }
    }
}
