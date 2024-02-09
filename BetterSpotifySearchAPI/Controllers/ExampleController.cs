using Microsoft.AspNetCore.Mvc;

namespace BetterSpotifySearchAPI.Controllers
{
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
        public List<int> GetRandomNumbers(int count)
        {
            List<int> numbers = new List<int>();
            for (int i = 0; i < count; i++)
            {
                numbers.Add(Random.Shared.Next());
            }
            return numbers;
        }
    }
}
