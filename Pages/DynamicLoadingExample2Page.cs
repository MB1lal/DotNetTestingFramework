using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace DotNetTestingFramework.Pages
{
    public class DynamicLoadingExample2Page
    {
        private IWebDriver _driver;
        [FindsBy(How = How.CssSelector, Using = "#start > button")]
        private IWebElement? btnStart;

        private By loadingBar = By.Id("loading");

        [FindsBy(How = How.Id, Using = "finish")]
        private IWebElement? txtHello;

        public DynamicLoadingExample2Page(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public void StartLoading() => btnStart.Click();

        private void WaitForLoadingToFinish()
        {
            WebDriverWait wait = new WebDriverWait(_driver, System.TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(loadingBar));
        }

        public string GetInvisibleELementText()
        {
            WaitForLoadingToFinish();
            return txtHello.Text;
        }
    }
}
