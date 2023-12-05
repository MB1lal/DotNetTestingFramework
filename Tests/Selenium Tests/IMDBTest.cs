using DotNetTestingFramework.Pages;
using DotNetTestingFramework.Tests.Core;
using DotNetTestingFramework.Utils;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;

namespace DotNetTestingFramework.Tests.Selenium_Tests
{
    [TestFixture, Description("Verifying cast from IMDB")]
    [AllureNUnit]
    [AllureTag("@Google", "@imdb")]
    [Category("Selenium")]
    [Ignore("Deprecated")]
    internal class IMDBTest : BaseSteps
    {
        private GoogleHomePage _googleHomePage;
        private GoogleSearchPage _googleSearchPage;
        private IMDBItemPage _iMDBItemPage;

        private Dictionary<string, string> _excelSheet;



        [Test]
        [Category("Google"), Category("Selenium")]
        public void GooglePageLoads()
        {
            logger.Info("Navigating to Google");
            _googleHomePage = new GoogleHomePage(driver);
            logger.Info("Asserting page is loaded");
            Assert.That(_googleHomePage.PageHasLogo(), Is.True);
        }

        [Test]
        [Category("IMDB")]
        [Ignore("Flaky")]
        public void GettingCastFromIMDB()
        {
            _excelSheet = ExcelReader.GetFullExcelSheet("Input");

            //Searching on google
            _googleHomePage = new GoogleHomePage(driver);
            _googleHomePage.SwitchToEnglish();
            _googleHomePage.EnterSearchText(_excelSheet["Search String 1"]);
            _googleHomePage.ClickSearchButton();

            //Clicking on serach results
            _googleSearchPage = new GoogleSearchPage();
            Assert.That(_googleSearchPage.SearchPageIsLoaded(), Is.True);
            _googleSearchPage.OpenLinkInNewTabUsingPartialText(_excelSheet["Search String 2"]);

            //IMDB actions
            _iMDBItemPage = new IMDBItemPage();
            Assert.That(_iMDBItemPage.IsPageLoaded(), Is.True);
            _iMDBItemPage.ScrollDownToElement("All cast & crew");
            _iMDBItemPage.ClickScrolledElement("All cast & crew");
            List<List<string>> list = _iMDBItemPage.GetCastTableData();

            //Writing back to excel
            ExcelWriter.WriteToExcelSheet(list, "Series Cast");
            ExcelWriter.SaveFile();
        }

    }
}