using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace BetterSpotifySearchAPI.Spotify
{
    public static class Authentication
    {
        private static string _clientId = "f24bda7bd0e44ac6a10e845139620932";
        private static string _clientSecret = "1d9f0a52840f4a5bac26fa90bb93a59d";

        public static void Authorize()
        {

        }

        public static string GetAuthorizationUrl()
        {
            string scopes = "user-read-private user-read-email";
            string state = "bababooey";
            string redirectUri = "http://localhost/40080/api/example/getrandomnumber";
            string authorizeUrl = $"https://accounts.spotify.com/authorize?response_type=code&client_id={_clientId}&scope={Uri.EscapeDataString(scopes)}&redirect_uri={Uri.EscapeDataString(redirectUri)}&state={state}";
            return authorizeUrl;
        }

        // public static string GetAccessToken(string authorizationCode)
        // {
        //     using HttpClient httpClient = new HttpClient();

        //     var requestMessage = new HttpRequestMessage(HttpMethod.Post, "https://accounts.spotify.com/api/token");
        //     requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_clientId}:{_clientSecret}")));
        //     requestMessage.Content = new FormUrlEncodedContent(new Dictionary<string>
        //     {
        //         { "grant_type",  },
        //         {  },
        //         {  }
        //     });
        // }
    }
}