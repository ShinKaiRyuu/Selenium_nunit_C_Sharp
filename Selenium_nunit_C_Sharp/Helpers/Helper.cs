using OpenQA.Selenium;
using System;

namespace Selenium_nunit_C_Sharp.Helpers
{
    class Helper
    {
        public void TakeScreenshot(IWebDriver driver, String path)
        {
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            var filePath = path;
            screenshot.SaveAsFile(filePath, ScreenshotImageFormat.Png);
        }
    }
}
