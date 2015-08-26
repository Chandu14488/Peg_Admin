﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public class EditProductCategories : DriverTestCase
    {
        [TestMethod]
        public void editProductCategories()
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
            CreateProductsCategoryHelper createProductsCategoryHelper = new CreateProductsCategoryHelper(GetWebDriver());


            //Variable 
            String name = "Test" + RandomNumber(99, 999);

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
            createProductsCategoryHelper.WaitForWorkAround(3000);

        }
    }
}
