using System.Threading.Tasks;

namespace Address.Tests.Services;

public class MetaServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var meta = await this.client.Meta.Retrieve(new(), TestContext.Current.CancellationToken);
        meta.Validate();
    }
}
