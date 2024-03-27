using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json.Linq;

public interface IAccessService
{
    string? GetAccessToken();
    void SetAccessToken(string? token);
    string? GetTestToken();
    void SetTestToken(string? token);
    string? GetUserToken();
    void SetUserToken(string? token);
}

public class AccessService : IAccessService
{
    private static readonly string _clientId = "f24bda7bd0e44ac6a10e845139620932";
    private static readonly string _clientSecret = "1d9f0a52840f4a5bac26fa90bb93a59d";
    private string? _accessToken;
    private string? _userToken;
    private string? _testToken;
    public AccessService()
    {
        using HttpClient httpClient = new HttpClient();
        var requestMessage = new HttpRequestMessage(HttpMethod.Post, "https://accounts.spotify.com/api/token");
        requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_clientId}:{_clientSecret}")));

        var requestData = "grant_type=client_credentials";
        var requestContent = new StringContent(requestData, Encoding.UTF8, "application/x-www-form-urlencoded");
        requestMessage.Content = requestContent;

        var response = httpClient.Send(requestMessage);
        if(response.IsSuccessStatusCode)
        {
            string? responseContent = null;
            Task.Run(async () => responseContent = await response.Content.ReadAsStringAsync()).Wait();
            var jsonObject = JObject.Parse(responseContent);
            SetAccessToken(jsonObject["access_token"]?.ToString());
        }
        else
        {
            Console.WriteLine("Bad Response from AccessService Constructor");
        }
    }

    public string? GetAccessToken()
    {
        return _accessToken;
    }
    public void SetAccessToken(string? token)
    {
        _accessToken = token;
    }

    public string? GetUserToken()
    {
        return _userToken;
    }
    public void SetUserToken(string? token)
    {
        _userToken = token;
    }

    public string? GetTestToken()
    {
        return _testToken;
    }
    public void SetTestToken(string? token)
    {
        _testToken = token;
    }
}