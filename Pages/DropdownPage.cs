using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace DotNetTestingFramework.Pages
{
    internal class DropdownPage
    {
        private IWebDriver _driver;

        [FindsBy(How = How.Id, Using = "dropdown")]
        private IWebElement? dropdownElement;

        private SelectElement dropdown;

        public DropdownPage(IWebDriver driver) 
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
            dropdown = new SelectElement(dropdownElement);
        }

        public void SetDropdownOption(string option)
        {
            dropdown.SelectByText(option);
        }

        public string GetSelectedOption() => dropdown.SelectedOption.Text;
    }
}
