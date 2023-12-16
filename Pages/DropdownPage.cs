using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace DotNetTestingFramework.Pages
{
    internal class DropdownPage
    {
        private readonly IWebDriver _driver;
#pragma warning disable CS0649
        [FindsBy(How = How.Id, Using = "dropdown")]
        private readonly IWebElement dropdownElement;

        private readonly SelectElement dropdown;
#pragma warning restore CS0649

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public DropdownPage(IWebDriver driver)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
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
