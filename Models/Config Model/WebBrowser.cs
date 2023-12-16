namespace DotNetTestingFramework.Models.Config_Model
{
    public class WebBrowser
    {
        public bool IsHeadless { get; set; }
        public bool IsPrivate { get; set; }
        public string BrowserName { get; set; }

        public WebBrowser()
        {
            IsHeadless = true;
            IsPrivate = true;
            BrowserName = "Chrome";
        }
    }
}
