using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Web;
using System.Text;
using Newtonsoft.Json.Linq;

namespace BetterSpotifySearchAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ArtistController : ControllerBase
    {
        private readonly IAccessService _AccessService;

        public ArtistController(IAccessService accessService){
            _AccessService = accessService;
        }

        [HttpGet]
        public async Task<IActionResult> SharedServiceTest()
        {
            return(Ok(_AccessService.GetTestToken()));
        }

        [HttpGet]
        [Route("{name}/{offset?}")]
        public async Task<IActionResult> Artists(string? name, int? offset)
        {
            using HttpClient httpClient = new HttpClient();
            string? _accessToken = _AccessService.GetAccessToken();

            if(name == null)
            {
                return BadRequest("No search value");
            }
            StringBuilder requestBuilder = new StringBuilder("https://api.spotify.com/v1/search?");
            requestBuilder.Append("q=" + Uri.EscapeDataString(name));
            requestBuilder.Append("&type=artist");
            requestBuilder.Append("&limit=10");
            if(offset != null)
            {
                requestBuilder.Append("&offset=" + offset);
            }
            string requestString = requestBuilder.ToString();

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestString);
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);

            var response = await httpClient.SendAsync(requestMessage);
            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return Ok(content);
            }
            return BadRequest(response.ReasonPhrase);
        }
    }
}
