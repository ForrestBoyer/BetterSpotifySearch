using BetterSpotifySearchAPI.Controllers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BetterSpotifySearchAPI.Tests;

public class ArtistController_Tests{
    [Fact]
    public async void EmptyNameSearchIsBad()
    {
        var accessService = new Mock<IAccessService>();

        var controller = new SongController(accessService.Object);

        var response = await controller.Search(null);

        string? responseContent;
        var castResponse = (BadRequestObjectResult)response;
        responseContent = castResponse.Value.ToString();

        Assert.Equal("No search value", responseContent);
    }
}