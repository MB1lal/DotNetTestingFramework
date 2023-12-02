using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace DotNetTestingFramework.Pages
{
    public class DynamicLoadingPage
    {
        [FindsBy(How = How.PartialLinkText, Using = "Example 1")]
        private readonly IWebElement? example1;

        [FindsBy(How = How.PartialLinkText, Using = "Example 2")]
        private readonly IWebElement? example2;

        public DynamicLoadingPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public void ClickXExample(int exampleIndex)
        {
            if (exampleIndex == 1)
            {
                example1.Click();
            }
            if (exampleIndex == 2)
            {
                example2.Click();
            }
        }
    }
}
