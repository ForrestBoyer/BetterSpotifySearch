public interface IAccessService
{
    string? GetAccessToken();
    void SetAccessToken(string? token);
}

public class AccessService : IAccessService
{
    private string? _accessToken;

    public string? GetAccessToken()
    {
        return _accessToken;
    }

    public void SetAccessToken(string? token)
    {
        _accessToken = token;
    }
}