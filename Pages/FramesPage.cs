using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace DotNetTestingFramework.Pages
{
    internal class FramesPage
    {
#pragma warning disable CS0649
        [FindsBy(How = How.LinkText, Using = "Nested Frames")]
        private readonly IWebElement nestedFramesPage;

        [FindsBy(How = How.LinkText, Using = "iFrame")]
        private readonly IWebElement iFramesPage;
#pragma warning restore CS0649
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public FramesPage(IWebDriver driver) => PageFactory.InitElements(driver, this);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

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
