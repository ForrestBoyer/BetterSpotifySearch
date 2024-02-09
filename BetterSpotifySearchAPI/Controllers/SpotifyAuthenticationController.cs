using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;

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

        [HttpGet]
        public IActionResult Register()
        {
            string authorizationUrl = GetAuthorizationUrl();
            return Redirect(authorizationUrl);
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmationCallback(string code, string state)
        {
            string? accessCode = null;

            if (state == _state)
            {
                accessCode = await GetAccessToken(code);
            }

            if (accessCode != null)
            {
                return Ok(accessCode);
            }
            else
            {
                return Unauthorized();
            }
        }

        public static async Task<string> GetAccessToken(string authorizationCode)
        {
            using HttpClient httpClient = new HttpClient();

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "https://accounts.spotify.com/api/token");
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_clientId}:{_clientSecret}")));
            requestMessage.Content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "grant_type", "authorization_code" },
                { "code", authorizationCode },
                { "redirect_url", _redirectUri }
            });

            var response = await httpClient.SendAsync(requestMessage);
            var content = await response.Content.ReadAsStringAsync();

            return content;
        }

        public static string GetAuthorizationUrl()
        {
            return $"https://accounts.spotify.com/authorize?response_type=code&client_id={_clientId}&scope={_scopes}&redirect_uri={Uri.EscapeDataString(_redirectUri)}&state={_state}";
        }
    }
}
