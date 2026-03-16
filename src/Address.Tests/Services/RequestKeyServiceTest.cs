using System.Threading.Tasks;

namespace Address.Tests.Services;

public class RequestKeyServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var requestKey = await this.client.RequestKey.Create(
            new()
            {
                Token = "token",
                Challenge = "challenge",
                Nonce = 0,
            },
            TestContext.Current.CancellationToken
        );
        requestKey.Validate();
    }
}
