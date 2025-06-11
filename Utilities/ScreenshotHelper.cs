
using OpenQA.Selenium;

public static class ScreenshotHelper
{
    public static string CaptureScreenshot(IWebDriver driver, string screenshotName)
    {
        string projectRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"));
        string screenshotsDir = Path.Combine(projectRoot, "Reports", "Screenshots");


        string filePath = Path.Combine(screenshotsDir, $"{screenshotName}_{DateTime.Now:yyyyMMdd_HHmmss}.png");

        Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
        screenshot.SaveAsFile(filePath);

        return filePath;
    }
}
