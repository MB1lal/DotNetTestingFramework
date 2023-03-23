using DotNetTestingFramework.Pages;
using DotNetTestingFramework.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DotNetTestingFramework.Tests.SeleniumTests
{
    [TestFixture]
    public class SeleniumTest : Hooks
    {
        private GoogleHomePage googleHomePage;
        private GoogleSearchPage googleSearchPage;
        private ExcelReader excelReader = new ExcelReader();
        private Dictionary<string, string> excelSheet;


        [Test]
        [Category("Google")]
        [Ignore("Duplicate test")]
        public void GooglePageLoads()
        {
            googleHomePage = new GoogleHomePage(Constants.SessionVariables.driver);
            googleHomePage.PageHasLogo();
        }

        [Test]
        [Category("GoogleSearch")]
        [Ignore("Duplicate test")]
        public void SearchTextOnGoogle()
        {
            googleHomePage = new GoogleHomePage(Constants.SessionVariables.driver);
            googleHomePage.SwitchToEnglish();
            googleHomePage.EnterSearchText("Browser Stack");
            googleHomePage.ClickSearchButton();
        }

        [Test]
        [Category("IMDB")]
        public void GettingCastFromIMDB()
        {
            excelSheet = excelReader.getFullExcelSheet();
            String searchText = excelSheet["Search String 1"];
            Console.WriteLine(searchText);
            googleHomePage = new GoogleHomePage(Constants.SessionVariables.driver);
            googleHomePage.SwitchToEnglish();
            googleHomePage.EnterSearchText(searchText);
            googleHomePage.ClickSearchButton();

            googleSearchPage = new GoogleSearchPage();

        }

        [Test]
        public void test1()
        {
            
        }

    }
}