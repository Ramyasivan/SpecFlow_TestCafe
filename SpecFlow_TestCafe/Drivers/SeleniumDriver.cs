using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlow_TestCafe.Drivers
{
    public class SeleniumDriver
    {
        private IWebDriver driver;


        public IWebDriver Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("'--start-maximized'");
            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            return driver;
        }
    }
}
