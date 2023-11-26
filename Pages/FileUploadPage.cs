using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace DotNetTestingFramework.Pages
{
    internal class FileUploadPage
    {

        private IWebDriver _driver;
        [FindsBy(How = How.Id, Using = "file-upload")]
        private IWebElement? btnFileUploader;

        [FindsBy(How = How.Id, Using = "file-submit")]
        private IWebElement? btnUpload;

        [FindsBy(How = How.Id, Using = "uploaded-files")]
        private IWebElement? uploadedFiles;

        [FindsBy(How = How.CssSelector, Using = "#content > div > h3")]
        private IWebElement? lblHeader;


        public FileUploadPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public void SelectFileToUpload() => btnFileUploader.SendKeys(Path.Combine(Directory.GetCurrentDirectory(), "Resources", "UploadFile.txt"));

        public void UploadFile() => btnUpload.Click();

        public string GetHeaderText() => lblHeader.Text;

        public string GetUploadedFileName() => uploadedFiles.Text;

    }
}
