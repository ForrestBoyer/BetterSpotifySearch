using BetterSpotifySearchAPI.Controllers;

namespace BetterSpotifySearchAPI.Tests;

public class ExampleController_Tests
{
    [Fact]
    public void TestGetRandomNumber()
    {
        var contoller = new ExampleController();

        Assert.InRange(contoller.GetRandomNumber(), int.MinValue, int.MaxValue);
    }

    [Fact]
    public void Test()
    {
        Assert.Equal(0, 0);
    }
}
