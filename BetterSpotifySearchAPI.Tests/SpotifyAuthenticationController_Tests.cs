using BetterSpotifySearchAPI.Controllers;
using Moq;

namespace BetterSpotifySearchAPI.Tests;

public class SpotifyAuthenticationController_Tests
{
    [Fact]
    public void TestGetAuthorizationUrl()
    {
        var accessService = new Mock<IAccessService>();

        var controller = new SpotifyAuthenticationController(accessService.Object);

        
    }
}
cache-dependency-path: BetterSpotifySearch/package-lock.json