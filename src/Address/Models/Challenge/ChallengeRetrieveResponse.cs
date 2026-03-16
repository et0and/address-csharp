using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Address.Core;

namespace Address.Models.Challenge;

[JsonConverter(
    typeof(JsonModelConverter<ChallengeRetrieveResponse, ChallengeRetrieveResponseFromRaw>)
)]
public sealed record class ChallengeRetrieveResponse : JsonModel
{
    public required string Token
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("token");
        }
        init { this._rawData.Set("token", value); }
    }

    public required string Challenge
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("challenge");
        }
        init { this._rawData.Set("challenge", value); }
    }

    public required double Difficulty
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("difficulty");
        }
        init { this._rawData.Set("difficulty", value); }
    }

    public required double ExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("expiresAt");
        }
        init { this._rawData.Set("expiresAt", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Token;
        _ = this.Challenge;
        _ = this.Difficulty;
        _ = this.ExpiresAt;
    }

    public ChallengeRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChallengeRetrieveResponse(ChallengeRetrieveResponse challengeRetrieveResponse)
        : base(challengeRetrieveResponse) { }
#pragma warning restore CS8618

    public ChallengeRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChallengeRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChallengeRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static ChallengeRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChallengeRetrieveResponseFromRaw : IFromRawJson<ChallengeRetrieveResponse>
{
    /// <inheritdoc/>
    public ChallengeRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChallengeRetrieveResponse.FromRawUnchecked(rawData);
}
