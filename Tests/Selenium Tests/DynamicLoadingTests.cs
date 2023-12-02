using DotNetTestingFramework.Pages;
using DotNetTestingFramework.Tests.Core;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;

namespace DotNetTestingFramework.Tests.Selenium_Tests
{
    [TestFixture]
    [AllureNUnit]
    [AllureTag("@Heroku", "@DynamicLoading")]
    [Category("Selenium")]
    internal class DynamicLoadingTests : BaseSteps
    {
        private DynamicLoadingPage dynamicLoadingPage;

        [TestCase(1, TestName = "Verify loading of hidden elements")]
        [TestCase(2, TestName = "Verify loading of newly created elements")]
        public void HiddenElementsTest(int exampleIndex)
        {
            dynamicLoadingPage = new(driver);
            string elementText;

            NavigateToPage("Dynamic Loading");

            logger.Info($"Navigating to Example {exampleIndex} Page");
            dynamicLoadingPage.ClickXExample(exampleIndex);
            switch (exampleIndex)
            {
                case 1:
                    DynamicLoadingExample1Page dynamicLoadingExample1Page = new(driver);
                    logger.Info("Starting loading of element");
                    dynamicLoadingExample1Page.StartLoading();
                    logger.Info("Fetching text of element");
                    elementText = dynamicLoadingExample1Page.GetInvisibleELementText();
                    break;

                case 2:
                    DynamicLoadingExample2Page dynamicLoadingExample2Page = new(driver);
                    logger.Info("Starting loading of element");
                    dynamicLoadingExample2Page.StartLoading();
                    logger.Info("Fetching text of element");
                    elementText = dynamicLoadingExample2Page.GetInvisibleELementText();
                    break;
                default:
                    logger.Error("Invalid example specified");
                    throw new ArgumentException("Invalid example index specified");

            }

            logger.Info("Verifying text");
            Assert.That(elementText, Is.EqualTo("Hello World!"));
        }
    }
}
