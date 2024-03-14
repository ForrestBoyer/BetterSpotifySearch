using BetterSpotifySearchAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Moq;

namespace BetterSpotifySearchAPI.Tests;

public class AccessService_Tests
{
    [Fact]
    public async void TestSongAccesService()
    {
        var accessService = new AccessService();
        var authController = new SpotifyAuthenticationController(accessService);
        var songController = new SongController(accessService);
        
        string token = "test0";

        var pushResult = authController.SharedServiceTest(token);
        var okPush = pushResult as OkObjectResult;
        Assert.NotNull(okPush);
        string? pushToken = okPush.Value as string;
        Assert.Equal(token, pushToken);

        var getResult = await songController.SharedServiceTest();

        var okResult = getResult as OkObjectResult;
        Assert.NotNull(okResult);
        string? returnToken = okResult.Value as string;

        Assert.Equal(token, returnToken);
    }

    [Fact]
    public async void TestArtistAccesService()
    {
        var accessService = new AccessService();
        var authController = new SpotifyAuthenticationController(accessService);
        var artistController = new ArtistController(accessService);
        
        string token = "test0";

        var pushResult = authController.SharedServiceTest(token);
        var okPush = pushResult as OkObjectResult;
        Assert.NotNull(okPush);
        string? pushToken = okPush.Value as string;
        Assert.Equal(token, pushToken);

        var getResult = await artistController.SharedServiceTest();

        var okResult = getResult as OkObjectResult;
        Assert.NotNull(okResult);
        string? returnToken = okResult.Value as string;

        Assert.Equal(token, returnToken);
    }
}
