using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace DotNetTestingFramework.Utils
{
    public class ExtentReporting
    {
       private static ExtentTest _extentTest;
       private static ExtentReports _extentReports;

        public void SetupReport()
        {
            _extentReports = new ExtentReports();
            var htmlReporter = new ExtentSparkReporter(Path.GetFullPath(@"..\..\..\Output\Reports\Report" + DateTime.Now.ToString("_MM_dd_yyyy_hh_mm") + ".html"));
            _extentReports.AttachReporter(htmlReporter);
        }

        public void AddTestCase(string testCaseName)
        {
            _extentTest = _extentReports.CreateTest(testCaseName);
        }

        public void LogStatusInReport(Status status, string message)
        {
            _extentTest.Log(status, message);
        }

        public void Flush()
        { _extentReports.Flush(); }
        
    }
}
