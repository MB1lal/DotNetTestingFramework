﻿using DotNetTestingFramework.Tests.Core;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace DotNetTestingFramework.Pages
{
    internal class HerokuHomePage : BaseSteps
    {
        private readonly string _url = Constants.SessionVariables.Config.Urls.HerokuURL;
#pragma warning disable CS0649
        [FindsBy(How = How.LinkText, Using = "Form Authentication")]
        private readonly IWebElement _formAuthentiation;

        [FindsBy(How = How.LinkText, Using = "Checkboxes")]
        private readonly IWebElement _checkboxesPage;

        [FindsBy(How = How.LinkText, Using = "Dropdown")]
        private readonly IWebElement _dropdownPage;

        [FindsBy(How = How.LinkText, Using = "Dynamic Loading")]
        private readonly IWebElement _dynamicLoadingPage;

        [FindsBy(How = How.LinkText, Using = "File Download")]
        private readonly IWebElement _fileDownloadPage;

        [FindsBy(How = How.LinkText, Using = "File Upload")]
        private readonly IWebElement _fileUploadPage;

        [FindsBy(How = How.LinkText, Using = "Frames")]
        private readonly IWebElement _framesPage;

        [FindsBy(How = How.LinkText, Using = "Hovers")]
        private readonly IWebElement _hoversPage;

        [FindsBy(How = How.LinkText, Using = "JavaScript Alerts")]
        private readonly IWebElement _javaScriptAlertsPage;

        [FindsBy(How = How.LinkText, Using = "Multiple Windows")]
        private readonly IWebElement _multiWindowPage;

        [FindsBy(How = How.LinkText, Using = "Notification Messages")]
        private readonly IWebElement _notificationMessages;
#pragma warning restore CS0649
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public HerokuHomePage(IWebDriver webDriver)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            PageFactory.InitElements(webDriver, this);
            webDriver.Navigate().GoToUrl(_url);
        }

        public void NavigateToPage(string pageName)
        {
            switch (pageName.ToLower())
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
