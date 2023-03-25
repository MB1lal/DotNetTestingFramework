using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System.Text.RegularExpressions;

namespace DotNetTestingFramework.Pages
{
    internal class IMDBItemPage
    {
        private IWebDriver _driver;

        [FindsBy(How = How.Id, Using = "home_img")]
        private IWebElement _imdbLogo;

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

        public void ClickScrolledElement(string elementText)
        {
            By linkText = By.LinkText(elementText);
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementToBeClickable(linkText));

            IWebElement targetElement = _driver.FindElement(linkText);
            targetElement.Click();
        }

        public List<List<string>> GetCastTableData()
        {
            //Setting headers
            List<List<string>> castDetails = new List<List<string>>();
            castDetails.Add(new List<string>());
            castDetails[0].Add("Name");
            castDetails[0].Add("Screen Name");
            castDetails[0].Add("Appearances");

            //Getting data from webpage
            List<IWebElement> tableElements = _driver.FindElements(_castTableRow).ToList();
            List<string> rows = new List<string>();
            
            foreach (IWebElement element in tableElements)
            {
                if(!element.GetAttribute("outerText").Equals(""))
                {
                    rows.Add(element.GetAttribute("outerText"));
                }
            }

            for (int j=0; j<rows.Count;j++)
            {
                castDetails.Add(new List<string>());
                string[] splitData = Regex.Split(rows[j], "[\t\n\r]");
                for (int i = 0; i < splitData.Count(); i++)
                {
                    if (splitData[i] is not "..." && splitData[i] is not "") 
                    {
                        castDetails[j+1].Add(splitData[i].Trim());
                    }
                }
            }
            return castDetails;
        }
    }
}
