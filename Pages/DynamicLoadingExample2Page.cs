using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace DotNetTestingFramework.Pages
{
    public class DynamicLoadingExample2Page
    {
        private readonly IWebDriver _driver;
#pragma warning disable CS0649
        [FindsBy(How = How.CssSelector, Using = "#start > button")]
        private readonly IWebElement btnStart;

        private readonly By loadingBar = By.Id("loading");

        [FindsBy(How = How.Id, Using = "finish")]
        private readonly IWebElement txtHello;
#pragma warning restore CS0649
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public DynamicLoadingExample2Page(IWebDriver driver)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public void StartLoading() => btnStart.Click();

        private void WaitForLoadingToFinish()
        {
            WebDriverWait wait = new(_driver, System.TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(loadingBar));
        }

        public string GetInvisibleELementText()
        {
            WaitForLoadingToFinish();
            return txtHello.Text;
        }
    }
}
