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
        private IMDBItemPage iMDBItemPage;

        private ExcelReader _excelReader = new ExcelReader();
        private ExcelWriter _excelWriter = new ExcelWriter();
        private Dictionary<string, string> excelSheet;


        [Test]
        [Category("Google")]
        [Ignore("Duplicate test")]
        public void GooglePageLoads()
        {
            googleHomePage = new GoogleHomePage(Constants.SessionVariables.Driver);
            Assert.IsTrue(googleHomePage.PageHasLogo());
        }

        [Test]
        [Category("GoogleSearch")]
        [Ignore("Duplicate test")]
        public void SearchTextOnGoogle()
        {
            googleHomePage = new GoogleHomePage(Constants.SessionVariables.Driver);
            googleHomePage.SwitchToEnglish();
            googleHomePage.EnterSearchText("Browser Stack");
            googleHomePage.ClickSearchButton();
        }

        [Test]
        [Category("IMDB")]
        public void GettingCastFromIMDB()
        {
            excelSheet = _excelReader.getFullExcelSheet();

            //Searching on google
            googleHomePage = new GoogleHomePage(Constants.SessionVariables.Driver);
            googleHomePage.SwitchToEnglish();
            googleHomePage.EnterSearchText(excelSheet["Search String 1"]);
            googleHomePage.ClickSearchButton();

            //Clicking on serach results
            googleSearchPage = new GoogleSearchPage();
            Assert.IsTrue(googleSearchPage.SearchPageIsLoaded());
            googleSearchPage.OpenLinkInNewTabUsingPartialText(excelSheet["Search String 2"]);

            //IMDB actions
            iMDBItemPage = new IMDBItemPage();
            Assert.IsTrue(iMDBItemPage.IsPageLoaded());
            iMDBItemPage.ScrollDownToElement("All cast & crew");
            iMDBItemPage.ClickScrolledElement("All cast & crew");
            List<List<string>> list = iMDBItemPage.GetCastTableData();

            //Writing back to excel
            _excelWriter.WriteToExcelSheet(list, "Series Cast");
            _excelWriter.SaveFile();
        }

        [Test]
        public void test1()
        {
            
        }

    }
}