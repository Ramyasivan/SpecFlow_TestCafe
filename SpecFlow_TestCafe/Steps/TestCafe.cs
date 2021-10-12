using SpecFlow_TestCafe.Page;
using TechTalk.SpecFlow;

namespace SpecFlow_TestCafe.Steps
{
    [Binding]
    public sealed class TestCafe
    {

        private DriverHelper _driverHelper;
        TestCafePage testCafePage;
        public TestCafe(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
            testCafePage = new TestCafePage(_driverHelper.Driver);
        }

     
        [Given(@"I Launch the Test Cafe webpage")]
        public void GivenILaunchTheTestCafeWebpage()
        {
            _driverHelper.Driver.Navigate().GoToUrl("https://devexpress.github.io/testcafe/example/");
            //testCafePage.NavigateToTestCafe();
        }

        [Given(@"I Input Name")]
        public void GivenIInputName()
        {
            testCafePage.Name.SendKeys("Test");
        }
         

        [Given(@"I click on submit button")]
        public void GivenIClickOnSubmitButton()
        {
            testCafePage.ClickSubmitButton();
        }

        [Then(@"I verify Success Page is displayed")]
        public void ThenIVerifySuccessPageIsDisplayed()
        {
         //   ScenarioContext.Current.Pending();
        }


    }
}
