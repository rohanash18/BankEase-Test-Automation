
using RestSharp;

public class ApiTestHelper
{
    private readonly RestClient client;
    private readonly string _apiKey = "reqres-free-v1";

    public ApiTestHelper(string baseURL)
    {
        client = new RestClient(baseURL);
    }
    public RestResponse Get(string endpoint)
    {
        var request = new RestRequest(endpoint, Method.Get);
        request.AddHeader("x-api-key", _apiKey);
        return client.Execute(request);
    }

    public RestResponse Post(string endpoint , object body)
    {
        var request = new RestRequest(endpoint, Method.Post);
        request.AddHeader("x-api-key", _apiKey);
        request.AddHeader("Content-Type", "application/json");
        request.AddJsonBody(body);
        return client.Execute(request);
    }
}