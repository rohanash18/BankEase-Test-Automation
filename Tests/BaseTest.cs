
using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Utilities.ReportManager;

public class BaseTest
{
    protected ExtentReports extent;
    protected ExtentTest test;
    protected IWebDriver driver;
    protected LoginPage loginPage;
    [OneTimeSetUp]
    public void SetupReporting()
    {
        extent = ReportManager.GetInstance();
    }

    [SetUp]
    public void SetUp()
    {
        driver = new ChromeDriver();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        driver.Manage().Window.Maximize();
        driver.Navigate().GoToUrl("https://demo.guru99.com/V4/");
        loginPage = new LoginPage(driver);
        test = extent.CreateTest(TestContext.CurrentContext.Test.Name);

    }
    protected void PerformLogin(string username, string password)
    {
        loginPage.LoginAs(username, password);
    }
    [TearDown]
    public void TearDown()
    {
        driver.Quit();
        var status = TestContext.CurrentContext.Result.Outcome.Status;
        var stacktrace = TestContext.CurrentContext.Result.StackTrace;

        switch (status)
        {

            case NUnit.Framework.Interfaces.TestStatus.Failed:
                test.Fail("Test Failed").Log(Status.Fail, stacktrace);
                string screenshotPath = ScreenshotHelper.CaptureScreenshot(driver, TestContext.CurrentContext.Test.Name);
                test.Fail("Test Failed")
                .AddScreenCaptureFromPath(screenshotPath)
                .Log(Status.Fail, stacktrace);
                break;
            case NUnit.Framework.Interfaces.TestStatus.Passed:
                test.Pass("Test Passed");
                break;
            default:
                test.Skip("Test Skipped");
                break;

        }
    }
    [OneTimeTearDown]
    public void TearDownReporting()
    {
        extent.Flush();
    }
}