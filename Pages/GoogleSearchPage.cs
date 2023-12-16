using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace DotNetTestingFramework.Pages
{
    internal class GoogleSearchPage
    {
        private readonly IWebDriver _driver;
#pragma warning disable CS0649
        [FindsBy(How = How.Id, Using = "search")]
        private readonly IWebElement _searchdiv;
#pragma warning restore CS0649

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public GoogleSearchPage(IWebDriver driver)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public Boolean SearchPageIsLoaded()
        {
            return _searchdiv.Displayed;
        }

        public void ClickPartialLinkText(string partiallinktext)
        {
            _driver.FindElement(By.PartialLinkText(partiallinktext)).Click();
        }

        public void OpenLinkInNewTabUsingPartialText(string partiallinktext)
        {

            IWebElement linktext = _driver.FindElement(By.PartialLinkText(partiallinktext));
            string keys;

            if (System.Environment.OSVersion.ToString().Contains("Mac"))
            {
                keys = Keys.Command + Keys.Enter;
            }
            else
            {
                keys = Keys.Control + Keys.Enter;
            }

            linktext.SendKeys(keys);
            _driver.SwitchTo().Window(_driver.WindowHandles[1]);
        }
    }
}
