using System;
using Address.Models.RequestKey;

namespace Address.Tests.Models.RequestKey;

public class RequestKeyCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RequestKeyCreateParams
        {
            Token = "token",
            Challenge = "challenge",
            Nonce = 0,
        };

        string expectedToken = "token";
        string expectedChallenge = "challenge";
        double expectedNonce = 0;

        Assert.Equal(expectedToken, parameters.Token);
        Assert.Equal(expectedChallenge, parameters.Challenge);
        Assert.Equal(expectedNonce, parameters.Nonce);
    }

    [Fact]
    public void Url_Works()
    {
        RequestKeyCreateParams parameters = new()
        {
            Token = "token",
            Challenge = "challenge",
            Nonce = 0,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://address.tom.so/request-key"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RequestKeyCreateParams
        {
            Token = "token",
            Challenge = "challenge",
            Nonce = 0,
        };

        RequestKeyCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
