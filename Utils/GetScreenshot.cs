using OpenQA.Selenium;

namespace DotNetTestingFramework.Utils
{
    public class GetScreenshot
    {
        [Obsolete("Not being used currently in framework")]
        public static string Capture(IWebDriver driver, string screenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase!;
            string finalpth = pth[..pth.LastIndexOf("bin")] + "Output/Reports\\" + screenShotName + DateTime.Now.ToString("_dd_MM_yy") + ".png";
            string localpath = new Uri(finalpth).LocalPath;
            screenshot.SaveAsFile(localpath, ScreenshotImageFormat.Png);
            return localpath;
        }
    }
}
