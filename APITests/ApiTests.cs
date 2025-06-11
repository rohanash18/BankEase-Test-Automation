
using AventStack.ExtentReports;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Utilities.ReportManager;

namespace BankTestAutomation.ApiTests
{
    [TestFixture, Order(4), Category("API"), Category("Smoke"), Category("Regression")]
    public class ApiTests
    {
        private ApiTestHelper apiHelper;
        private ExtentReports extent;
        private ExtentTest test;

        [OneTimeSetUp]
        public void SetUp()
        {
            extent = ReportManager.GetInstance();
        }

        [SetUp]
        public void Setup()
        {
            apiHelper = new ApiTestHelper("https://reqres.in/api");
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);

        }
        [Test]
        public void GetListOfUsers()
        {
            try
            {
                var response = apiHelper.Get("/users?page=2");
                Assert.That(response.IsSuccessful, Is.True, "GET request failed");
                test.Pass("GET request sent successfully");
                var content = JObject.Parse(response.Content);
                Assert.That(content["data"], Is.Not.Null, "No user data found");
                test.Pass("Fetched data sucessfully");
            }
            catch (Exception e)
            {
                test.Fail("Test Failed : " + e.Message);
            }
        }
        [Test]
        public void PostCreateUser()
        {
            try
            {
                var newUser = new
                {
                    name = "Rohan",
                    job = "SDET"
                };
                var response = apiHelper.Post("/users", newUser);
                Assert.That(response.IsSuccessful, Is.True, "POST request failed");
                test.Info("Post request sent.");

                var content = JObject.Parse(response.Content);
                Assert.That(content["name"].ToString(), Is.EqualTo("Rohan"));
                Assert.That(content["job"].ToString(), Is.EqualTo("SDET"));
                test.Pass("Verified new User successfully");
            }
            catch (Exception e)
            {
                test.Fail("Test failed : " + e.Message);
            }
        }
        [TearDown]
        public void AfterTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            if(status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                test.Fail("Test Failed.");
            }
        }
    }
}