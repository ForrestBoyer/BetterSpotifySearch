using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json.Linq;

namespace BetterSpotifySearchAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SpotifyAuthenticationController : ControllerBase
    {
        private static readonly string _clientId = "f24bda7bd0e44ac6a10e845139620932";
        private static readonly string _clientSecret = "1d9f0a52840f4a5bac26fa90bb93a59d";
        private static readonly string _state = "bababooey";
        private static readonly string _scopes = "user-read-private user-read-email";
        private static readonly string _redirectUri = "http://localhost:40080/api/spotifyauthentication/confirmationcallback";

        public static bool Authenticed { get; set; } = false;
        public static string? AccessToken { get; set; }

        [HttpGet]
        public IActionResult Register()
        {
            string authorizationUrl = GetAuthorizationUrl();
            return Redirect(authorizationUrl);
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmationCallback(string code, string state)
        {
            string? accessToken = null;

            if (state == _state)
            {
                accessToken = await GetAccessToken(code);
            }

            if (accessToken != null)
            {
                AccessToken = accessToken;
                Authenticed = true;
                return Ok(accessToken);
            }
            else
            {
                return Unauthorized();
            }
        }

        public static async Task<string> GetAccessToken(string authorizationCode)
        {
            using HttpClient httpClient = new HttpClient();

            string encoded = $"{Uri.EscapeDataString(_redirectUri)}";

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "https://accounts.spotify.com/api/token");
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_clientId}:{_clientSecret}")));

            // Specifically do not URL encode the _redirectUrl in this step to match the URL registered with spotify
            var requestData = $"grant_type=authorization_code&code={Uri.EscapeDataString(authorizationCode)}&redirect_uri={_redirectUri}";
            var requestContent = new StringContent(requestData, Encoding.UTF8, "application/x-www-form-urlencoded");

            requestMessage.Content = requestContent;
            
            var response = await httpClient.SendAsync(requestMessage);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return GetAccessTokenFromJson(content);
            }
            else
            {
                return null;
            }
        }

        public static string GetAccessTokenFromJson(string jsonResponse)
        {
            var jsonObject = JObject.Parse(jsonResponse);
            return jsonObject["access_token"]?.ToString();
        }

        public static string GetAuthorizationUrl()
        {
            return $"https://accounts.spotify.com/authorize?response_type=code&client_id={_clientId}&scope={_scopes}&redirect_uri={Uri.EscapeDataString(_redirectUri)}&state={_state}";
        }
    }
}
