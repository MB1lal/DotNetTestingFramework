using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace DotNetTestingFramework.Pages
{
    internal class IFramePage
    {
        private readonly IWebDriver _driver;
#pragma warning disable CS0649
        [FindsBy(How = How.Id, Using = "mce_0_ifr")]
        private readonly IWebElement iFrameWithText;

        [FindsBy(How = How.Id, Using = "tinymce")]
        private readonly IWebElement txtContent;
#pragma warning restore CS0649
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public IFramePage(IWebDriver driver)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            PageFactory.InitElements(driver, this);
            _driver = driver;
        }

        public void SwitchToIFrame() => _driver.SwitchTo().Frame(iFrameWithText);

        public void EnterTextIntoContent(string inputText)
        {
            txtContent.Clear();
            txtContent.SendKeys(inputText);
        }

        public string GetContentText() => txtContent.Text.Trim();

    }
}
