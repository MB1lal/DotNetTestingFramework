using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace DotNetTestingFramework.Pages
{
    internal class FileUploadPage
    {
        [FindsBy(How = How.Id, Using = "file-upload")]
        private readonly IWebElement? btnFileUploader;

        [FindsBy(How = How.Id, Using = "file-submit")]
        private readonly IWebElement? btnUpload;

        [FindsBy(How = How.Id, Using = "uploaded-files")]
        private readonly IWebElement? uploadedFiles;

        [FindsBy(How = How.CssSelector, Using = "#content > div > h3")]
        private readonly IWebElement? lblHeader;


        public FileUploadPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public void SelectFileToUpload() => btnFileUploader.SendKeys(Path.Combine(Directory.GetCurrentDirectory(), "Resources", "UploadFile.txt"));

        public void UploadFile() => btnUpload.Click();

        public string GetHeaderText() => lblHeader.Text;

        public string GetUploadedFileName() => uploadedFiles.Text;

    }
}
