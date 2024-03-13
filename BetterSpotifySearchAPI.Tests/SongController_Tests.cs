using BetterSpotifySearchAPI.Controllers;
using Moq;

namespace BetterSpotifySearchAPI.Tests;

public class SongController_Tests
{
    [Fact]
    public void TestSongsNotNull()
    {
        var accessService = new Mock<IAccessService>();

        var controller = new SongController(accessService.Object);

        var songs = controller.Songs("Sacrifices").Result;

        Assert.NotNull(songs);
    }
}
