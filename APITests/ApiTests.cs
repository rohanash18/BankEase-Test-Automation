
using Newtonsoft.Json.Linq;
using NUnit.Framework;

[TestFixture , Order(4) , Category("API") , Category("Smoke") , Category("Regression")]
public class ApiTests
{
    private ApiTestHelper apiHelper;

    [SetUp]
    public void Setup()
    {
        apiHelper = new ApiTestHelper("https://reqres.in/api");

    }
    [Test]
    public void GetListOfUsers()
    {
        var response = apiHelper.Get("/users?page=2");
        Assert.That(response.IsSuccessful, Is.True, "GET request failed");
        var content = JObject.Parse(response.Content);
        Assert.That(content["data"], Is.Not.Null, "No user data found");
    }
    [Test]
    public void PostCreateUser()
    {
        var newUser = new
        {
            name = "Rohan",
            job = "SDET"
        };
        var response = apiHelper.Post("/users", newUser);
        Assert.That(response.IsSuccessful, Is.True, "POST request failed");
        var content = JObject.Parse(response.Content);
        Assert.That(content["name"].ToString(), Is.EqualTo("Rohan"));
        Assert.That(content["job"].ToString(), Is.EqualTo("SDET"));
    }
}