using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace DotNetTestingFramework.Pages
{
    internal class GoogleSearchPage
    {
        private IWebDriver _driver;
        [FindsBy(How = How.Id, Using = "search")]
        private IWebElement _searchdiv;


        public GoogleSearchPage()
        {
            _driver = Constants.SessionVariables.Driver;
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
            
            if(System.Environment.OSVersion.ToString().Contains("Mac"))
            {
                keys = Keys.Command + Keys.Enter;
            } else
            {
                keys = Keys.Control + Keys.Enter;
            }

            linktext.SendKeys(keys);
            _driver.SwitchTo().Window(_driver.WindowHandles[1]);    
         }
    }
}
