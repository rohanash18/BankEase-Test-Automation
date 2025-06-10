
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BankTestAutomation.LoginTest
{
    [TestFixture , Order(1)]
    public class LoginTests : BaseTest
    {
        // private IWebDriver driver;
        // private LoginPage loginPage;
        private HomePage homePage;


        [Test, Order(1)]
        public void ValidLoginTest()
        {
            // loginPage.LoginAs("mngr623805", "nUpevAz");
            homePage = new HomePage(driver);
            PerformLogin("mngr623805", "nUpevAz");
            Assert.That(homePage.isSuccessfulLogin(), Is.True);
        }
        [Test, Order(2)]
        public void InValidLoginTest()
        {
            // loginPage.LoginAs("mngrXXXX", "invalidPassword");
            PerformLogin("mngrXXXX", "invalidPassword");

            //IAlert alert = driver.SwitchTo().Alert();


            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(5));
            IAlert alert = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());

            Assert.That(alert.Text, Is.EqualTo("User or Password is not valid"));
            alert.Accept();
        }

    }
}