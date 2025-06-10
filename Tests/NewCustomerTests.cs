
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace BankTestAutomation.NewCustomerTest
{
    [TestFixture , Order(3) , Category("UI") , Category("Regression")]
    public class NewCustomerTests : BaseTest
    {
        // private IWebDriver driver;
        // private LoginPage loginPage;
        private NewCustomerPage ncPage;

        [Test]
        public void FillNewCustomerForm()
        {
            ncPage = new NewCustomerPage(driver);
            PerformLogin("mngr623805", "nUpevAz");
            var email = $"testuser{Guid.NewGuid().ToString().Substring(0, 5)}@example.com";
            ncPage.NavigateToNewCustomer();
            ncPage.FillCustomerForm("Ramesh Kumar", "male", "10051989", "34 parle vila", "Delhi", "NCR", "567473", "8789487567", email, "test1234");
            ncPage.SubmitForm();
            Assert.That(ncPage.validateSuccessfulRegistration(), Is.True);
            Console.WriteLine(ncPage.fetchCustomerId());
        }

    }
}