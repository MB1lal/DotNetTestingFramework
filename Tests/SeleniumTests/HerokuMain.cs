using DotNetTestingFramework.Pages;
using DotNetTestingFramework.Tests.Core;


namespace DotNetTestingFramework.Tests.SeleniumTests
{
    internal class HerokuMain : BaseSteps
    { 
        public void NavigateToPage(string pageName)
        {
            HerokuHomePage herokuHomePage = new HerokuHomePage(driver);
            logger.Info("Navigating to " + pageName);
            herokuHomePage.NavigateToPage(pageName);
        }
    }
}
