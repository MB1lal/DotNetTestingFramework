using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;

namespace DotNetTestingFramework.Pages
{
    internal class HoverPage
    {
        private IWebDriver _driver;

        private const string FirstUserSelector = ".figure:nth-child(3)";
        private const string SecondUserSelector = ".figure:nth-child(4)";
        private const string ThirdUserSelector = ".figure:nth-child(5)";

        [FindsBy(How = How.CssSelector, Using = FirstUserSelector)]
        private IWebElement _firstUser;

        [FindsBy(How = How.CssSelector, Using = SecondUserSelector)]
        private IWebElement _secondUser;

        [FindsBy(How = How.CssSelector, Using = ThirdUserSelector)]
        private IWebElement _thirdUser;

        private By profileName = By.CssSelector("h5");


        public HoverPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            _driver = driver;
        }

        public void HoverOverUserAvatar(string profile)
        {
            Actions actions = new Actions(_driver);
            switch(profile.ToLower())
            {
                case "first":
                    actions.MoveToElement(_firstUser).Perform();
                    break;

                case "second":
                    actions.MoveToElement(_secondUser).Perform();
                    break;

                case "third":
                    actions.MoveToElement(_thirdUser).Perform();
                    break;

                default:

                    throw new ArgumentException("Invalid user profile specified", nameof(profile));
            }
        }

        public string GetProfileText(int userId) => _driver.FindElements(profileName)[userId].Text;

    }
}
