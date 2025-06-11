
using NUnit.Framework;
// using OpenQA.Selenium;
// using OpenQA.Selenium.Chrome;
// using TechTalk.SpecFlow;

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
            try
            {
                ncPage = new NewCustomerPage(driver);
                PerformLogin("mngr623805", "nUpevAz");
                test.Info("Perform Login Called");
                var email = $"testuser{Guid.NewGuid().ToString().Substring(0, 5)}@example.com";
                ncPage.NavigateToNewCustomer();
                test.Info("Navigated to new customer page");
                ncPage.FillCustomerForm("Ramesh Kumar", "male", "10051989", "34 parle vila", "Delhi", "NCR", "567473", "8789487567", email, "test1234");
                ncPage.SubmitForm();
                test.Info("Filled in details and clicked submit");
                Assert.That(ncPage.validateSuccessfulRegistration(), Is.True);
                test.Pass("New customer created successfully");
                Console.WriteLine(ncPage.fetchCustomerId());
            }
            catch (Exception e)
            {
                test.Fail("Test Failed : " + e.Message);
            }
        }

    }
}