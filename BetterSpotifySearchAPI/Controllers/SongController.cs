

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
        private readonly IAccessService _AccessService;

        public SongController(IAccessService AccessService){
            _AccessService = AccessService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Songs([FromBody] string? name)
        {
            string? sharedInfo = _AccessService.GetAccessToken();
            return Ok(sharedInfo);
        }
    }
}
