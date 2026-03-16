using System.Threading.Tasks;

namespace Address.Tests.Services;

public class ReverseServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Geocode_Works()
    {
        var response = await this.client.Reverse.Geocode(
            new() { Point = "point" },
            TestContext.Current.CancellationToken
        );
        foreach (var item in response)
        {
            item.Validate();
        }
    }
}
