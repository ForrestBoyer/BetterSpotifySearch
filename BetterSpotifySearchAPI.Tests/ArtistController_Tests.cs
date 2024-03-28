using BetterSpotifySearchAPI.Controllers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
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

    [Fact]
    public async void NameSearchReturnsQueen()
    {
        var accessService = new AccessService();

        var controller = new ArtistController(accessService);

        var response = await controller.Search("queen");
        var castResponse = response as OkObjectResult;
        var responseContent = castResponse.Value as string;
        var jsonContent = JObject.Parse(responseContent);
        var name = jsonContent["artists"]["items"][0]["name"];

        Assert.Equal("Queen", name);
    }
}