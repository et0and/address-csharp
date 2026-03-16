using System.Text.Json;
using Address.Core;
using Address.Models.Health;

namespace Address.Tests.Models.Health;

public class HealthCheckResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new HealthCheckResponse { Status = "status", Timestamp = "timestamp" };

        string expectedStatus = "status";
        string expectedTimestamp = "timestamp";

        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTimestamp, model.Timestamp);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new HealthCheckResponse { Status = "status", Timestamp = "timestamp" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<HealthCheckResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new HealthCheckResponse { Status = "status", Timestamp = "timestamp" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<HealthCheckResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedStatus = "status";
        string expectedTimestamp = "timestamp";

        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new HealthCheckResponse { Status = "status", Timestamp = "timestamp" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new HealthCheckResponse { Status = "status", Timestamp = "timestamp" };

        HealthCheckResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
