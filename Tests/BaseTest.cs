
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class BaseTest
{
    protected IWebDriver driver;
    protected LoginPage loginPage;

    [SetUp]
    public void SetUp()
    {
        driver = new ChromeDriver();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        driver.Manage().Window.Maximize();
        driver.Navigate().GoToUrl("https://demo.guru99.com/V4/");
        loginPage = new LoginPage(driver);
       
    }
    protected void PerformLogin(string username , string password)
    {
        loginPage.LoginAs(username , password);
    }
    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}