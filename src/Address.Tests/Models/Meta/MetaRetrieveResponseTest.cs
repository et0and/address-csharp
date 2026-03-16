using System.Text.Json;
using Address.Core;
using Address.Models.Meta;

namespace Address.Tests.Models.Meta;

public class MetaRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MetaRetrieveResponse
        {
            LastUpdated = "lastUpdated",
            TotalAddresses = 0,
            Version = "version",
        };

        string expectedLastUpdated = "lastUpdated";
        double expectedTotalAddresses = 0;
        string expectedVersion = "version";

        Assert.Equal(expectedLastUpdated, model.LastUpdated);
        Assert.Equal(expectedTotalAddresses, model.TotalAddresses);
        Assert.Equal(expectedVersion, model.Version);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MetaRetrieveResponse
        {
            LastUpdated = "lastUpdated",
            TotalAddresses = 0,
            Version = "version",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MetaRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MetaRetrieveResponse
        {
            LastUpdated = "lastUpdated",
            TotalAddresses = 0,
            Version = "version",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MetaRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedLastUpdated = "lastUpdated";
        double expectedTotalAddresses = 0;
        string expectedVersion = "version";

        Assert.Equal(expectedLastUpdated, deserialized.LastUpdated);
        Assert.Equal(expectedTotalAddresses, deserialized.TotalAddresses);
        Assert.Equal(expectedVersion, deserialized.Version);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MetaRetrieveResponse
        {
            LastUpdated = "lastUpdated",
            TotalAddresses = 0,
            Version = "version",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MetaRetrieveResponse
        {
            LastUpdated = "lastUpdated",
            TotalAddresses = 0,
            Version = "version",
        };

        MetaRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
