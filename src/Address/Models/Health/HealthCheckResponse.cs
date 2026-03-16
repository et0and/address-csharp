using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Address.Core;

namespace Address.Models.Health;

[JsonConverter(typeof(JsonModelConverter<HealthCheckResponse, HealthCheckResponseFromRaw>))]
public sealed record class HealthCheckResponse : JsonModel
{
    public required string Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public required string Timestamp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("timestamp");
        }
        init { this._rawData.Set("timestamp", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Status;
        _ = this.Timestamp;
    }

    public HealthCheckResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public HealthCheckResponse(HealthCheckResponse healthCheckResponse)
        : base(healthCheckResponse) { }
#pragma warning restore CS8618

    public HealthCheckResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    HealthCheckResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="HealthCheckResponseFromRaw.FromRawUnchecked"/>
    public static HealthCheckResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class HealthCheckResponseFromRaw : IFromRawJson<HealthCheckResponse>
{
    /// <inheritdoc/>
    public HealthCheckResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        HealthCheckResponse.FromRawUnchecked(rawData);
}
