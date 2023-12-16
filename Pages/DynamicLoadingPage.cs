using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace DotNetTestingFramework.Pages
{
    public class DynamicLoadingPage
    {
#pragma warning disable CS0649
        [FindsBy(How = How.PartialLinkText, Using = "Example 1")]
        private readonly IWebElement example1;

        [FindsBy(How = How.PartialLinkText, Using = "Example 2")]
        private readonly IWebElement example2;
#pragma warning restore CS0649
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public DynamicLoadingPage(IWebDriver driver) => PageFactory.InitElements(driver, this);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

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
