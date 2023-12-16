using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace DotNetTestingFramework.Pages
{
    public class GoogleHomePage
    {
        private readonly string _url = "https://www.google.com";
#pragma warning disable CS0649
        [FindsBy(How = How.Name, Using = "q")]
        private readonly IWebElement _searchTextBox;

        [FindsBy(How = How.Name, Using = "btnK")]
        private readonly IWebElement _searchBtn;

        [FindsBy(How = How.ClassName, Using = "lnXdpd")]
        private readonly IWebElement _pageLogo;

        [FindsBy(How = How.LinkText, Using = "English")]
        private readonly IWebElement _englishElement;
#pragma warning restore CS0649
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public GoogleHomePage(IWebDriver driver)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            PageFactory.InitElements(driver, this);
            driver.Navigate().GoToUrl(_url);
        }

        public Boolean PageHasLogo()
        {
            return _pageLogo.Displayed;
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
            if (_englishElement.Displayed)
            {
                _englishElement.Click();
            }
        }

    }
}

