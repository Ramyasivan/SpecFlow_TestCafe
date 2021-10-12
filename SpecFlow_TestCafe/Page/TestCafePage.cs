using OpenQA.Selenium;
using SpecFlow_TestCafe.Drivers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlow_TestCafe.Page
{
    class TestCafePage
    {
        private IWebDriver _driver;

        public TestCafePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void NavigateToTestCafe()
        {
            _driver.Navigate().GoToUrl("https://devexpress.github.io/testcafe/example/");
        }

        public IWebElement SubmitBtn => _driver.FindElement(By.Id("submit-button"));
        public IWebElement Name => _driver.FindElement(By.Id("developer-name"));

        public IWebDriver Driver { get; }

        public void ClickSubmitButton() => SubmitBtn.Click();



    }
}
