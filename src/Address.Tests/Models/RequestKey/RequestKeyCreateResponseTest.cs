using System.Text.Json;
using Address.Core;
using Address.Models.RequestKey;

namespace Address.Tests.Models.RequestKey;

public class RequestKeyCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RequestKeyCreateResponse { ApiKey = "apiKey", RateLimit = 0 };

        string expectedApiKey = "apiKey";
        double expectedRateLimit = 0;

        Assert.Equal(expectedApiKey, model.ApiKey);
        Assert.Equal(expectedRateLimit, model.RateLimit);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RequestKeyCreateResponse { ApiKey = "apiKey", RateLimit = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RequestKeyCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RequestKeyCreateResponse { ApiKey = "apiKey", RateLimit = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RequestKeyCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedApiKey = "apiKey";
        double expectedRateLimit = 0;

        Assert.Equal(expectedApiKey, deserialized.ApiKey);
        Assert.Equal(expectedRateLimit, deserialized.RateLimit);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RequestKeyCreateResponse { ApiKey = "apiKey", RateLimit = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RequestKeyCreateResponse { ApiKey = "apiKey", RateLimit = 0 };

        RequestKeyCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
