using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Address.Core;

namespace Address.Models.RequestKey;

[JsonConverter(
    typeof(JsonModelConverter<RequestKeyCreateResponse, RequestKeyCreateResponseFromRaw>)
)]
public sealed record class RequestKeyCreateResponse : JsonModel
{
    public required string ApiKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("apiKey");
        }
        init { this._rawData.Set("apiKey", value); }
    }

    public required double RateLimit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("rateLimit");
        }
        init { this._rawData.Set("rateLimit", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ApiKey;
        _ = this.RateLimit;
    }

    public RequestKeyCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RequestKeyCreateResponse(RequestKeyCreateResponse requestKeyCreateResponse)
        : base(requestKeyCreateResponse) { }
#pragma warning restore CS8618

    public RequestKeyCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RequestKeyCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RequestKeyCreateResponseFromRaw.FromRawUnchecked"/>
    public static RequestKeyCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RequestKeyCreateResponseFromRaw : IFromRawJson<RequestKeyCreateResponse>
{
    /// <inheritdoc/>
    public RequestKeyCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RequestKeyCreateResponse.FromRawUnchecked(rawData);
}
