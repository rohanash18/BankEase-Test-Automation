
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

[TestFixture]
public class LoginTests
{
    private IWebDriver driver;
    private LoginPage loginPage;
    private HomePage homePage;

    [SetUp]
    public void SetUp()
    {
        driver = new ChromeDriver();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        driver.Manage().Window.Maximize();
        driver.Navigate().GoToUrl("https://demo.guru99.com/V4/");
        loginPage = new LoginPage(driver);
        homePage = new HomePage(driver);
    }
    [Test]
    public void ValidLoginTest()
    {
        loginPage.LoginAs("mngr623805", "nUpevAz");
        Assert.That(homePage.isSuccessfulLogin(), Is.True);
    }
    [Test]
    public void InValidLoginTest()
    {
        loginPage.LoginAs("mngrXXXX", "invalidPassword");
        IAlert alert = driver.SwitchTo().Alert();
        Assert.That(alert.Text, Is.EqualTo("User or Password is not valid"));
        alert.Accept();
    }
    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}