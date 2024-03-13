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
    public void TestGetRandomNumbers()
    {
        var controller = new ExampleController();

        var numbers = controller.GetRandomNumbers(10);

        foreach (var number in numbers)
        {
            Assert.InRange(number, int.MinValue, int.MaxValue);
        }
    }
}
