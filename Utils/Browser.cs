using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

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
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--remote-allow-origins=*");
            return new ChromeDriver(options);
        }

        private IWebDriver _getEdgeDriver(Boolean isHeadless, Boolean isPrivate) 
        {
            EdgeOptions options = new EdgeOptions();
            if(isHeadless)
            {
                options.AddArgument("--headless");
            }
            if(isPrivate)
            {
                options.AddArgument("--incognito");
            }
            options.AddArgument("--disable-gpu");
            return new EdgeDriver(options);
        }

        private IWebDriver _getFirefoxDriver(Boolean isHeadless, Boolean isPrivate)
        {
            FirefoxOptions options = new FirefoxOptions();
            FirefoxProfile profile = new FirefoxProfile();

            options.AddArgument("-window-size=1920x1080");

            if (isHeadless)
            {
                options.AddArgument("--headless");
            }

            if (isPrivate)
            {
                profile.SetPreference("browser.privatebrowsing.autostart", true);
            }
            options.Profile = profile;

            return new FirefoxDriver(options);
        }

        public IWebDriver GetWebDriver(string browserName, Boolean isHeadless, Boolean isPrivate)
        {
            switch (browserName.ToLower())
            {
                case "chrome":
                    return _getChromeDriver(isHeadless, isPrivate);

                case "edge":
                    return _getEdgeDriver(isHeadless, isPrivate);

                case "firefox":
                    return _getFirefoxDriver(isHeadless, isPrivate);

                default:
                    throw new ArgumentException("Incorrect browser specified");
            }
        }
    }
}
