using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Feb25TurnUpPortal.Pages
{
    public class LoginPage

    {
        private readonly String url = "http://horse.industryconnect.io/";
        private readonly By userNameTextBoxLocator = By.Id("UserName");
        IWebElement usernameTextBox;
        private readonly By passwordTextBoxLocator = By.Id("Password");
        IWebElement pwdTextBox;
        private readonly By loginButtonLoactor = By.XPath("//input[@value='Log in']");
        public void LoginActions(IWebDriver driver,String username,String pwd)
        {
            //Launch TurnUPportal
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();

            //Identify UserName TextBox and enter valid username
            usernameTextBox = driver.FindElement(userNameTextBoxLocator);
            usernameTextBox.SendKeys(username);

            //Identify Password TextBox and enter valid Password
            pwdTextBox = driver.FindElement(passwordTextBoxLocator);
            pwdTextBox.SendKeys(pwd);


            //Identify LoginButton and click on it
            IWebElement loginButton = driver.FindElement(loginButtonLoactor);
            loginButton.Click();




        }
        public void CheckSuccessfulLogin(IWebDriver driver)
        {
            //Check if user has logged in successfuly
            IWebElement hellohari = driver.FindElement(By.XPath("//a[text()='Hello hari!']"));

            if (hellohari.Text == "Hello hari!")
            {
                Console.WriteLine("User has logged in successfully.Test Passed");
            }
            else
            {
                Console.WriteLine("User has not logged in.Test failed");

            }

        }
    }
}