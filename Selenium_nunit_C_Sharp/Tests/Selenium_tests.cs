using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ReportPortal.Shared;
using System;
using System.Drawing.Imaging;

namespace Example.Tests
{
    [TestFixture]
    class Selenium_test
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void BeforeTestSuit() { }

        [OneTimeTearDown]
        public void AfterTestSuit() { }

        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver();
        }

        [TearDown]
        public void EndTest()
        {
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            var filePath = TestContext.CurrentContext.TestDirectory + "\\tmp.png";
            screenshot.SaveAsFile(filePath, ScreenshotImageFormat.Png);
            Bridge.LogMessage(ReportPortal.Client.Models.LogLevel.Info, "screenshot {rp#file#" + filePath + "}");
            driver.Quit();
        }

        [Test]
        [Category("T1")]
        public void Test_1_Passed()
        {
            Bridge.LogMessage(ReportPortal.Client.Models.LogLevel.Trace, "This is message for test 1");
            driver.Url = "https://shinkairyuu.github.io/Selenium_test_page/";
            Assert.AreEqual("SELENIUM TEST PAGE INDEX", driver.Title);
        }

        [Test]
        public void Test_2_Failed()
        {
            Bridge.LogMessage(ReportPortal.Client.Models.LogLevel.Trace, "This is message for test 2");
            driver.Url = "https://shinkairyuu.github.io/Selenium_test_page/";
            Assert.AreEqual("SELENIUM TEST PAGE INDEX2", driver.Title);
        }

        [Test]
        [Ignore("Ignore a test")]
        public void Test_3_Ignored()
        {
            Bridge.LogMessage(ReportPortal.Client.Models.LogLevel.Trace, "This is message for test 2");
            driver.Url = "https://shinkairyuu.github.io/Selenium_test_page/";
            Assert.AreEqual("SELENIUM TEST PAGE INDEX", driver.Title);
        }
    }
}

