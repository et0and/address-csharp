using System.Collections.Generic;
using System.Text.Json;
using Address.Core;
using Address.Models;

namespace Address.Tests.Models;

public class ClientGetApiInfoResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ClientGetApiInfoResponse
        {
            Endpoints = ["string"],
            Name = "name",
            Version = "version",
        };

        List<string> expectedEndpoints = ["string"];
        string expectedName = "name";
        string expectedVersion = "version";

        Assert.Equal(expectedEndpoints.Count, model.Endpoints.Count);
        for (int i = 0; i < expectedEndpoints.Count; i++)
        {
            Assert.Equal(expectedEndpoints[i], model.Endpoints[i]);
        }
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedVersion, model.Version);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ClientGetApiInfoResponse
        {
            Endpoints = ["string"],
            Name = "name",
            Version = "version",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClientGetApiInfoResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ClientGetApiInfoResponse
        {
            Endpoints = ["string"],
            Name = "name",
            Version = "version",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClientGetApiInfoResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedEndpoints = ["string"];
        string expectedName = "name";
        string expectedVersion = "version";

        Assert.Equal(expectedEndpoints.Count, deserialized.Endpoints.Count);
        for (int i = 0; i < expectedEndpoints.Count; i++)
        {
            Assert.Equal(expectedEndpoints[i], deserialized.Endpoints[i]);
        }
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedVersion, deserialized.Version);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ClientGetApiInfoResponse
        {
            Endpoints = ["string"],
            Name = "name",
            Version = "version",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ClientGetApiInfoResponse
        {
            Endpoints = ["string"],
            Name = "name",
            Version = "version",
        };

        ClientGetApiInfoResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
