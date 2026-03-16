using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Address.Core;

namespace Address.Models.Meta;

[JsonConverter(typeof(JsonModelConverter<MetaRetrieveResponse, MetaRetrieveResponseFromRaw>))]
public sealed record class MetaRetrieveResponse : JsonModel
{
    public required string LastUpdated
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("lastUpdated");
        }
        init { this._rawData.Set("lastUpdated", value); }
    }

    public required double TotalAddresses
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("totalAddresses");
        }
        init { this._rawData.Set("totalAddresses", value); }
    }

    public required string Version
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("version");
        }
        init { this._rawData.Set("version", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.LastUpdated;
        _ = this.TotalAddresses;
        _ = this.Version;
    }

    public MetaRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MetaRetrieveResponse(MetaRetrieveResponse metaRetrieveResponse)
        : base(metaRetrieveResponse) { }
#pragma warning restore CS8618

    public MetaRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MetaRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MetaRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static MetaRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MetaRetrieveResponseFromRaw : IFromRawJson<MetaRetrieveResponse>
{
    /// <inheritdoc/>
    public MetaRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MetaRetrieveResponse.FromRawUnchecked(rawData);
}
