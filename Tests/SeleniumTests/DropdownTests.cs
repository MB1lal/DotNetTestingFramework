﻿using DotNetTestingFramework.Pages;
using DotNetTestingFramework.Tests.Core;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;


namespace DotNetTestingFramework.Tests.SeleniumTests
{
    [TestFixture]
    [AllureNUnit]
    [AllureTag("@Heroku", "@dropdown")]
    [Category("Selenium")]
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
            Assert.That(option, Is.EqualTo(dropdownPage.GetSelectedOption()));
        }
    }
}