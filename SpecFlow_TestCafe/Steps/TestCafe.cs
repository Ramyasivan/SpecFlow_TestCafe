using NUnit.Framework;
using SpecFlow_TestCafe.Page;
using TechTalk.SpecFlow;

namespace SpecFlow_TestCafe.Steps
{
    [Binding]
    public sealed class TestCafe
    {
        private ScenarioContext _scenarioContext;
        private DriverHelper _driverHelper;
        TestCafePage testCafePage;
        SuccessPage successPage;
        public TestCafe(DriverHelper driverHelper, ScenarioContext scenarioContext)
        {
            _driverHelper = driverHelper;
            _scenarioContext = scenarioContext;
            testCafePage = new TestCafePage(_driverHelper.Driver);
            successPage = new SuccessPage(_driverHelper.Driver);
        }

     
        [Given(@"I Launch the Test Cafe webpage")]
        public void GivenILaunchTheTestCafeWebpage()
        {
            _driverHelper.Driver.Navigate().GoToUrl("https://devexpress.github.io/testcafe/example/");
            _driverHelper.Driver.Manage().Window.Maximize();
        }

        [Given(@"I Input Name (.*)")]
        public void GivenIInputName(string value)
        {
            testCafePage.InputName(value);
            _scenarioContext["Name"] = value;
        }

        [Given(@"I click on submit button")]
        public void GivenIClickOnSubmitButton()
        {
            testCafePage.ClickSubmitButton();
        }

        [Then(@"Success Page is displayed")]
        public void ThenSuccessPageIsDisplayed()
        {
            string successMsg = "Thank you, " + (string)_scenarioContext["Name"] + "!";
            successPage.VerifySuccessMsg(successMsg);
        }

        [Given(@"I select Operating System as (.*)")]
        public void GivenISelectOperatingSystemAs(string value)
        {
            testCafePage.SelectOSRadioBtn(value);
        }

        [Given(@"I select Remote Devices checkbox in important features")]
        public void GivenISelectRemoteDevicesCheckboxInImportantFeatures()
        {
            testCafePage.SelectRemoteTestingCB();
        }

        [Given(@"I Select Reuse JavaScript code in important features")]
        public void GivenISelectReuseJavaScriptCodeInImportantFeatures()
        {
            testCafePage.SelectReusingJSCodeCB();
        }

        [Given(@"I select all checkboxes in important features")]
        public void GivenISelectAllCheckboxesInImportantFeatures()
        {
            testCafePage.SelectRemoteTestingCB();
            testCafePage.SelectReusingJSCodeCB();
            testCafePage.SelectParallelTestingCB();
            testCafePage.SelectCICB();
            testCafePage.SelectTrafficMarkupCB();
        }

        [Then(@"I verify submit button is disabled")]
        public void ThenIVerifySubmitButtonIsDisabled()
        {
            if (!testCafePage.CheckSubmitButtonEnabled())
                Assert.Pass("Submit button is disabled");
            else
                Assert.Fail("Submit button is enabled");
        }

        [Given(@"I select I have tried TestCafe checkbox")]
        public void GivenISelectIHaveTriedTestCafeCheckbox()
        {
            testCafePage.SelectTriedTestCafeCB();
        }

        [Given(@"I select (.*) in a slider")]
        public void GivenISelectInASlider(string value)
        {
            testCafePage.SelectRating(value);
        }

        [Given(@"I input (.*) in What you think textarea")]
        public void GivenIInputInWhatYouThinkTextarea(string value)
        {
            testCafePage.InputReview(value);
        }


    }
}
