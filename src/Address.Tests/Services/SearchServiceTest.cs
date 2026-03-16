using System.Threading.Tasks;

namespace Address.Tests.Services;

public class SearchServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Query_Works()
    {
        var response = await this.client.Search.Query(
            new() { Q = "q" },
            TestContext.Current.CancellationToken
        );
        foreach (var item in response)
        {
            item.Validate();
        }
    }
}
