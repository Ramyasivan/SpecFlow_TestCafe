using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlow_TestCafe.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlow_TestCafe.HookInitialization
{
    [Binding]
    public sealed class HooksInitilization
    {
        private DriverHelper _driverHelper;
        public HooksInitilization(DriverHelper driverHelper) => _driverHelper = driverHelper;

        [BeforeScenario]
        public void BeforeScenario()
        {
            _driverHelper.Driver = new ChromeDriver();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driverHelper.Driver.Quit();
        }
    }
}