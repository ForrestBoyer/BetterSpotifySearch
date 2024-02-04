using Microsoft.AspNetCore.Mvc;

namespace BetterSpotifySearchAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class ExampleController : ControllerBase
{
    [HttpGet]
    public int GetRandomNumber()
    {
        return Random.Shared.Next();
    }

    [HttpGet]
    public int GetRandomNumber2()
    {
        return Random.Shared.Next();
    }
}
