using System.Threading.Tasks;

namespace Address.Tests.Services;

public class ChallengeServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var challenge = await this.client.Challenge.Retrieve(
            new(),
            TestContext.Current.CancellationToken
        );
        challenge.Validate();
    }
}
