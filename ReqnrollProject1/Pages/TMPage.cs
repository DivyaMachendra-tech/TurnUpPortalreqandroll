using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ReqnrollProject1.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;


namespace ReqnrollProject1.Pages
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
            priceTextBox.SendKeys("14 ");

            //Click on save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Wait.WaitToBeVisible(driver, "XPath", "//span[text()='Go to the last page']", 20);

            //check time record has been created successfully
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//span[text()='Go to the last page']"));
            goToLastPageButton.Click();

           //Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]", 10);
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]", 50);

        }

        public String GetNewCode(IWebDriver driver)
        {
            IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            return newCode.Text;
        }
        public String GetNewDescription(IWebDriver driver)
        {
            IWebElement newDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
            return newDescription.Text;
        }
        public String GetNewPrice(IWebDriver driver)
        {
            IWebElement newPrice = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));
            return newPrice.Text;
        }
        public void EditTimeRecord(IWebDriver driver,String code,String description)
        {
            //Go to last page
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//span[text()='Go to the last page']"));
            goToLastPageButton.Click();


            //Click on the Edit button
            IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            editButton.Click();

            //Edit the price per unit
           // IWebElement priceTagOverlap1 = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
           // priceTagOverlap1.Click();

            //IWebElement priceTextBox1 = driver.FindElement(By.Id("Price"));
            //priceTextBox1.Clear();

            //IWebElement priceTagOverlap2 = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            //priceTagOverlap1.Click();

            IWebElement codeTextBox = driver.FindElement(By.Id("Code"));
            codeTextBox.Clear();
            codeTextBox.SendKeys(code);
            Thread.Sleep(2000);

            IWebElement descriptionTextBox = driver.FindElement(By.Id("Description"));
            descriptionTextBox.Clear();
            descriptionTextBox.SendKeys(description);

            //Click on save button
            IWebElement saveButtonAfterEdit = driver.FindElement(By.Id("SaveButton"));
            saveButtonAfterEdit.Click();
            Wait.WaitToBeClickable(driver, "XPath", "//span[text()='Go to the last page']", 3);

            IWebElement goToLastPageButton1 = driver.FindElement(By.XPath("//span[text()='Go to the last page']"));
            goToLastPageButton1.Click();




        }

        public string GetEditedCode(IWebDriver driver)
        {

            IWebElement editedCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            return editedCode.Text;       
        }

        public String GetEditedDescription(IWebDriver driver)
        {
            IWebElement editedDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
            return editedDescription.Text;
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