using DotNetTestingFramework.Tests.Core;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace DotNetTestingFramework.Pages
{
    internal class HerokuHomePage : BaseSteps
    {
        private string _url = Constants.SessionVariables.Config.urls.herokuURL;

        [FindsBy(How = How.LinkText, Using = "Form Authentication")]
        private IWebElement _formAuthentiation;

        [FindsBy(How = How.LinkText, Using = "Checkboxes")]
        private IWebElement _checkboxesPage;

        [FindsBy(How = How.LinkText, Using = "Dropdown")]
        private IWebElement _dropdownPage;

        [FindsBy(How = How.LinkText, Using = "Dynamic Loading")]
        private IWebElement _dynamicLoadingPage;

        [FindsBy(How = How.LinkText, Using = "File Download")]
        private IWebElement _fileDownloadPage;

        [FindsBy(How = How.LinkText, Using = "File Upload")]
        private IWebElement _fileUploadPage;

        [FindsBy(How = How.LinkText, Using = "Frames")]
        private IWebElement _framesPage;

        [FindsBy(How = How.LinkText, Using = "Hovers")]
        private IWebElement _hoversPage;

        [FindsBy(How = How.LinkText, Using = "JavaScript Alerts")]
        private IWebElement _javaScriptAlertsPage;

        [FindsBy(How = How.LinkText, Using = "Multiple Windows")]
        private IWebElement _multiWindowPage;

        [FindsBy(How = How.LinkText, Using = "Notification Messages")]
        private IWebElement _notificationMessages;
        
        public HerokuHomePage(IWebDriver webDriver)
        {
            PageFactory.InitElements(webDriver, this);
            webDriver.Navigate().GoToUrl(_url);
        }

        public void NavigateToPage(string pageName)
        {
            switch(pageName.ToLower())
            {
                case "form authentication":
                    _formAuthentiation.Click();
                    break;
                case "checkboxes":
                    _checkboxesPage.Click();
                    break;
                case "dropdown":
                    _dropdownPage.Click();
                    break;
                case "dynamic loading":
                    _dynamicLoadingPage.Click();
                    break;
                case "file download":
                    _fileDownloadPage.Click();
                    break;
                case "file upload":
                    _fileUploadPage.Click();
                    break;
                case "frames":
                    _framesPage.Click();
                    break;
                case "hovers":
                    _hoversPage.Click();
                    break;
                case "javascript alerts":
                    _javaScriptAlertsPage.Click();
                    break;
                case "multiple windows":
                    _multiWindowPage.Click();
                    break;
                case "notification messages":
                    _notificationMessages.Click();
                    break;
                default:
                    logger.Error("Invalid page specified");
                    throw new ArgumentException("Invalid page specified");
            }
        }
    
    }
}
