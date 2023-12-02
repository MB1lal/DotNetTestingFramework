using DotNetTestingFramework.Pages;
using DotNetTestingFramework.Tests.Core;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;

namespace DotNetTestingFramework.Tests.Selenium_Tests
{
    [TestFixture]
    [AllureNUnit]
    [AllureTag("@Heroku", "@JSAlerts")]
    [Category("Selenium")]
    internal class JSAlertTests : BaseSteps
    {
        [TestCase(null, TestName = "Verifying interaction with JS Alerts")]
        public void VerifyJSALerts(object? ignored)
        {
            NavigateToPage("JavaScript Alerts");
            JSAlertsPage jSAlertsPage = new(driver);
            logger.Info("Triggering JS ALert");
            jSAlertsPage.TriggerJSALert("JS Alert");
            logger.Info("Accepting the alert");
            jSAlertsPage.InteractWithAlert("OK");
            logger.Info("Verifying interaction with alert was succesfull");
            Assert.That(jSAlertsPage.GetResultText(), Is.EqualTo("You successfully clicked an alert"));

        }

        [TestCase(null, TestName = "Verifying interaction with JS Confirm")]
        public void VerifyJSConfirm(object? ignored)
        {
            NavigateToPage("JavaScript Alerts");
            JSAlertsPage jSAlertsPage = new(driver);
            logger.Info("Triggering JS Confirm");
            jSAlertsPage.TriggerJSALert("JS Confirm");
            logger.Info("Accepting the alert");
            jSAlertsPage.InteractWithAlert("CANCEL");
            logger.Info("Verifying interaction with alert was succesfull");
            Assert.That(jSAlertsPage.GetResultText(), Is.EqualTo("You clicked: Cancel"));
        }

        [TestCase(null, TestName = "Verifying interaction with JS Prompt")]
        public void VerifyJSPrompts(object? ignored)
        {
            string inputText = "Test Input";
            NavigateToPage("JavaScript Alerts");
            JSAlertsPage jSAlertsPage = new(driver);
            logger.Info("Triggering JS Prompt");
            jSAlertsPage.TriggerJSALert("JS Prompt");
            logger.Info("Entering the text into alert");
            jSAlertsPage.EnterTextIntoAlert(inputText);
            logger.Info("Verifying entered text was correct");
            Assert.That(jSAlertsPage.GetResultText(), Is.EqualTo($"You entered: {inputText}"));
        }

    }
}
