
using NUnit.Framework;

namespace BankTestAutomation.NewAccountTest
{
    [TestFixture , Order(2)]
    public class NewAccountTests : BaseTest
    {
        private NewAccountPage naPage;
        [Test]
        public void FillNewAccountForm()
        {
            naPage = new NewAccountPage(driver);
            PerformLogin("mngr623805", "nUpevAz");
            naPage.NavigateToNewAccount();
            naPage.FillNewAccForm("18731", "Savings", "1500");
            Assert.That(naPage.ValidateSuccessfulRegistration(), Is.True);
            Console.WriteLine(naPage.FetchAccId());
        }

    }
}