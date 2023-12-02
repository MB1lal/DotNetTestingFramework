using DotNetTestingFramework.Pages;
using DotNetTestingFramework.Tests.Core;
using DotNetTestingFramework.Utils;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;

namespace DotNetTestingFramework.Tests.Selenium_Tests
{
    [TestFixture]
    [AllureNUnit]
    [AllureTag("@Google", "@imdb")]
    [Category("Selenium")]
    internal class IMDBTest : BaseSteps
    {
        private GoogleHomePage _googleHomePage;
        private GoogleSearchPage _googleSearchPage;
        private IMDBItemPage _iMDBItemPage;

        private ExcelReader _excelReader = new ExcelReader();
        private ExcelWriter _excelWriter = new ExcelWriter();
        private Dictionary<string, string> _excelSheet;



        [Test]
        [Category("Google"), Category("Selenium")]
        public void GooglePageLoads()
        {
            try
            {
                logger.Info("Navigating to Google");
                _googleHomePage = new GoogleHomePage(driver);
                logger.Info("Asserting page is loaded");
                Assert.IsTrue(_googleHomePage.PageHasLogo());
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        [Test]
        [Category("IMDB")]
        [Ignore("Flaky")]
        public void GettingCastFromIMDB()
        {
            _excelSheet = _excelReader.getFullExcelSheet("Input");

            //Searching on google
            _googleHomePage = new GoogleHomePage(driver);
            _googleHomePage.SwitchToEnglish();
            _googleHomePage.EnterSearchText(_excelSheet["Search String 1"]);
            _googleHomePage.ClickSearchButton();

            //Clicking on serach results
            _googleSearchPage = new GoogleSearchPage();
            Assert.IsTrue(_googleSearchPage.SearchPageIsLoaded());
            _googleSearchPage.OpenLinkInNewTabUsingPartialText(_excelSheet["Search String 2"]);

            //IMDB actions
            _iMDBItemPage = new IMDBItemPage();
            Assert.IsTrue(_iMDBItemPage.IsPageLoaded());
            _iMDBItemPage.ScrollDownToElement("All cast & crew");
            _iMDBItemPage.ClickScrolledElement("All cast & crew");
            List<List<string>> list = _iMDBItemPage.GetCastTableData();

            //Writing back to excel
            _excelWriter.WriteToExcelSheet(list, "Series Cast");
            _excelWriter.SaveFile();
        }

    }
}