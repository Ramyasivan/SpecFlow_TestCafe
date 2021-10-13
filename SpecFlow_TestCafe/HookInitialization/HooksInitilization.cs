using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Gherkin.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlow_TestCafe.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using System.Reflection;

namespace SpecFlow_TestCafe.HookInitialization
{
    [Binding]
    public sealed class HooksInitilization
    {
        private DriverHelper _driverHelper;
        private FeatureContext _featureContext;
        private ScenarioContext _scenarioContext;
        public HooksInitilization(DriverHelper driverHelper, FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            _driverHelper = driverHelper;
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
        }
        public static ExtentReports extent;
        public static ExtentTest Scenario;
        public static ExtentTest featureName;

        [BeforeTestRun]
        public static void InitializeReport()
        {
            var driverDir = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            int Location = driverDir.IndexOf("bin");
            string strDirName = driverDir.Substring(0, Location);
      
            var htmlReporter = new ExtentHtmlReporter(strDirName + "\\TestResult\\ExtentReport.html");
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        [AfterTestRun]
        public static void FlushReport()
        {
            extent.Flush();
        }

        [AfterStep]
        public void InsertReportingsteps()
        {
            string stepType = _scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            PropertyInfo pInfo = typeof(ScenarioContext).GetProperty("ScenarioExecutionStatus", BindingFlags.Instance | BindingFlags.Public);
            MethodInfo getter = pInfo.GetGetMethod(nonPublic: true);
            object TestResult = getter.Invoke(_scenarioContext, null);

            if (_scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                    Scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "When")
                    Scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "Then")
                    Scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "And")
                    Scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
            }
            else if (_scenarioContext.TestError != null)
            {
                if (stepType == "Given")
                    Scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenarioContext.TestError.InnerException);
                else if (stepType == "When")
                    Scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenarioContext.TestError.InnerException);
                else if (stepType == "Then")
                    Scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
            }

            //Pending Status
            if (TestResult.ToString() == "StepDefinitionPending")
            {
                if (stepType == "Given")
                    Scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "When")
                    Scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "Then")
                    Scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");

            }

        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _driverHelper.Driver = new ChromeDriver();
            featureName = extent.CreateTest<AventStack.ExtentReports.Gherkin.Model.Feature>(_featureContext.FeatureInfo.Title);

            Scenario = featureName.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driverHelper.Driver.Quit();
        }
    }
}