
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BankTestAutomation.LoginTest
{
    [TestFixture , Order(1) , Category("UI") , Category("Smoke") , Category("Regression")]
    public class LoginTests : BaseTest
    {
        // private IWebDriver driver;
        // private LoginPage loginPage;
        private HomePage homePage;


        [Test, Order(1)]
        public void ValidLoginTest()
        {
            try
            {
                // loginPage.LoginAs("mngr623805", "nUpevAz");
                homePage = new HomePage(driver);
                PerformLogin("mngr623805", "nUpevAz");
                test.Info("Logging in with credentials");
                Assert.That(homePage.isSuccessfulLogin(), Is.True);
                test.Pass("Successfully Logged in");
            }
            catch(Exception e)
            {
                test.Fail("Test Failed : " + e.Message);
            }
        }
        [Test, Order(2)]
        public void InValidLoginTest()
        {
            try
            {
                // loginPage.LoginAs("mngrXXXX", "invalidPassword");
                PerformLogin("mngrXXXX", "invalidPassword");
                test.Info("Called Perform Login");
                //IAlert alert = driver.SwitchTo().Alert();


                WebDriverWait wait = new(driver, TimeSpan.FromSeconds(5));
                IAlert alert = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
                
                Assert.That(alert.Text, Is.EqualTo("User or Password is not valid"));
                test.Pass("Invalid Login test successful");
                alert.Accept();
            }
            catch (Exception e)
            {
                test.Fail("Test Failed : " + e.Message);
            }
        }

    }
}