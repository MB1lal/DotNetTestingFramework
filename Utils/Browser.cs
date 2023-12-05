using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace DotNetTestingFramework.Utils
{
    internal class Browser
    {
        private static IWebDriver GetChromeDriver(Boolean isHeadless, Boolean isPrivate)
        {
            ChromeOptions options = new();
            if (isHeadless)
            {
                options.AddArgument("--headless");
            }
            if (isPrivate)
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

        private static IWebDriver GetEdgeDriver(Boolean isHeadless, Boolean isPrivate)
        {
            EdgeOptions options = new();
            if (isHeadless)
            {
                options.AddArgument("--headless");
            }
            if (isPrivate)
            {
                options.AddArgument("--incognito");
            }
            options.AddArgument("--disable-gpu");
            return new EdgeDriver(options);
        }

        private static IWebDriver GetFirefoxDriver(Boolean isHeadless, Boolean isPrivate)
        {
            FirefoxOptions options = new();
            FirefoxProfile profile = new();

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

        public static IWebDriver GetWebDriver(string browserName, Boolean isHeadless, Boolean isPrivate)
        {
            return browserName.ToLower() switch
            {
                "chrome" => GetChromeDriver(isHeadless, isPrivate),
                "edge" => GetEdgeDriver(isHeadless, isPrivate),
                "firefox" => GetFirefoxDriver(isHeadless, isPrivate),
                _ => throw new ArgumentException("Incorrect browser specified"),
            };
        }
    }
}
