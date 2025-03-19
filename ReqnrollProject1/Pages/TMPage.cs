using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Feb25TurnUpPortal.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Feb25TurnUpPortal.Pages
{
    public class TMPage
    {
        public void CreateTimeRecord(IWebDriver driver)
        {
            //Click on create new button
            IWebElement createNewButton = driver.FindElement(By.XPath("//a[text()='Create New']"));
            createNewButton.Click();

            //Select time from dropdown
            IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span"));
            typeCodeDropdown.Click();

            IWebElement timeOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
            timeOption.Click();

            //Type the code into code textbox
            IWebElement codeTextBox = driver.FindElement(By.Id("Code"));
            codeTextBox.SendKeys("TA Programme");

            //Type description into description textbox
            IWebElement descriptionTextPath = driver.FindElement(By.Id("Description"));
            descriptionTextPath.SendKeys("This is a description");

            //Type price into price textbox
            IWebElement priceTagOverlap = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceTagOverlap.Click();

            IWebElement priceTextBox = driver.FindElement(By.Id("Price"));
            priceTextBox.SendKeys("12");

            //Click on save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Wait.WaitToBeVisible(driver, "XPath", "//span[text()='Go to the last page']", 3);

            //check time record has been created successfully
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//span[text()='Go to the last page']"));
            goToLastPageButton.Click();

            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]", 3);

            IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            Assert.That(newCode.Text == "TA Programme", "New time record has not been created");

            //if (newCode.Text == "TA Programme")
            //{
            //    Assert.Pass("Time record created successfully!");
            //}
            //else
            //{
            //    Assert.Fail("New time recorded has not been created!");

            //}

            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]", 3);

        }
        public void EditTimeRecord(IWebDriver driver)
        {
            //Go to last page
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//span[text()='Go to the last page']"));
            goToLastPageButton.Click();


            //Click on the Edit button
            IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            editButton.Click();

            //Edit the price per unit
            IWebElement priceTagOverlap1 = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceTagOverlap1.Click();

            IWebElement priceTextBox1 = driver.FindElement(By.Id("Price"));
            priceTextBox1.Clear();

            IWebElement priceTagOverlap2 = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceTagOverlap1.Click();

            IWebElement priceTextBox2 = driver.FindElement(By.Id("Price"));
            priceTextBox2.SendKeys("40");

            //Click on save button
            IWebElement saveButtonAfterEdit = driver.FindElement(By.Id("SaveButton"));
            saveButtonAfterEdit.Click();
            Wait.WaitToBeClickable(driver, "XPath", "//span[text()='Go to the last page']", 3);


        }
        public void DeleteTimeRecord(IWebDriver driver)
        {

            IWebElement goToLastPageButton1 = driver.FindElement(By.XPath("//span[text()='Go to the last page']"));
            goToLastPageButton1.Click();

            //Click on the Delete button
            IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            deleteButton.Click();

            //Deleting a record
            IAlert confirmAlert = driver.SwitchTo().Alert();
            confirmAlert.Accept();


            //check if the record is deleted

            IWebElement checkDelete = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));

            if (checkDelete.Text == "40")
            {
                Assert.Fail("Record is not deleted");

            }
            else
            {
                Assert.Pass("Record is deleted successfully");
            }

        }
    }
}