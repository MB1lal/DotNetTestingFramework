using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;

namespace DotNetTestingFramework.Pages
{
    internal class HoverPage
    {
        private readonly IWebDriver _driver;

        private const string FirstUserSelector = ".figure:nth-child(3)";
        private const string SecondUserSelector = ".figure:nth-child(4)";
        private const string ThirdUserSelector = ".figure:nth-child(5)";
#pragma warning disable CS0649
        [FindsBy(How = How.CssSelector, Using = FirstUserSelector)]
        private readonly IWebElement _firstUser;

        [FindsBy(How = How.CssSelector, Using = SecondUserSelector)]
        private readonly IWebElement _secondUser;

        [FindsBy(How = How.CssSelector, Using = ThirdUserSelector)]
        private readonly IWebElement _thirdUser;
#pragma warning restore CS0649
        private readonly By profileName = By.CssSelector("h5");


#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public HoverPage(IWebDriver driver)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            PageFactory.InitElements(driver, this);
            _driver = driver;
        }

        public void HoverOverUserAvatar(string profile)
        {
            Actions actions = new(_driver);
            switch (profile.ToLower())
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
