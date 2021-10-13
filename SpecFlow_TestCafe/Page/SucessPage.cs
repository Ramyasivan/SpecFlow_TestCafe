
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlow_TestCafe.Page
{
    public class SuccessPage
    {
        private IWebDriver _driver;

        public SuccessPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement SuccessHeader => _driver.FindElement(By.Id("article-header"));

        public void VerifySuccessMsg(string value)
        {
            SuccessHeader.Text.Equals(value);
        }

    }
}
