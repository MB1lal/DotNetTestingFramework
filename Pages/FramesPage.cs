using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace DotNetTestingFramework.Pages
{
    internal class FramesPage
    {
        [FindsBy(How = How.LinkText, Using = "Nested Frames")]
        private readonly IWebElement? nestedFramesPage;

        [FindsBy(How = How.LinkText, Using = "iFrame")]
        private readonly IWebElement? iFramesPage;

        public FramesPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public void NavigateToXFramesPage(string page)
        {
            switch (page.ToLower())
            {
                case "iframe":
                    iFramesPage.Click();
                    break;

                case "nested frames":
                    nestedFramesPage.Click();
                    break;

                default:
                    throw new ArgumentException("Invalid page specified");
            }
        }
    }
}
