using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTestingFramework.Pages
{
    internal class GoogleSearchPage
    {
        private IWebDriver driver;
        [FindsBy(How = How.Id, Using = "search")]
        private IWebElement _searchdiv;


        public GoogleSearchPage()
        {
            driver = Constants.SessionVariables.Driver;
            PageFactory.InitElements(driver, this);
        }

        public Boolean SearchPageIsLoaded()
        {
            return _searchdiv.Displayed;
        }

        public void ClickPartialLinkText(string partiallinktext)
        { 
            driver.FindElement(By.PartialLinkText(partiallinktext)).Click();
        }

        public void OpenLinkInNewTabUsingPartialText(string partiallinktext)
        {

            IWebElement _linktext = driver.FindElement(By.PartialLinkText(partiallinktext));
            string keys;
            
            if(System.Environment.OSVersion.ToString().Contains("Mac"))
            {
                keys = Keys.Command + Keys.Enter;
            } else
            {
                keys = Keys.Control + Keys.Enter;
            }

            _linktext.SendKeys(keys);
            driver.SwitchTo().Window(driver.WindowHandles[1]);    
                
         }
       

    }
}
