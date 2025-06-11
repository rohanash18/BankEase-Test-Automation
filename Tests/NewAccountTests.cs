
using NUnit.Framework;

namespace BankTestAutomation.NewAccountTest
{
    [TestFixture , Order(2), Category("UI") , Category("Regression")]
    public class NewAccountTests : BaseTest
    {
        private NewAccountPage naPage;
        [Test]
        public void FillNewAccountForm()
        {
            try
            {
                naPage = new NewAccountPage(driver);
                PerformLogin("mngr623805", "nUpevAz");
                test.Info("Perform Login called");
                naPage.NavigateToNewAccount();
                test.Info("Navigated to new Account section");
                naPage.FillNewAccForm("18731", "Savings", "1500");
                test.Info("Filled in Details");
                Assert.That(naPage.ValidateSuccessfulRegistration(), Is.True);
                test.Pass("New Account created successfully");
                Console.WriteLine(naPage.FetchAccId());
            }
            catch (Exception e)
            {
                test.Fail("Test Failed : " + e.Message);
            }
        }

    }
}