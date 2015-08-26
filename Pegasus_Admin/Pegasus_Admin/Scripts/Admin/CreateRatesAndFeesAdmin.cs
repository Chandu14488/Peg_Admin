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
    public class CreateRatesAndFeesAdmin : DriverTestCase
    {
        [TestMethod]
        public void createRatesAndFeesAdmin()
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
            CreateRatesAndFeesAdminHelper createRatesAndFeesAdminHelper = new CreateRatesAndFeesAdminHelper(GetWebDriver());

            //Variable
            String name = "TEST COMPANY" + RandomNumber(1,99);
            String FirstName = "Test" + RandomNumber(1,99);
            String LastName = "Tester" + RandomNumber(1,99);
            String Number = "12345678" + RandomNumber(10, 99);

            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Click On  Admin
            createRatesAndFeesAdminHelper.RedirectToAdmin();

            //Redirect To URL
            createRatesAndFeesAdminHelper.RedirectToPage();
            

            //Verify titke
            VerifyTitle("Manage Master Rates & Fees");


//################################# CREATE A LEAD   #############################################

            //Enter company name
            createRatesAndFeesAdminHelper.TypeText("PricingTemplateName", "TEST");

            //Select Processor
            createRatesAndFeesAdminHelper.Selectbytext("Processor", "Chy Processor");
           // Thread.Sleep(5000);


            //Select Merchant Type
            createRatesAndFeesAdminHelper.Selectbytext("SelectMerchanType", "test");


            //Enter MCC/SIC Code
          //  createRatesAndFeesAdminHelper.TypeText("EnterMCCSICcODE", "TEST");

            //Method of accepting card
            createRatesAndFeesAdminHelper.Selectbytext("MethodOfAcceptingCards", "Ecommerce");

            //Select Discount Frequency 
            createRatesAndFeesAdminHelper.Select("DiscountFrequency", "Monthly");

            //Method of pricing plan
    //        createRatesAndFeesAdminHelper.Select("PricePlan", "10,000");

         


           //Select Debit Network InterFace Pass Through
//            createRatesAndFeesAdminHelper.Select("DebitNetworkInterFacePassThrough", "Yes");
  //          createRatesAndFeesAdminHelper.WaitForWorkAround(3000);

            //Enter Vica Credit Oualified Percentage
            createRatesAndFeesAdminHelper.TypeText("VicaCreditOualifiedPercentage", "30");

            //Enter Vica Credit Mid Qualified
            createRatesAndFeesAdminHelper.TypeText("VicaCreditMidQualified", "30");

            //Enter Vica Credit Authorization Fees
            createRatesAndFeesAdminHelper.TypeText("VicaCreditAuthorizationFees", "30");

            //Enter Vica Check Card Qualified
            createRatesAndFeesAdminHelper.TypeText("VicaCheckCardQualified", "30");

            //Enter Vica CheckCard Mid Qualified
            createRatesAndFeesAdminHelper.TypeText("VicaCheckCardMidQualified", "30");

            //Enter Vica CheckCard Non Qualified
            createRatesAndFeesAdminHelper.TypeText("VicaCheckCardNonQualified", "30");


            //Enter Vica Check Card Per Item
            createRatesAndFeesAdminHelper.TypeText("VicaCheckCardPerIthem", "30");


            //Enter Vica Check Card Mid Qual Per Item
            createRatesAndFeesAdminHelper.TypeText("VicaCheckCardMidQualPerItem", "30");


            //Enter Vice Check Card Non Qual Per item
            createRatesAndFeesAdminHelper.TypeText("ViceCheckCardNonQualPeritem", "30");


            //Enter Authentication Fees
            createRatesAndFeesAdminHelper.TypeText("AuthenticationFees", "30");


            //Enter Master Card Credit Qualified
            createRatesAndFeesAdminHelper.TypeText("MasterCardCreditQualified", "30");


            //Enter Master Card Credit Non Qualified
            createRatesAndFeesAdminHelper.TypeText("MasterCardCreditNonQualified", "30");

            //Enter Master Card Credit PerItem
            createRatesAndFeesAdminHelper.TypeText("MasterCardCreditPerItem", "30");


            //Enter Master Credit Card MidQual PerItem
            createRatesAndFeesAdminHelper.TypeText("MasterCreditCardMidQualPerItem", "30");


            //Enter Master Credit Card Non Qual Per Item
            createRatesAndFeesAdminHelper.TypeText("MasterCreditCardNonQualPerItem", "30");

            //Enter Master Credit Card Authentication fee
            createRatesAndFeesAdminHelper.TypeText("MasterCreditCardAuthenticationfee", "30");

            // ############################     MASTER DEBIT CARD   ###########################################

            //Enter Master Card Debit Qualified
            createRatesAndFeesAdminHelper.TypeText("MasterCardDebitQualified", "30");


            //Enter Master Credit Card Mid Qualified
            createRatesAndFeesAdminHelper.TypeText("MasterCreditCardMidQualified", "30");

            //Enter Master Debit Card Non Qualified
            createRatesAndFeesAdminHelper.TypeText("MasterDebitCardNonQualified", "30");


            //Enter Master Debit Card perItem
            createRatesAndFeesAdminHelper.TypeText("MasterDebitCardperItem", "30");


            //Enter Master Debit Card MidQual
            createRatesAndFeesAdminHelper.TypeText("MasterDebitCardMidQual", "30");

            //Enter Master Debit Card Non Qual PerItem
            createRatesAndFeesAdminHelper.TypeText("MasterDebitCardNonQualPerItem", "30");


            //Enter Master Debit Card Authorization Fees
            createRatesAndFeesAdminHelper.TypeText("MasterDebitCardAuthorizationFees", "30");


            // ############################     Discover Network Credit  ###########################################

            //Enter Discover NetworK Credit Qualified
            createRatesAndFeesAdminHelper.TypeText("DiscoverNetworCreditQualified", "30");


            //Enter Discover Mid Qualified
            createRatesAndFeesAdminHelper.TypeText("DiscoverMidQualified", "30");

            //Enter Discover Network Credit NonQualified
            createRatesAndFeesAdminHelper.TypeText("DiscoverNetworkCreditNonQualified", "30");


            //Enter Discover Network Credit PerItem
            createRatesAndFeesAdminHelper.TypeText("DiscoverNetworkCreditPerItem", "30");


            //Enter Discover Network Credit Mid Qualified
            createRatesAndFeesAdminHelper.TypeText("DiscoverNetworkCreditMidQualified", "30");

            //Enter Discover Network Credit Non Qualified
            createRatesAndFeesAdminHelper.TypeText("DiscoverNetworkCreditNonQualified", "30");


            //Enter Discover Network credit Authentication
            createRatesAndFeesAdminHelper.TypeText("DiscoverNetworkcreditAuthentication", "30");


            // ############################     Discover Network Debit   ###########################################

            //Enter Discover Network Debit Qualified
            createRatesAndFeesAdminHelper.TypeText("DiscoverNetworkDebitQualified", "30");


            //Enter Discover Network Debit Mid Qualified
            createRatesAndFeesAdminHelper.TypeText("DiscoverNetworkDebitMidQualified", "30");

            //Enter Discover Network Debit Non Qualified
            createRatesAndFeesAdminHelper.TypeText("DiscoverNetworkDebitNonQualified", "30");


            //Enter Discover Network Debit PerItem
            createRatesAndFeesAdminHelper.TypeText("DiscoverNetworkDebitPerItem", "30");


            //Enter Discover Network Debit Mid QualPerItem
            createRatesAndFeesAdminHelper.TypeText("DiscoverNetworkDebitMidQualPerItem", "30");

            //Enter Discover Network Debit Non QualPerItem
            createRatesAndFeesAdminHelper.TypeText("DiscoverNetworkDebitNonQualPerItem", "30");


            //Enter Discover Network Debit Authentication
            createRatesAndFeesAdminHelper.TypeText("DiscoverNetworkDebitAuthentication", "30");


            // ############################     American Express   ###########################################

            //Enter American Express Qualified
            createRatesAndFeesAdminHelper.TypeText("AmericanExpressQualified", "30");


            //Enter American Express Mid Qualified 
            createRatesAndFeesAdminHelper.TypeText("AmericanExpressMidQualified", "30");

            //Enter American Express Debit Non Qualified
            createRatesAndFeesAdminHelper.TypeText("AmericanExpressDebitNonQualified", "30");


            //Enter American Express Debit PerItem
            createRatesAndFeesAdminHelper.TypeText("AmericanExpressDebitPerItem", "30");


            //Enter American Express Debit Mid QualPerItem
            createRatesAndFeesAdminHelper.TypeText("AmericanExpressDebitMidQualPerItem", "30");

            //Enter American Express Debit Non Qual PerItem
            createRatesAndFeesAdminHelper.TypeText("AmericanExpressDebitNonQualPerItem", "30");


            //Enter American Express Debit Authentication
            createRatesAndFeesAdminHelper.TypeText("AmericanExpressDebitAuthentication", "30");


            //#######################################  AMEX Prepaid   ################################################

            //Enter AMEX Prepaid Qualified
            createRatesAndFeesAdminHelper.TypeText("AMEXPrepaidQualified", "50");


            //Enter American Express Debit Authentication
            createRatesAndFeesAdminHelper.TypeText("AMEXPrepaidMidQualified", "50");


            //##########################################  Amex Monthly Flat Fee   ##############################################

            //Select Amex Monthly Flat Fee
            createRatesAndFeesAdminHelper.Select("AmexMonthlyFlatFee", "Yes");

            //########################################## Visa Regualted Debit  #####################################################3

            //Enter Visa Regualted Debit
            createRatesAndFeesAdminHelper.TypeText("VisaRegulatedDebit", "20");


            //Enter Visa Regualted Debit
            createRatesAndFeesAdminHelper.TypeText("VisaRegulatedDebitPerItem", "20");


            //################################ MasterCard Regulated Debit   #######################################################

            //Enter MasterCard Regulated Debit Qualified
            createRatesAndFeesAdminHelper.TypeText("VisaRegulatedDebit", "20");


            //Enter MasterCard Regulated Debit Per Item
            createRatesAndFeesAdminHelper.TypeText("VisaRegulatedDebitPerItem", "20");


            //################################ Discover Network Regulated Debit  #######################################################

            //Enter Discover Network Regulated Debit
            createRatesAndFeesAdminHelper.TypeText("DiscoverNetworkRegualtedDebit", "20");

            //Enter Discover Network Regulated Debit Per Item
            createRatesAndFeesAdminHelper.TypeText("DiscoverNetworkRegulatedDebitPerItem", "20");

            //######################################## Diners Club / Carte Blanche    ###########################################################

            //Enter Diners Club / Carte Blanche
            createRatesAndFeesAdminHelper.TypeText("DinerClubCareteQualified", "20");

            //Enter Diners Club / Carte Blanche Per
            createRatesAndFeesAdminHelper.TypeText("DinerClubQualPer", "20");

            //Enter Diners Club / Carte Blanche
            createRatesAndFeesAdminHelper.TypeText("DinerAuthentication", "20");

            //####################################   Discover   ################################################################

            //Enter Discover
            createRatesAndFeesAdminHelper.TypeText("DiscoverQualifiedQualified", "20");

            //Enter Discover
            createRatesAndFeesAdminHelper.TypeText("DiscoverPerItem", "20");

            //Enter Discover
            createRatesAndFeesAdminHelper.TypeText("DiscoverAuthentictaion", "20");

            //###############################   EBT   ####################################################

            //Enter Discover
            createRatesAndFeesAdminHelper.TypeText("EBTQualified", "20");

            //Enter Discover
            createRatesAndFeesAdminHelper.TypeText("EBTItem", "2000");

            //###############################   EBT CASH BENEFITS  ####################################################

            //Enter EBT Cash Benefit Qualified
            createRatesAndFeesAdminHelper.TypeText("EBTCashBenefitQualified", "20");

            //###############################   Flexcache (Gift Card)   ####################################################

            //Enter Flex Cache Gift Card
            createRatesAndFeesAdminHelper.TypeText("FlexCacheGiftCard", "20");

            //Enter Flex Cache Per Gift Card
            createRatesAndFeesAdminHelper.TypeText("FlexCachePerGiftCard", "20");

            //Enter Flex Cache Authentication GiftCard
            createRatesAndFeesAdminHelper.TypeText("FlexCacheAuthenticationGiftCard", "20");

            // ############################     JCB    ###########################################

            //Enter JCB  Qualified
            createRatesAndFeesAdminHelper.TypeText("JCBQualified", "30");


            //Enter JCB Mid Qualified
            createRatesAndFeesAdminHelper.TypeText("JCBMidQualified", "30");

            //Enter JCB Non Qualified 
            createRatesAndFeesAdminHelper.TypeText("JCBNonQualified", "30");


            //Enter JCB Per Item 
            createRatesAndFeesAdminHelper.TypeText("JCBPerItem", "30");


            //Enter JCB Mid Qual Per Item
            createRatesAndFeesAdminHelper.TypeText("JCBMidQualPerItem", "30");

            //Enter JCB Non Qual PerItem
            createRatesAndFeesAdminHelper.TypeText("JCBNonQualPerItem", "30");


            //Enter JCB Authentication
            createRatesAndFeesAdminHelper.TypeText("JCBAuthentication", "30");


            // ############################     PIN BASED DEBIT    ###########################################

            //Enter PIN BASED DEBIT
            createRatesAndFeesAdminHelper.TypeText("PinBasedDebitQualified", "30");


            //Enter Pin Based Debit Mid Qualified
            createRatesAndFeesAdminHelper.TypeText("PinBasedDebitMidQualified", "30");

            //Enter Pin Based DebitPer Qualified
            createRatesAndFeesAdminHelper.TypeText("PinBasedDebitPerQualified", "30");


            // ############################     Wright Express Fleet Card     ###########################################

            //Enter Wright Express Fleet Card Qualified
            createRatesAndFeesAdminHelper.TypeText("WrightExpressFleetCardQualified", "30");


            //Enter Wright Express Fleet Card Mid Qualified
            createRatesAndFeesAdminHelper.TypeText("WrightExpressFleetCardMidQualified", "30");

            //Enter Wright Express Fleet Card Non Qualified
            createRatesAndFeesAdminHelper.TypeText("WrightExpressFleetCardNonQualified", "30");


            //Enter Wright Express Fleet Card Per Item
            createRatesAndFeesAdminHelper.TypeText("WrightExpressFleetCardPerItem", "30");


            //Enter Wright Express Fleet Card Mid Qual Per Item
            createRatesAndFeesAdminHelper.TypeText("WrightExpressFleetCardMidQualPerItem", "30");

            //Enter JCB Wright Express Fleet Card Non Qual Per Item
            createRatesAndFeesAdminHelper.TypeText("WrightExpressFleetCardNonQualPerItem", "30");


            //Enter Wright Express FleetCard Authentication
            createRatesAndFeesAdminHelper.TypeText("WrightExpressFleetCardAuthentication", "30");



            // ############################    Voyager Fleet Card      ###########################################

            //Enter Voyager Fleet Card Qualified
            createRatesAndFeesAdminHelper.TypeText("VoyagerFleetCardQualified", "30");


            //Enter Voyager Fleet Card Mid Qualified
            createRatesAndFeesAdminHelper.TypeText("VoyagerFleetCardMidQualified", "30");

            //Enter Voyager Fleet Card Non Qualified
            createRatesAndFeesAdminHelper.TypeText("VoyagerFleetCardNonQualified", "30");


            //Enter Voyager Fleet Card Per Item
            createRatesAndFeesAdminHelper.TypeText("VoyagerFleetCardPerItem", "30");


            //Enter Voyager Fleet Card Mid Qual PerItem
            createRatesAndFeesAdminHelper.TypeText("VoyagerFleetCardMidQualPerItem", "30");

            //Enter Voyager Fleet Card Non Qual Per Item
            createRatesAndFeesAdminHelper.TypeText("VoyagerFleetCardNonQualPerItem", "30");


            //Enter Voyager Fleet Card Authentication
            createRatesAndFeesAdminHelper.TypeText("VoyagerFleetCardAuthentication", "30");


            //####################################  BILBACK SUURCHARGE #######################################

            //Enter BillBack Surcharge Qualified
            createRatesAndFeesAdminHelper.TypeText("BillBackSurchargeQualified", "30");

            //################################### Rewards Surcharge (Retail Only)  ############################

            //Enter Rewards Surcharge Retail Qualified
            createRatesAndFeesAdminHelper.TypeText("RewardsSurchargeRetailQualified", "30");

            //Click Rewards Surcharge With Qualified Reward At Pass
            createRatesAndFeesAdminHelper.ClickElement("RewardsSurchargeWithQualifiedRewardAtPass");

            //####################################  MC Worldcard  #######################################

            //Enter Mc World Card Qualified
            createRatesAndFeesAdminHelper.TypeText("McWorldCardQualified", "30");

            //Enter Mc World Card Mid Qualified
            createRatesAndFeesAdminHelper.TypeText("McWorldCardMidQualified", "30");


            //Enter Mc World Card Non Qualified
            createRatesAndFeesAdminHelper.TypeText("McWorldCardNonQualified", "30");


            //Enter Mc World Card Per Item
            createRatesAndFeesAdminHelper.TypeText("McWorldCardPerItem", "30");


            //Enter Mc World Card Mid Qual PerItem
            createRatesAndFeesAdminHelper.TypeText("McWorldCardMidQualPerItem", "30");

            //Enter Mc World Card Qualified
            createRatesAndFeesAdminHelper.TypeText("McWorldCardNonQualPerItem", "30");

            //####################################  Visa Rewards1 #######################################

            //Enter Visa Rewards Qualified
            createRatesAndFeesAdminHelper.TypeText("VisaRewardsQualified", "30");

            //Enter Visa Rewards Mid Qualified
            createRatesAndFeesAdminHelper.TypeText("VisaRewardsMidQualified", "30");

            //#######################################  MC Other Item  ##################################################

            //Enter Mc Other Item qualified
            createRatesAndFeesAdminHelper.TypeText("McOtherItemqualified", "30");

            //#######################################  Visa Other Item  ##################################################

            //Enter Visa Other Item
            createRatesAndFeesAdminHelper.TypeText("VisaOtherItem", "30");

            //#######################################  DiscoverOtherItem #######################################

            //Enter Discover Other Item
            createRatesAndFeesAdminHelper.TypeText("DiscoverOtherItem", "30");

            //################################### JBC OTHER ITEM   #####################################

            //Enter JBC Other Item 
            createRatesAndFeesAdminHelper.TypeText("JBCOtherItem", "30");

            //##################################### AMEX OTHER ITEM   ######################################

            //Enter AMEX Other Item
            createRatesAndFeesAdminHelper.TypeText("AMEXOtherItem", "30");                   
             
            //##################################### PIN Debit-Other Volume Percentage  ###########################

            //Enter PIN Debit-Other Volume Percentage
          //  createRatesAndFeesAdminHelper.ClickElement("DuesAssesmentCheckbox");


            //################################   OTHER SERVICE FEES    #####################################################


            //Click On Click On Expand Button
          //  createRatesAndFeesAdminHelper.ClickElement("ClickOnOtherServiceFeeExpandButton");

            //Enter Account Setup Fee
            createRatesAndFeesAdminHelper.TypeText("AccountSetupFee", "30");

            //Select Account Setup Frequency
            createRatesAndFeesAdminHelper.Select("AccountSetupFrequency", "daily");

            //Enter ACH Return Item Processing
            createRatesAndFeesAdminHelper.TypeText("ACHReturnItemProcessing", "30");

            //Select ACH Return Item Processing Frequency
            createRatesAndFeesAdminHelper.Select("ACHReturnItemProcessingFrequency", "daily");


            //Enter Annual MemberShip
            createRatesAndFeesAdminHelper.TypeText("AnnualMemberShip", "30");

            //Select Annual Member Ship Frequency
            createRatesAndFeesAdminHelper.Select("AnnualMemberShipFrequency", "daily");


            //Enter Annual Fees Collected Month
            createRatesAndFeesAdminHelper.Select("AnnualFeesCollectedMonth", "January");

            //Select Application Processing
            createRatesAndFeesAdminHelper.TypeText("ApplicationProcessing", "30");


            //Enter Application Processing Frquency
            createRatesAndFeesAdminHelper.Select("ApplicationProcessingFrquency", "daily");

            //Select Application Processing
            createRatesAndFeesAdminHelper.TypeText("ApplicationProcessing", "30");


            //Enter Application Processing Frquency
            createRatesAndFeesAdminHelper.Select("ApplicationProcessingFrquency", "daily");


            //Select Batch Settlement
            createRatesAndFeesAdminHelper.TypeText("BatchSettlement", "30");


            //Enter Batch Settlement Frequency
            createRatesAndFeesAdminHelper.Select("BatchSettlementFrequency", "daily");


            //Enter Charge Back Processing
            createRatesAndFeesAdminHelper.TypeText("ChargeBackProcessing", "30");

            //Select ChargeBackFrequency
            createRatesAndFeesAdminHelper.Select("ChargeBackFrequency", "daily");

            //Enter Account Setup Fee
            createRatesAndFeesAdminHelper.TypeText("DebitEBTSetUp", "30");

            //Select Debit EBT Frequency
            createRatesAndFeesAdminHelper.Select("DebitEBTFrequency", "daily");


            //Enter Decisionable Data
            createRatesAndFeesAdminHelper.TypeText("DecisionableData", "30");

            //Select Decisionable Data Frequency
            createRatesAndFeesAdminHelper.Select("DecisionableDataFrequency", "daily");


            //Enter Deposit Confirmation Letter
            createRatesAndFeesAdminHelper.TypeText("DepositConfirmationLetter", "30");

            //Select Deposit Confirmation Freq
            createRatesAndFeesAdminHelper.Select("DepositConfirmationFreq", "daily");


            //Enter Excepetion Item Respond
            createRatesAndFeesAdminHelper.TypeText("ExcepetionItemRespond", "30");

            //Select Excepetion Item Respond Frequency
            createRatesAndFeesAdminHelper.Select("ExcepetionItemRespondFrequency", "daily");

            //Enter Flex Cache Setup
            createRatesAndFeesAdminHelper.TypeText("FlexCacheSetup", "30");

            //Select Flex Cache Setup Frequency
            createRatesAndFeesAdminHelper.Select("FlecCacheSetupFrequency", "daily");


            //Enter Flex Cache Internal Store Settlement
            createRatesAndFeesAdminHelper.TypeText("FlexCacheInternalStoreSettlement", "30");

            //Select Flex Cache Internal Store Settlement Frequency
            createRatesAndFeesAdminHelper.Select("FlexCacheInternalStoreSettlementFrequency", "daily");


            //Enter Monthly Cutomer Service Fees
            createRatesAndFeesAdminHelper.TypeText("MonthlyCutomerServiceFees", "30");

            //Enter E Marchent View Access Fee
            createRatesAndFeesAdminHelper.TypeText("EMarchentViewAccessFee", "30");

            //Enter MonthlySupplies
            createRatesAndFeesAdminHelper.TypeText("MonthlySupplies", "30");

            //Enter Other Monthly Fees
            createRatesAndFeesAdminHelper.TypeText("OtherMonthlyFees", "30");

            //Enter Other Fees
            createRatesAndFeesAdminHelper.TypeText("OtherFees", "30");


            //Enter VisaMisuesFees
            createRatesAndFeesAdminHelper.TypeText("VisaMisuesFees", "30");


            //Enter MCCNPAVSFees
            createRatesAndFeesAdminHelper.TypeText("MCCNPAVSFees", "30");

            //Enter Discover Data Usage
            createRatesAndFeesAdminHelper.TypeText("DiscoverDataUsage", "30");

            //Enter Acquire Processing Fees Debit
            createRatesAndFeesAdminHelper.TypeText("AcquireProcessingFeesDebit", "30");

            //Enter MC License Volume Fee
            createRatesAndFeesAdminHelper.TypeText("MCLicenseVolumeFee", "30");

            //Enter VisaMisuesFees
            createRatesAndFeesAdminHelper.TypeText("VisaPartialAuth", "30");

            //Enter Trans Freedom Montly Fee
            createRatesAndFeesAdminHelper.TypeText("TransFreedomMontlyFee", "30");

            //Enter Monthly Merchant Club Fees
            createRatesAndFeesAdminHelper.TypeText("MonthlyMerchantClubFees", "30");

            //Enter Reprogramming Fee
            createRatesAndFeesAdminHelper.TypeText("ReprogrammingFee", "30");


            //Enter Visa Transaction Interigity Fee
            createRatesAndFeesAdminHelper.TypeText("VisaTransactionInterigityFee", "30");


            //Enter Visa Kilobyte Surcharge Fee
            createRatesAndFeesAdminHelper.TypeText("VisaKilobyteSurchargeFee", "30");


            //Enter MC AVS Surchage Fee
            createRatesAndFeesAdminHelper.TypeText("MCAVSSurchageFee", "30");

            //Enter Visa AFD Non Participation
            createRatesAndFeesAdminHelper.TypeText("VisaAFDNonParticipation", "30");

            //Enter MC Kilobyte Surcharge Fee
            createRatesAndFeesAdminHelper.TypeText("MCKilobyteSurchargeFee", "30");

            //Enter MC Digital Enable Fee
            createRatesAndFeesAdminHelper.TypeText("MCDigitalEnableFee", "30");

            //Enter Discover Auth Surchage
            createRatesAndFeesAdminHelper.TypeText("DiscoverAuthSurchage", "30");


            //Enter Star Debit Network Anual Surcharge
            createRatesAndFeesAdminHelper.TypeText("StarDebitNetworkAnualSurcharge", "30");

            //Enter Jeanie Debit Network Anual Surcharge
            createRatesAndFeesAdminHelper.TypeText("JeanieDebitNetworkAnualSurcharge", "30");

            //Enter Protfolio Msg Fees
            createRatesAndFeesAdminHelper.TypeText("ProtfolioMsgFees", "30");

            //Enter Clover And Transarmor MontlyFee
            createRatesAndFeesAdminHelper.TypeText("CloverAndTransarmorMontlyFee", "30");

            //Enter Apriva Activation Fee
            createRatesAndFeesAdminHelper.TypeText("AprivaActivationFee", "30");

            //Enter Perka Solution Fee
            createRatesAndFeesAdminHelper.TypeText("PerkaSolutionFee", "30");

            //Enter Other Services Fees
            createRatesAndFeesAdminHelper.TypeText("OtherServicesFees", "30");


            //Enter On File Fee
            createRatesAndFeesAdminHelper.TypeText("OnFileFee", "30");


            //Enter PCI Fee Year
            createRatesAndFeesAdminHelper.TypeText("PCIFeeYear", "30");

            //Enter Paper Statement Fee
            createRatesAndFeesAdminHelper.TypeText("PaperStatementFee", "30");

            //Enter Visa Processing Fee
//          createRatesAndFeesAdminHelper.TypeText("VisaProcessingFee", "30");

 //###########################  RIGHT SIDE OF OTHER SERVICES FEES


            //Enter Frame Relay Setup
            createRatesAndFeesAdminHelper.TypeText("FrameRelaySetup", "30");

            //Select Frame Relay Frequency
            createRatesAndFeesAdminHelper.Select("FrameRelayFrequency", "daily");

            //Enter Minimum Montly Discount
            createRatesAndFeesAdminHelper.TypeText("MinimumMontlyDiscount", "30");

            //Select Minimum Montly discount Frequency
            createRatesAndFeesAdminHelper.Select("MinimumMontlyDiscountFrequency", "daily");


            //Enter Monthly Service Support 
            createRatesAndFeesAdminHelper.TypeText("MonthlyServiceSupport", "30");

            //Select Montly Service Support freq
            createRatesAndFeesAdminHelper.Select("MontlyServiceSupportfreq", "daily");


            //Enter Net Connect Activation
            createRatesAndFeesAdminHelper.TypeText("NetConnectActivation", "30");

            //Select Net Connect Activation Frequency
            createRatesAndFeesAdminHelper.Select("NetConnectActivationFrequency", "daily");


            //Enter Orbital GateWay Activation
            createRatesAndFeesAdminHelper.TypeText("OrbitalGateWayActivation", "30");

            //Select Orbital GateWay Activation Frequency
            createRatesAndFeesAdminHelper.Select("OrbitalGateWayActivationFrequency", "daily");


            //Enter Orbital Montly Service Support
            createRatesAndFeesAdminHelper.TypeText("OrbitalMontlyServiceSupport", "30");

            //Select Orbital Montly Service Support Frequency
            createRatesAndFeesAdminHelper.Select("OrbitalMontlyServiceSupportFrequency", "daily");


            //Enter Pin Pad Encrypytion
            createRatesAndFeesAdminHelper.TypeText("PinPadEncrypytion", "30");

            //Select Pin Pad Encrypytion Frequency
            createRatesAndFeesAdminHelper.Select("PinPadEncrypytionFrequency", "daily");

            //Enter Recon Solution
            createRatesAndFeesAdminHelper.TypeText("ReconSolution", "30");

            //Select Recon Solution Frequecy
            createRatesAndFeesAdminHelper.Select("ReconSolutionFrequecy", "daily");

            //Enter Retrivel
            createRatesAndFeesAdminHelper.TypeText("Retrivel", "30");

            //Select Retrivel Frequency
            createRatesAndFeesAdminHelper.Select("RetrivelFrequency", "daily");

            //Enter Statement
            createRatesAndFeesAdminHelper.TypeText("Statement", "30");

            //Select StatementFrequency
            createRatesAndFeesAdminHelper.Select("StatementFrequency", "daily");

            //Enter WirelessActivation
            createRatesAndFeesAdminHelper.TypeText("WirelessActivation", "30");

            //Select Wireless Activation Frequency
            createRatesAndFeesAdminHelper.Select("WirelessActivationFrequency", "daily");

            //Enter Wireless Montly Service Support
            createRatesAndFeesAdminHelper.TypeText("WirelessMontlyServiceSupport", "30");

            //Select Wireless Montly Service Support Frequecy
            createRatesAndFeesAdminHelper.Select("WirelessMontlyServiceSupportFrequecy", "weekly");

            //Enter Monthly Debit Access Fees
            createRatesAndFeesAdminHelper.TypeText("MonthlyDebitAccessFees", "30");

            //Enter Early Termination Fees
            createRatesAndFeesAdminHelper.TypeText("EarlyTerminationFees", "30");

            //Enter Description
            createRatesAndFeesAdminHelper.TypeText("Descriptionl", "30");

            //Enter MC Acquirier AVS Billing
            createRatesAndFeesAdminHelper.TypeText("MCAcquirierAVSBilling", "30");

            //Enter MC Processing Integration
            createRatesAndFeesAdminHelper.TypeText("MCProcessingIntegration", "30");

            //Enter Visa Network Fees
            createRatesAndFeesAdminHelper.TypeText("VisaNetworkFees", "30");

            //Enter Visa Network Fes CNP
            createRatesAndFeesAdminHelper.TypeText("VisaNetworkFesCNP", "30");

            //Enter Terminal Support Fees
            createRatesAndFeesAdminHelper.TypeText("TerminalSupportFees", "30");

            //Enter Start Date
            createRatesAndFeesAdminHelper.TypeText("StartDate", "2015-03-24");

            //Enter Network Realse Fees
            createRatesAndFeesAdminHelper.TypeText("NetworkRealseFees", "40");

            //Enter Discover International Services Fees
            createRatesAndFeesAdminHelper.TypeText("DiscoverInternationalServicesFees", "40");

            //Enter Visa Kilo byte Fees Surcharge
            createRatesAndFeesAdminHelper.TypeText("VisaKilobyteFeesSurcharge", "40");

            //Enter MCC VC2 Fees Surcharge
            createRatesAndFeesAdminHelper.TypeText("MCCVC2FeesSurcharge", "40");

            //Enter Visa FAND Card Not Present Surcharge
            createRatesAndFeesAdminHelper.TypeText("VisaFANDCardNotPresentSurcharge", "40");

            //Enter MC Kilo Byte Fee Surcharge
            createRatesAndFeesAdminHelper.TypeText("MCKiloByteFeeSurcharge", "40");

            //Enter AMEX Network Surcharge Fees
            createRatesAndFeesAdminHelper.TypeText("AMEXNetworkSurchargeFees", "40");


            //Enter Discover Network Au Fee Surcharge
            createRatesAndFeesAdminHelper.TypeText("DiscoverNetworkAutFeeSurcharge", "40");

            //Enter Pulse Debit Card Annual Surcharge
            createRatesAndFeesAdminHelper.TypeText("PulseDebitCardAnnualSurcharge", "40");

            //Enter Return Trans Fees
            createRatesAndFeesAdminHelper.TypeText("ReturnTransFees", "40");

            //Enter eIDS Acces Fees
            createRatesAndFeesAdminHelper.TypeText("eIDSAccesFees", "40");

            //Enter Insights Solution Monthly fee
            createRatesAndFeesAdminHelper.TypeText("InsightsSolutionMonthlyfee", "40");

            //Enter Apriva Montly Acces Fes
            createRatesAndFeesAdminHelper.TypeText("AprivaMontlyAccesFes", "40");

            //Enter Description Again
            createRatesAndFeesAdminHelper.TypeText("DescriptionAgain", "40");

            //SelectMonthly
            createRatesAndFeesAdminHelper.Select("SelectMontly", "January");

            //Enter Advantage Buyer Program
            createRatesAndFeesAdminHelper.TypeText("AdvantageBuyerProgram", "40");

            //Enter PCI Fees Month
            createRatesAndFeesAdminHelper.TypeText("PCIFeesMonth", "40");

            //Enter MC proceesing Fees
            createRatesAndFeesAdminHelper.TypeText("MCproceesingFees", "60");        

            //Enter MC proceesing Fees
            createRatesAndFeesAdminHelper.TypeText("Voice", "60");


            //Enter Frame Relay Authoriztion
            createRatesAndFeesAdminHelper.TypeText("FrameRelayAuthoriztion", "60");


            //Enter MC NABU Fees
            createRatesAndFeesAdminHelper.TypeText("MCNABUFees", "60");


            //Enter Cross Border Fees
            createRatesAndFeesAdminHelper.TypeText("CrossBorderFees", "60");


            //Enter Issuer Refferal
            createRatesAndFeesAdminHelper.TypeText("IssuerRefferal", "60");


            //Enter Net Connect Authorization
            createRatesAndFeesAdminHelper.TypeText("NetConnectAuthorization", "60");


            //Enter Visa APF Fees
            createRatesAndFeesAdminHelper.TypeText("VisaAPFFees", "60");

            //Enter Cross Border FeesUs
            createRatesAndFeesAdminHelper.TypeText("CrossBorderFeesUs", "60");

            //Enter Electronic AVS
            createRatesAndFeesAdminHelper.TypeText("ElectronicAVS", "60");

            //Enter OAF WireLess Authorization Fees
            createRatesAndFeesAdminHelper.TypeText("OAFWireLessAuthorizationFees", "60");

            //Enter OAF Zero Limit Fee
            createRatesAndFeesAdminHelper.TypeText("OAFZeroLimitFee", "60");

            //Enter Connectivity Fees
            createRatesAndFeesAdminHelper.TypeText("ConnectivityFees", "60");

            //Enter Visa Inter National Fees
            createRatesAndFeesAdminHelper.TypeText("VisaInterNationalFees", "60");

            //Enter TransArmorAuthfees
            createRatesAndFeesAdminHelper.TypeText("TransArmorAuthfees", "60");

            //Enter Visa Bin Fees
            createRatesAndFeesAdminHelper.TypeText("VisaBinFees", "60");

            //Enter MC IICA Fees
            createRatesAndFeesAdminHelper.TypeText("MCIICAFees", "60");

            //Enter Regulatory Product Fee
            createRatesAndFeesAdminHelper.TypeText("RegulatoryProductFee", "60");

            //Enter TINTNF Invalid Fee
            createRatesAndFeesAdminHelper.TypeText("TINTNFInvalidFee", "60");

            //Enter Web site Usage Fees
            createRatesAndFeesAdminHelper.TypeText("WebsiteUsageFees", "60");

            //Enter IVR Usage Fees
            createRatesAndFeesAdminHelper.TypeText("IVRUsageFees", "60");

            //Enter MC LiceNse Fee
            createRatesAndFeesAdminHelper.TypeText("MCLiceseFee", "60");

            //Enter MC License Fees Sale Vol
            createRatesAndFeesAdminHelper.TypeText("MCLicenseFeesSaleVol", "60");


            //Enter MC License Fees Flat Rate  
            createRatesAndFeesAdminHelper.TypeText("MCLicenseFeesFlatRate", "60");

            //Enter Amex Credit Discount Rate
            createRatesAndFeesAdminHelper.TypeText("AmexCreditDiscountRate", "90");

            //Enter Credit Discount Rate 813
            createRatesAndFeesAdminHelper.TypeText("CreditDiscountRate813", "90");


            //Enter Sale And Credit Trans
            createRatesAndFeesAdminHelper.TypeText("SaleAndCreditTrans", "90");

            //Enter Mid Qual Credit Trans  
            createRatesAndFeesAdminHelper.TypeText("MidQualCreditTrans", "90");

            //Enter Non Qual Credit Trans
            createRatesAndFeesAdminHelper.TypeText("NonQualCreditTrans", "90");

            //Enter Non Qual Surcarge
            createRatesAndFeesAdminHelper.TypeText("NonQualSurcarge", "90");

            //Enter Charge Back Fees
            createRatesAndFeesAdminHelper.TypeText("ChargeBackFees", "90");

            //Enter Retrival Fees
            createRatesAndFeesAdminHelper.TypeText("RetrivalFees", "90");

            //Enter AVS Amex
            createRatesAndFeesAdminHelper.TypeText("AVSAmex", "90");

            //EnterAmex Auth Fees
            createRatesAndFeesAdminHelper.TypeText("AmexAuthDees", "90");

            // Click on Save button   
            createRatesAndFeesAdminHelper.ClickElement("ClickOnMasterRateAndFeesSavebtn");

        }

        private void Selectbytext(string p1, string p2)
        {
            throw new NotImplementedException();
        }
    }
}
