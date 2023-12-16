using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace DotNetTestingFramework.Pages
{
    internal class NestedFramesPage
    {
        private readonly IWebDriver _driver;
#pragma warning disable CS0649
        [FindsBy(How = How.Name, Using = "frame-top")]
        private readonly IWebElement frameTop;

        [FindsBy(How = How.Name, Using = "frame-left")]
        private readonly IWebElement topLeftFrame;

        [FindsBy(How = How.Name, Using = "frame-right")]
        private readonly IWebElement topRightFrame;

        [FindsBy(How = How.Name, Using = "frame-middle")]
        private readonly IWebElement topMiddleFrame;

        [FindsBy(How = How.Name, Using = "frame-bottom")]
        private readonly IWebElement childBottomFrame;

        [FindsBy(How = How.CssSelector, Using = "body")]
        private readonly IWebElement frameText;
#pragma warning restore CS0649

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public NestedFramesPage(IWebDriver driver)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            PageFactory.InitElements(driver, this);
            _driver = driver;
        }

        private void SwitchToFrame(string frameId)
        {
            switch (frameId)
            {
                case "Top Left":
                    _driver.SwitchTo().Frame(topLeftFrame);
                    break;

                case "Top Middle":
                    _driver.SwitchTo().Frame(topMiddleFrame);
                    break;

                case "Top Right":
                    _driver.SwitchTo().Frame(topRightFrame);
                    break;

                case "Bottom":
                    _driver.SwitchTo().Frame(childBottomFrame);
                    break;
            }
        }

        private void NavigateToExpectedFrameLayer(string frameId)
        {
            if (frameId != "Bottom")
            {
                _driver.SwitchTo().Frame(frameTop);
            }
            SwitchToFrame(frameId);
        }

        public string GetFrameText(string frameId)
        {
            NavigateToExpectedFrameLayer(frameId);
            string frameText = this.frameText.Text;

            if (frameId != "Bottom")
            {
                _driver.SwitchTo().ParentFrame().SwitchTo().ParentFrame();
            }
            else
            {
                _driver.SwitchTo().ParentFrame();
            }
            return frameText;
        }

    }
}
