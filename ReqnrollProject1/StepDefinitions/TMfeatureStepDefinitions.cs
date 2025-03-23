using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using Reqnroll;
using ReqnrollProject1.Pages;
using ReqnrollProject1.Utilities;

namespace ReqnrollProject1.StepDefinitions
{
    [Binding]
    public class TMfeatureStepDefinitions : CommonDriver
    {
        [Given("I logged into Turnup portal successfully")]
        public void GivenILoggedIntoTurnupPortalSuccessfully()
        {
            driver = new ChromeDriver();

            //LoginPage Object initaialization and definition
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginActions(driver, "hari", "123123");

        }

        [Given("I navigate to the Time and Material Page")]
        public void GivenINavigateToTheTimeAndMaterialPage()
        {
            //HomePage Object initaialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.NavigateToTMPage(driver);

        }

        [When("I create a new Time and Material record")]
        public void WhenICreateANewTimeAndMaterialRecord()
        {
            //TMPage Object initaialization and definition
            TMPage tmPageObj = new TMPage();
            tmPageObj.CreateTimeRecord(driver);


        }

        [Then("the record should be created successfully")]
        public void ThenTheRecordShouldBeCreatedSuccessfully()
        {
            TMPage tmPageObj = new TMPage();
            
            String newCode = tmPageObj.GetNewCode(driver);
            Assert.That(newCode == "TA Programme", "Actual code and Expected code do not match");
            
            String newDescription = tmPageObj.GetNewDescription(driver);
            Assert.That(newDescription == "This is a description","Actual Description and Expected Description do not match");

            String newPrice = tmPageObj.GetNewPrice(driver);
            Console.WriteLine(newPrice);
            Assert.That(newPrice == "$14.00", "Actual Price and Expected Price do not match");
           
        }
        [When("I update the {string} on the existing time record.")]
        public void WhenIUpdateTheOnTheExistingTimeRecord_(string code)
        {
            TMPage tmPageObj = new TMPage();
            tmPageObj.EditTimeRecord(driver,code);

        }

        [Then("the record should be updated {string}")]
        public void ThenTheRecordShouldBeUpdated(string code)
        {
            TMPage tmPageObj = new TMPage();
            String editedPrice = tmPageObj.GetEditedPrice(driver);
            Assert.That(editedPrice == code, "Expected edited code does not match with actual edited code");

        }








    }
}
