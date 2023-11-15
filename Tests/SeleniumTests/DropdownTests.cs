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
    internal class DropdownTests : BaseSteps
    {
        private DropdownPage dropdownPage;

        [TestCase("Option 1", TestName = "Verify dropdown option is correctly selected")]
        public void VerifyDropdownSelection(string option)
        {
            NavigateToPage("Dropdown");
            dropdownPage = new DropdownPage(driver);

            logger.Info("Selecting dropdown option as 'Option 2'");
            dropdownPage.SetDropdownOption(option);

            logger.Info("Verifying selected option");
            Assert.AreEqual(dropdownPage.GetSelectedOption(), option);
        }
    }
}