using AngleSharp.Dom;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DotNetTestingFramework.Pages
{
    internal class IMDBItemPage
    {
        private IWebDriver _driver;

        [FindsBy(How = How.Id, Using = "home_img")]
        private IWebElement _imdbLogo;

        //[FindsBy(How = How.Id, Using = "home_img")]
        // private IWebElement _imdblogo;

        private By _castTableRow = By.XPath("//*[@id='fullcredits_content']/table[3]/tbody/tr");

        public IMDBItemPage()
        {
            _driver = Constants.SessionVariables.Driver;
            PageFactory.InitElements(_driver, this);
        }

        public Boolean IsPageLoaded()
        {
            return _imdbLogo.Displayed;
        }

        public void ScrollDownToElement(string elementText)
        {
            IWebElement targetElement = _driver.FindElement(By.LinkText(elementText));
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", targetElement);
        }

        public void ClickScrolledElement(string _elementText)
        {
            IWebElement targetElement = _driver.FindElement(By.LinkText(_elementText));
            targetElement.Click();
        }

        public List<List<string>> GetCastTableData()
        {
            //Setting headers
            List<List<string>> _castDetails = new List<List<string>>();
            _castDetails.Add(new List<string>());
            _castDetails[0].Add("Name");
            _castDetails[0].Add("Screen Name");
            _castDetails[0].Add("Appearances");

            //Getting data from webpage
            List<IWebElement> _tableElements = _driver.FindElements(_castTableRow).ToList();
            List<string> rows = new List<string>();
            
            foreach (IWebElement element in _tableElements)
            {
                if(!element.GetAttribute("outerText").Equals(""))
                {
                    rows.Add(element.GetAttribute("outerText"));
                }
            }

            for (int j=0; j<rows.Count;j++)
            {
                _castDetails.Add(new List<string>());
                string[] _splitData = Regex.Split(rows[j], "[\t\n\r]");
                for (int i = 0; i < _splitData.Count(); i++)
                {
                    if (_splitData[i] is not "..." && _splitData[i] is not "") 
                    {
                        _castDetails[j+1].Add(_splitData[i].Trim());
                    }
                }
            }
            return _castDetails;
        }


    }
}
