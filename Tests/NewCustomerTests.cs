
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

[TestFixture]
public class NewCustomerTests
{
    private IWebDriver driver;
    private LoginPage loginPage;
    private NewCustomerPage ncPage;
    [SetUp]
    public void SetUp()
    {
        driver = new ChromeDriver();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        driver.Manage().Window.Maximize();
        driver.Navigate().GoToUrl("https://demo.guru99.com/V4/");
        loginPage = new LoginPage(driver);
        ncPage = new NewCustomerPage(driver);
        loginPage.LoginAs("mngr623805", "nUpevAz");
    }
    
    [Test]
    public void FillNewCustomerForm()
    {
        var email = $"testuser{Guid.NewGuid().ToString().Substring(0, 5)}@example.com";
        ncPage.NavigateToNewCustomer();
        ncPage.FillCustomerForm("Ramesh Kumar", "male", "10051989", "34 parle vila", "Delhi", "NCR", "567473", "8789487567", email, "test1234");
        ncPage.SubmitForm();
        Assert.That(ncPage.validateSuccessfulRegistration(), Is.True);
        Console.WriteLine(ncPage.fetchCustomerId());
    }
    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}