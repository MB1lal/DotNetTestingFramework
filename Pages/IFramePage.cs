using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace DotNetTestingFramework.Pages
{
    internal class IFramePage
    {
        private readonly IWebDriver _driver;

        [FindsBy(How = How.Id, Using = "mce_0_ifr")]
        private readonly IWebElement? iFrameWithText;

        [FindsBy(How = How.Id, Using = "tinymce")]
        private readonly IWebElement? txtContent;

        public IFramePage(IWebDriver driver)
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
