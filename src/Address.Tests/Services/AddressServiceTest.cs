using System.Threading.Tasks;

namespace Address.Tests.Services;

public class AddressServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var address = await this.client.Addresses.Retrieve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        address.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var addresses = await this.client.Addresses.List(
            new(),
            TestContext.Current.CancellationToken
        );
        foreach (var item in addresses)
        {
            item.Validate();
        }
    }
}
