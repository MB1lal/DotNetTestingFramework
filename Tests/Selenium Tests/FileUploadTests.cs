using DotNetTestingFramework.Pages;
using DotNetTestingFramework.Tests.Core;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;

namespace DotNetTestingFramework.Tests.Selenium_Tests
{
    [TestFixture, Description("Verify file uploading on Heroku Web App")]
    [AllureNUnit]
    [AllureTag("@Heroku", "@FileUpload")]
    [Category("Selenium")]
    internal class FileUploadTests : BaseSteps
    {

        [Test, Description("Verify file is succesfully uploaded")]
        public void VerifyFileUpload()
        {
            NavigateToPage("File Upload");
            logger.Info("Uploading a file");
            FileUploadPage fileUploadPage = new(driver);
            fileUploadPage.SelectFileToUpload();
            fileUploadPage.UploadFile();
            logger.Info("Verifying file is correctly uploaded");
            Assert.That(fileUploadPage.GetHeaderText, Is.EqualTo("File Uploaded!"), "File not uploaded");
            Assert.That(fileUploadPage.GetUploadedFileName(), Is.EqualTo("UploadFile.txt"), "Correct file is not uploaded");
        }
    }
}
