
using NUnit.Framework;
using OpenQA.Selenium;

namespace BankTestAutomation.LoginTest
{
    [TestFixture]
    public class LoginTests : BaseTest
    {
        // private IWebDriver driver;
        // private LoginPage loginPage;
        private HomePage homePage;


        [Test]
        public void ValidLoginTest()
        {
            // loginPage.LoginAs("mngr623805", "nUpevAz");
            homePage = new HomePage(driver);
            PerformLogin("mngr623805", "nUpevAz");
            Assert.That(homePage.isSuccessfulLogin(), Is.True);
        }
        [Test]
        public void InValidLoginTest()
        {
            // loginPage.LoginAs("mngrXXXX", "invalidPassword");
            PerformLogin("mngrXXXX", "invalidPassword");
            IAlert alert = driver.SwitchTo().Alert();
            Assert.That(alert.Text, Is.EqualTo("User or Password is not valid"));
            alert.Accept();
        }

    }
}