﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReqnrollProject1.Utilities;
using OpenQA.Selenium;

namespace ReqnrollProject1.Pages
{
    public class HomePage
    {

        public void NavigateToTMPage(IWebDriver driver)
        {

            //Create time record
            IWebElement administrationTab = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            administrationTab.Click();

            //Navigate to time and material page
            IWebElement timeAndMaterialOption = driver.FindElement(By.XPath("//a[text()='Time & Materials']"));
            timeAndMaterialOption.Click();

            


        }
    }
}