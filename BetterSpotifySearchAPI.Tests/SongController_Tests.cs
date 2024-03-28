using BetterSpotifySearchAPI.Controllers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
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
    public async void SearchByFeatureResultMatches()
    {
        var accessService = new AccessService();
        var controller = new SongController(accessService);

        var response = await controller.SearchBy(null, "hip-hop", null, null, null, null, null, null, 0.911,
                                                 null, null, null, null, null, 0.566, null, null, null, 
                                                 null, null, null, null, null, null, null, null, null, 
                                                 null, null, null, null, null, null, null, null, 0.135,
                                                 null, null, 150, null, null, null, null, null, null);
        var castResponse = response as OkObjectResult;
        var responseContent = castResponse.Value as string;
        var jsonContent = JObject.Parse(responseContent);
        var name = jsonContent["tracks"][0]["name"];

        Assert.Equal("Leave Me", name);
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
    public async void NameSearchReturnsSacrifices()
    {
        var accessService = new AccessService();

        var controller = new SongController(accessService);

        var response = await controller.Search("sacrifices");
        var castResponse = response as OkObjectResult;
        var responseContent = castResponse.Value as string;
        var jsonContent = JObject.Parse(responseContent);
        var name = jsonContent["tracks"]["items"][0]["name"];

        Assert.Equal("Sacrifices (with EARTHGANG & J. Cole feat. Smino & Saba)", name);
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

    [Fact]
    public async void HumbleFeaturesCorrect()
    {
        var accessService = new AccessService();

        var controller = new SongController(accessService);

        var response = await controller.Features("131OLY5J8XyfGuSjXRiTRM");
        var castResponse = response as OkObjectResult;
        var responseContent = castResponse.Value as string;
        var jsonContent = JObject.Parse(responseContent);
        var tempo = jsonContent["tempo"];

        Assert.Equal(150.039, tempo);
    }
}
