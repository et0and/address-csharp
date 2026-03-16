using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Address.Core;

namespace Address.Models;

[JsonConverter(
    typeof(JsonModelConverter<ClientGetApiInfoResponse, ClientGetApiInfoResponseFromRaw>)
)]
public sealed record class ClientGetApiInfoResponse : JsonModel
{
    public required IReadOnlyList<string> Endpoints
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("endpoints");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "endpoints",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
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
        _ = this.Endpoints;
        _ = this.Name;
        _ = this.Version;
    }

    public ClientGetApiInfoResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ClientGetApiInfoResponse(ClientGetApiInfoResponse clientGetApiInfoResponse)
        : base(clientGetApiInfoResponse) { }
#pragma warning restore CS8618

    public ClientGetApiInfoResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ClientGetApiInfoResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ClientGetApiInfoResponseFromRaw.FromRawUnchecked"/>
    public static ClientGetApiInfoResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ClientGetApiInfoResponseFromRaw : IFromRawJson<ClientGetApiInfoResponse>
{
    /// <inheritdoc/>
    public ClientGetApiInfoResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ClientGetApiInfoResponse.FromRawUnchecked(rawData);
}
