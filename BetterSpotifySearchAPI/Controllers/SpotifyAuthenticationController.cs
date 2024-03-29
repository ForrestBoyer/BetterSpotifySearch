using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

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
        public static string? UserAccessToken { get; set; }
        private static string? RefreshToken { get; set; }
        private readonly IAccessService _AccessService;

        public SpotifyAuthenticationController(IAccessService AccessService){
            _AccessService = AccessService;
        }

        [HttpPost]
        [Route("{testToken}")]
        public IActionResult SharedServiceTest(string? testToken)
        {
            _AccessService.SetTestToken(testToken);
            return Ok(_AccessService.GetTestToken());
        }

        [HttpGet]
        public IActionResult Register()
        {
            string authorizationUrl = GetAuthorizationUrl();
            return Redirect(authorizationUrl);
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmationCallback(string code, string state)
        {
            string? userAccessToken = null;

            if (state == _state)
            {
                userAccessToken = await GetAccessToken(code, _AccessService);
            }

            if (userAccessToken != null)
            {
                UserAccessToken = userAccessToken;
                _AccessService.SetUserToken(userAccessToken);
                Authenticed = true;
                return Ok(userAccessToken);
            }
            else
            {
                return Unauthorized();
            }
        }

        public static async Task<string?> GetAccessToken(string authorizationCode, IAccessService _aService)
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
                string? newToken = GetRefreshTokenFromJson(content);
                if(newToken != null){
                    RefreshToken = newToken;
                }
                Task.Delay(new TimeSpan(1, 0, 0)).ContinueWith(async o => {UserAccessToken = await RefreshAccessToken(_aService);});
                return GetAccessTokenFromJson(content);
            }
            else
            {
                Console.WriteLine("Bad Response from RefreshAccessToken");
                return null;
            }
        }

        public static string? GetAccessTokenFromJson(string jsonResponse)
        {
            var jsonObject = JObject.Parse(jsonResponse);
            return jsonObject["access_token"]?.ToString();
        }

        public static string? GetRefreshTokenFromJson(string jsonResponse)
        {
            var jsonObject = JObject.Parse(jsonResponse);
            return jsonObject["refresh_token"]?.ToString();
        }

        public static async Task<string?> RefreshAccessToken(IAccessService _aService)
        {
            using HttpClient httpClient = new HttpClient();

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "https://accounts.spotify.com/api/token");
            requestMessage.Headers.Add(Convert.ToBase64String(Encoding.UTF8.GetBytes("content-type")), "application/x-www-form-urlencoded");
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_clientId}:{_clientSecret}")));
            string requestData = $"grant_type=refresh_token&refresh_token={Uri.EscapeDataString(RefreshToken)}";
            var requestContent = new StringContent(requestData, Encoding.UTF8, "application/x-www-form-urlencoded");
            requestMessage.Content = requestContent;

            var response = await httpClient.SendAsync(requestMessage);
            if(response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                string? newToken = GetRefreshTokenFromJson(content);
                if(newToken != null){
                    RefreshToken = newToken;
                }
                Task.Delay(new TimeSpan(1, 0, 0)).ContinueWith(async o => {UserAccessToken = await RefreshAccessToken(_aService);});
                _aService.SetUserToken(GetAccessTokenFromJson(content));
                return _aService.GetUserToken();
            }
            else
            {
                Console.WriteLine("Bad Response from RefreshAccessToken");
                return null;
            }
        }

        public static string GetAuthorizationUrl()
        {
            return $"https://accounts.spotify.com/authorize?response_type=code&client_id={_clientId}&scope={_scopes}&redirect_uri={Uri.EscapeDataString(_redirectUri)}&state={_state}";
        }
    }
}
