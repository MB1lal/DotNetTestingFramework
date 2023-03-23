using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace DotNetTestingFramework.Pages
{
    public class GoogleHomePage
    {
        private IWebDriver _driver;
        private string _url = "https://www.google.com";

        [FindsBy(How = How.Name, Using = "q")]
        private IWebElement _searchTextBox;

        [FindsBy(How = How.Name, Using = "btnK")]
        private IWebElement _searchBtn;

        [FindsBy(How = How.ClassName, Using = "lnXdpd")]
        private IWebElement _pageLogo;

        [FindsBy(How = How.LinkText, Using = "English")]
        private IWebElement _englishElement;

        public GoogleHomePage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
            _driver.Navigate().GoToUrl(_url);
        }

        public void PageHasLogo()
        {
            Assert.IsTrue(_pageLogo.Displayed);
        }

        public void EnterSearchText(string searchText)
        {
            _searchTextBox.SendKeys(searchText);
        }

        public void ClickSearchButton()
        {
            _searchBtn.Click();
        }

        public void SwitchToEnglish()
        {
            if(_englishElement.Displayed)
            {
                _englishElement.Click();
            }
        }

    }
}

