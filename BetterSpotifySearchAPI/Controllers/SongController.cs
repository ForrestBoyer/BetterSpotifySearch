

using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Web;
using System.Text;
using Newtonsoft.Json.Linq;

namespace BetterSpotifySearchAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SongController : ControllerBase
    {
        private readonly IAccessService _accessService;

        public SongController(IAccessService accessService){
            _accessService = accessService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Songs(string? name)
        {
            string? sharedInfo = _accessService.GetAccessToken();
            return Ok(sharedInfo);
        }
    }
}
