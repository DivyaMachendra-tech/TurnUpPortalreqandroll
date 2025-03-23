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
        //LoginPage Object initaialization and definition
        LoginPage loginPageObj = new LoginPage();

        //HomePage Object initaialization and definition
        HomePage homePageObj = new HomePage();

        //TMPage Object initaialization and definition
        TMPage tmPageObj = new TMPage();

        [Given("I logged into Turnup portal successfully")]
        //[BeforeScenario]
        public void GivenILoggedIntoTurnupPortalSuccessfully()
        {
            driver = new ChromeDriver();

           loginPageObj.LoginActions(driver, "hari", "123123");

        }

        [Given("I navigate to the Time and Material Page")]
        public void GivenINavigateToTheTimeAndMaterialPage()
        {
            homePageObj.NavigateToTMPage(driver);

        }

        [When("I create a new Time and Material record")]
        public void WhenICreateANewTimeAndMaterialRecord()
        {
            
            tmPageObj.CreateTimeRecord(driver);
        }

        [Then("the record should be created successfully")]
        public void ThenTheRecordShouldBeCreatedSuccessfully()
        {
            
            String newCode = tmPageObj.GetNewCode(driver);
            Assert.That(newCode == "TA Programme", "Actual code and Expected code do not match");
            
            String newDescription = tmPageObj.GetNewDescription(driver);
            Assert.That(newDescription == "This is a description","Actual Description and Expected Description do not match");

            String newPrice = tmPageObj.GetNewPrice(driver);
            Console.WriteLine(newPrice);
            Assert.That(newPrice == "$14.00", "Actual Price and Expected Price do not match");
        }
        [When("I update the {string} and {string} on the existing time record.")]
        public void WhenIUpdateTheAndOnTheExistingTimeRecord_(string code, string description)
        {
            tmPageObj.EditTimeRecord(driver, code, description);
            
        }

        [Then("the record have the updated {string} and {string}")]
        public void ThenTheRecordHaveTheUpdatedAnd(string code, string description)
        {
            String editedCode = tmPageObj.GetEditedCode(driver);
            String editedDescription = tmPageObj.GetEditedDescription(driver);
            Assert.That(code == editedCode, "Expected edited code and actual edited code do not match");
            Assert.That(description == editedDescription, "Expected edited description and actual edited description do not match");
            
        }

        //[AfterScenario]

        //public void CloseTestRun()
        //{
        //    driver.Quit();

        //}








    }
}
