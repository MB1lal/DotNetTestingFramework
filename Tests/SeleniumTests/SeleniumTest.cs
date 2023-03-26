using DotNetTestingFramework.Pages;
using DotNetTestingFramework.Utils;

namespace DotNetTestingFramework.Tests.SeleniumTests
{
    [TestFixture]
    [Category("Selenium")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class SeleniumTest : Hooks
    {
        private GoogleHomePage _googleHomePage;
        private GoogleSearchPage _googleSearchPage;
        private IMDBItemPage _iMDBItemPage;

        private ExcelReader _excelReader = new ExcelReader();
        private ExcelWriter _excelWriter = new ExcelWriter();
        private Dictionary<string, string> _excelSheet;


        [Test]
        [Category("Google")]
        public void GooglePageLoads()
        {
            _googleHomePage = new GoogleHomePage(Constants.SessionVariables.Driver);
            Assert.IsTrue(_googleHomePage.PageHasLogo());
        }

        [Test]
        [Category("IMDB")]
        public void GettingCastFromIMDB()
        {
            _excelSheet = _excelReader.getFullExcelSheet("Input");

            //Searching on google
            _googleHomePage = new GoogleHomePage(Constants.SessionVariables.Driver);
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