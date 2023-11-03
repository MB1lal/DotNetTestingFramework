using DotNetTestingFramework.Pages;
using DotNetTestingFramework.Utils;

namespace DotNetTestingFramework.Tests.SeleniumTests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    internal class SeleniumTest : BaseSteps
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
            extentReporting.AddTestCase("Verfiy google home page loads successfully");
            try
            {
                _googleHomePage = new GoogleHomePage(Constants.SessionVariables.Driver);
                extentReporting.LogStatusInReport(info, "Google homepage is loading");
                Assert.IsTrue(_googleHomePage.PageHasLogo());
                extentReporting.LogStatusInReport(pass, "Google home page loaded successfully");
            } catch (Exception ex)
            {
                extentReporting.LogStatusInReport(fail, ex.ToString());
                throw;
            }
           
        }

        [Test]
        [Ignore("Ignoring this test as it's pretty much deprecated")]
        [Category("IMDB"), Category("Selenium")]
        public void GettingCastFromIMDB()
        {
            extentReporting.AddTestCase("Getting cast from IMDB");
           try
            {
                _excelSheet = _excelReader.getFullExcelSheet("Input");
                extentReporting.LogStatusInReport(info, "Fetched excel sheet data");

                //Searching on google
                extentReporting.LogStatusInReport(info, "Navigating to google homepage");
                _googleHomePage = new GoogleHomePage(Constants.SessionVariables.Driver);
                _googleHomePage.SwitchToEnglish();
                extentReporting.LogStatusInReport(info, "Searching for " + _excelSheet["Search String 1"]);
                _googleHomePage.EnterSearchText(_excelSheet["Search String 1"]);
                extentReporting.LogStatusInReport(info, "Clicking on search button");
                _googleHomePage.ClickSearchButton();

                //Clicking on serach results
                _googleSearchPage = new GoogleSearchPage();
                Assert.IsTrue(_googleSearchPage.SearchPageIsLoaded());
                extentReporting.LogStatusInReport(info, "Search results are loaded");
                extentReporting.LogStatusInReport(info, "Opening searhc results using partial link text = " + _excelSheet["Search String 2"]);
                _googleSearchPage.OpenLinkInNewTabUsingPartialText(_excelSheet["Search String 2"]);

                //IMDB actions
                _iMDBItemPage = new IMDBItemPage();
                Assert.IsTrue(_iMDBItemPage.IsPageLoaded());
                extentReporting.LogStatusInReport(info, "IMDB page is loaded");
                extentReporting.LogStatusInReport(info, "Scrolling down to 'All cast & crew'");
                _iMDBItemPage.ScrollDownToElement("All cast & crew");
                extentReporting.LogStatusInReport(info, "Clicking on 'All cast & crew'");
                _iMDBItemPage.ClickScrolledElement("All cast & crew");
                extentReporting.LogStatusInReport(info, "Fetching cast table data");
                List<List<string>> list = _iMDBItemPage.GetCastTableData();

                //Writing back to excel
                extentReporting.LogStatusInReport(info, "Writing to excel sheet under workbook 'Series Cast'");
                _excelWriter.WriteToExcelSheet(list, "Series Cast");
                extentReporting.LogStatusInReport(info, "Saving excel file");
                _excelWriter.SaveFile();
                extentReporting.LogStatusInReport(pass, "Excel file saved");
            } catch (Exception ex)
            {
                extentReporting.LogStatusInReport(fail, ex.ToString());
                throw;
            }
        }

    }
}