public interface IAccessService
{
    string? GetAccessToken();
    void SetAccessToken(string? token);
    string? GetTestToken();
    void SetTestToken(string? token);
}

public class AccessService : IAccessService
{
    private string? _accessToken;
    private string? _testToken;

    public string? GetAccessToken()
    {
        return _accessToken;
    }
    public void SetAccessToken(string? token)
    {
        _accessToken = token;
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