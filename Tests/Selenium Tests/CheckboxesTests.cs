using DotNetTestingFramework.Pages;
using DotNetTestingFramework.Tests.Core;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;

namespace DotNetTestingFramework.Tests.Selenium_Tests
{
    [TestFixture, Description("Verify checkbox scenarios for Heroku Web App")]
    [AllureNUnit]
    [AllureTag("@Heroku", "@checkboxes")]
    [Category("Selenium")]
    internal class CheckboxesTests : BaseSteps
    {
        private CheckboxPage? checkboxPage;

        [Test, Description("Verify checkboxes are checked")]
        public void VerifyCheckboxesChecking()
        {
            NavigateToXPage("Checkboxes");
            checkboxPage = new CheckboxPage(driver);


            logger.Info("Checking the first checkbox");
            checkboxPage.ClickCheckbox(1);

            logger.Info("Verifying the first checkbox is checked");
            Assert.That(checkboxPage.IsChecked(1), Is.True);
        }

        [Test, Description("Verify checkboxes are unchecked")]
        public void VerifyCheckboxesUnchecking()
        {
            NavigateToXPage("Checkboxes");
            checkboxPage = new CheckboxPage(driver);


            logger.Info("Unchecking the second checkbox");
            checkboxPage.ClickCheckbox(2);

            logger.Info("Verifying the second checkbox is unchecked");
            Assert.That(checkboxPage.IsChecked(2), Is.False);

        }
    }
}
