using BetterSpotifySearchAPI.Controllers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BetterSpotifySearchAPI.Tests;

public class SongController_Tests
{
    [Fact]
    public async void TestSongsNotNull()
    {
        var accessService = new Mock<IAccessService>();

        var controller = new SongController(accessService.Object);

        var songs = await controller.Search("Sacrifices");

        Assert.NotNull(songs);
    }

    [Fact]
    public async void EmptyCriteriaSearchIsBad()
    {
        var accessService = new Mock<IAccessService>();

        var controller = new SongController(accessService.Object);

        var response = await controller.SearchBy(null, null, null, null, null, null, null, null, null,
                                                 null, null, null, null, null, null, null, null, null, 
                                                 null, null, null, null, null, null, null, null, null, 
                                                 null, null, null, null, null, null, null, null, null,
                                                 null, null, null, null, null, null, null, null, null);
        string? responseContent;
        var castResponse = (BadRequestObjectResult)response;
        responseContent = castResponse.Value.ToString();

        Assert.Equal("No search criteria", responseContent);
    }

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

    [Fact]
    public async void EmptyGetFeaturesBad()
    {
        var accessService = new Mock<IAccessService>();

        var controller = new SongController(accessService.Object);

        var response = await controller.Features(null);

        string? responseContent;
        var castResponse = (BadRequestObjectResult)response;
        responseContent = castResponse.Value.ToString();

        Assert.Equal("No song given", responseContent);
    }
}
