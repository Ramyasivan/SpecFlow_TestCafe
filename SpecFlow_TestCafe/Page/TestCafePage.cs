using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SpecFlow_TestCafe.Drivers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
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

        public IWebElement SubmitBtn => _driver.FindElement(By.Id("submit-button"));
        public IWebElement Name => _driver.FindElement(By.Id("developer-name"));
        public IWebElement RemoteDevices => _driver.FindElement(By.Id("remote-testing"));
        public IWebElement ReusingJSCode => _driver.FindElement(By.Id("reusing-js-code"));
        public IWebElement ParallelTesting => _driver.FindElement(By.Id("background-parallel-testing"));
        public IWebElement CI => _driver.FindElement(By.Id("continuous-integration-embedding"));
        public IWebElement TrafficMarkup => _driver.FindElement(By.Id("traffic-markup-analysis"));
        public IWebElement TriedTestCafe => _driver.FindElement(By.Id("tried-test-cafe"));
        public IWebElement slider => _driver.FindElement(By.Id("slider"));
        public IWebElement comments => _driver.FindElement(By.Id("comments"));
        public IWebElement Header => _driver.FindElement(By.TagName("header"));


        public void ClickSubmitButton() => SubmitBtn.Click();


        public void InputName(string name)
        {
            Name.SendKeys(name);
        }
        public void SelectOSRadioBtn(string value)
        {
            string xpath = "//input[@value=\'" + value + "\']";
            _driver.FindElement(By.XPath(xpath));
        }

        public void SelectRemoteTestingCB() => RemoteDevices.Click();
        public void SelectReusingJSCodeCB() => ReusingJSCode.Click();
        public void SelectParallelTestingCB() => ParallelTesting.Click();
        public void SelectCICB() => CI.Click();
        public void SelectTrafficMarkupCB() => TrafficMarkup.Click();
        public void SelectTriedTestCafeCB() => TriedTestCafe.Click();

        public bool CheckSubmitButtonEnabled()
        {
            if (SubmitBtn.Enabled == true)
                return true;
            else
                return false;
        }

        public void SelectRating(string value)
        {
            Actions action = new Actions(_driver);
            IWebElement SliderIcon = _driver.FindElement(By.XPath("//span[starts-with(@class,'ui-slider-handle')]"));

            int intVal = Convert.ToInt32(value);
            for (int i = 2; i <= intVal; i++)
            {
                SliderIcon.Click();
                SliderIcon.SendKeys(Keys.ArrowRight);
            }
        }

        public void InputReview(string review)
        {
            comments.SendKeys(review);
        }
    }
}
