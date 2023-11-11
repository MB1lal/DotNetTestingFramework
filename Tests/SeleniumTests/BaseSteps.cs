using AventStack.ExtentReports;

namespace DotNetTestingFramework.Tests.SeleniumTests
{
    internal class BaseSteps : Hooks
    {
        

        protected Status info = AventStack.ExtentReports.Status.Info;
        protected Status error = AventStack.ExtentReports.Status.Error;
        protected Status pass = AventStack.ExtentReports.Status.Pass;
        protected Status warning = AventStack.ExtentReports.Status.Warning;
        protected Status fail = AventStack.ExtentReports.Status.Fail;

       

    }
}
