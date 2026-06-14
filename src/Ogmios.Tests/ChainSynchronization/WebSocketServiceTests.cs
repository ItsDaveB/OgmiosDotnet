using Ogmios.Services.ChainSynchronization;

namespace Ogmios.Tests.ChainSynchronization;

public class WebSocketServiceTests
{
    [Theory]
    [InlineData(WebSocketTimeouts.Infinite, WebSocketTimeouts.Infinite)]
    [InlineData(0, WebSocketTimeouts.Default)]
    [InlineData(2500, 2500)]
    public void ResolveTimeoutMilliseconds_ReturnsExpectedValue(int input, int expected)
    {
        Assert.Equal(expected, WebSocketTimeouts.ResolveTimeoutMilliseconds(input));
    }
}
