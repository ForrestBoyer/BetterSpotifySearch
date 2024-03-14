using BetterSpotifySearchAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BetterSpotifySearchAPI.Tests;

public class SpotifyAuthenticationController_Tests
{
    [Fact]
    public void TestGetAuthorizationUrl()
    {
        var accessService = new Mock<IAccessService>();

        var controller = new SpotifyAuthenticationController(accessService.Object);

        Assert.NotNull(controller.Register());
    }

    [Fact]
    public async void TestConfirmationCallbackFailsWithIncorrectState()
    {
        var accessService = new Mock<IAccessService>();
        var controller = new SpotifyAuthenticationController(accessService.Object);

        var incorrectState = "incorrect";
        var code = "151523523";

        var result = await controller.ConfirmationCallback(code, incorrectState);

        Assert.IsType<UnauthorizedResult>(result);
    }
}
