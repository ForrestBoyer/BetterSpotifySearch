using BetterSpotifySearchAPI.Controllers;
using Moq;

namespace BetterSpotifySearchAPI.Tests;

public class SongController_Tests
{
    [Fact]
    public async void TestSongsNotNull()
    {
        var accessService = new Mock<IAccessService>();

        var controller = new SongController(accessService.Object);

        var songs = await controller.Songs("Sacrifices");

        Assert.NotNull(songs);
    }
}
