using DotNetTestingFramework.Pages;
using DotNetTestingFramework.Tests.Core;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;

namespace DotNetTestingFramework.Tests.SeleniumTests
{
    [TestFixture]
    [AllureNUnit]
    [AllureTag("@Heroku")]
    [Category("Selenium")]
    [Parallelizable(ParallelScope.Fixtures)]
    internal class CheckboxesTests : BaseSteps
    {
        private CheckboxPage checkboxPage;

        [TestCase(null, TestName = "Verify checkboxes are checked")]
        public void VerifyCheckboxesChecking(object? ignored)
        {
            NavigateToPage("Checkboxes");
            checkboxPage = new CheckboxPage(driver);


            logger.Info("Checking the first checkbox");
            checkboxPage.ClickCheckbox(1);

            logger.Info("Verifying the first checkbox is checked");
            Assert.That(checkboxPage.IsChecked(1), Is.True);
        }

        [TestCase(null, TestName = "Verify checkboxes are unchecked")]
        public void VerifyCheckboxesUnchecking(object? ignored)
        {
            NavigateToPage("Checkboxes");
            checkboxPage = new CheckboxPage(driver);


            logger.Info("Unchecking the second checkbox");
            checkboxPage.ClickCheckbox(2);

            logger.Info("Verifying the second checkbox is unchecked");
            Assert.That(checkboxPage.IsChecked(2), Is.False);

        }
    }
}
