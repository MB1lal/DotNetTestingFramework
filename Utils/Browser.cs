using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DotNetTestingFramework.Utils
{
    internal class Browser
    {
        private IWebDriver _driver;

        private IWebDriver _getChromeDriver(Boolean isHeadless, Boolean isPrivate)
        {
            ChromeOptions options = new ChromeOptions();
            if(isHeadless)
            {
                options.AddArgument("--headless");
            }
            if(isPrivate)
            {
                options.AddArgument("--incognito");
            }
          
            options.AddArgument("--disable-download-notification");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--user-agent=Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/111.0.0.0 Safari/537.36");
            return new ChromeDriver(options);
        }
        public IWebDriver GetWebDriver(string browserName, Boolean isHeadless, Boolean isPrivate)
        {
            switch (browserName.ToLower())
            {
                case "chrome":
                    return _getChromeDriver(isHeadless, isPrivate);
               

                    default:
                    throw new ArgumentException("Incorrect browser specified");
            }
        }
    }
}
