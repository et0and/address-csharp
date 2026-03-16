using System.Text.Json;
using Address.Core;
using Address.Models.Challenge;

namespace Address.Tests.Models.Challenge;

public class ChallengeRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChallengeRetrieveResponse
        {
            Token = "token",
            Challenge = "challenge",
            Difficulty = 0,
            ExpiresAt = 0,
        };

        string expectedToken = "token";
        string expectedChallenge = "challenge";
        double expectedDifficulty = 0;
        double expectedExpiresAt = 0;

        Assert.Equal(expectedToken, model.Token);
        Assert.Equal(expectedChallenge, model.Challenge);
        Assert.Equal(expectedDifficulty, model.Difficulty);
        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChallengeRetrieveResponse
        {
            Token = "token",
            Challenge = "challenge",
            Difficulty = 0,
            ExpiresAt = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChallengeRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChallengeRetrieveResponse
        {
            Token = "token",
            Challenge = "challenge",
            Difficulty = 0,
            ExpiresAt = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChallengeRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedToken = "token";
        string expectedChallenge = "challenge";
        double expectedDifficulty = 0;
        double expectedExpiresAt = 0;

        Assert.Equal(expectedToken, deserialized.Token);
        Assert.Equal(expectedChallenge, deserialized.Challenge);
        Assert.Equal(expectedDifficulty, deserialized.Difficulty);
        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChallengeRetrieveResponse
        {
            Token = "token",
            Challenge = "challenge",
            Difficulty = 0,
            ExpiresAt = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChallengeRetrieveResponse
        {
            Token = "token",
            Challenge = "challenge",
            Difficulty = 0,
            ExpiresAt = 0,
        };

        ChallengeRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
