using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace DotNetTestingFramework.Pages
{
    internal class FileUploadPage
    {
#pragma warning disable CS0649
        [FindsBy(How = How.Id, Using = "file-upload")]
        private readonly IWebElement btnFileUploader;

        [FindsBy(How = How.Id, Using = "file-submit")]
        private readonly IWebElement btnUpload;

        [FindsBy(How = How.Id, Using = "uploaded-files")]
        private readonly IWebElement uploadedFiles;

        [FindsBy(How = How.CssSelector, Using = "#content > div > h3")]
        private readonly IWebElement lblHeader;
#pragma warning restore CS0649

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public FileUploadPage(IWebDriver driver) => PageFactory.InitElements(driver, this);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public void SelectFileToUpload() => btnFileUploader.SendKeys(Path.Combine(Directory.GetCurrentDirectory(), "Resources", "UploadFile.txt"));

        public void UploadFile() => btnUpload.Click();

        public string GetHeaderText() => lblHeader.Text;

        public string GetUploadedFileName() => uploadedFiles.Text;

    }
}
