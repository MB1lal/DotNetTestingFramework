using DotNetTestingFramework.Pages;
using DotNetTestingFramework.Tests.Core;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;

namespace DotNetTestingFramework.Tests.SeleniumTests
{
    [TestFixture]
    [AllureNUnit]
    [AllureTag("@Heroku", "@FileUpload")]
    [Category("Selenium")]
    internal class FileUploadTests : BaseSteps
    {

        [TestCase(null, TestName = "Verifyt file is succesfully uploaded")]
        public void VerifyFileUpload(object? ignored)
        {
            NavigateToPage("File Upload");
            logger.Info("Uploading a file");
            FileUploadPage fileUploadPage = new FileUploadPage(driver);
            fileUploadPage.SelectFileToUpload();
            fileUploadPage.UploadFile();
            logger.Info("Verifying file is correctly uploaded");
            Assert.AreEqual("File Uploaded!", fileUploadPage.GetHeaderText(), "File not uploaded");
            Assert.AreEqual("UploadFile.txt", fileUploadPage.GetUploadedFileName(), "Correct file is not uploaded");
        }
    }
}
